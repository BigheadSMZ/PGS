using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Automation;

// Credits to Ivan Yakimov at codeproject. This is phenomenal code.
// https://www.codeproject.com/Articles/639486/Save-and-Restore-Icon-Positions-on-Desktop

namespace IconsRestorer.Code
{
    internal class Desktop
    {
        private readonly IntPtr _desktopHandle;
        private readonly List<string> _currentIconsOrder;

        public Desktop()
        {
            _desktopHandle = Win32.GetDesktopWindow(Win32.DesktopWindow.SysListView32);

            AutomationElement el = AutomationElement.FromHandle(_desktopHandle);

            TreeWalker walker = TreeWalker.ContentViewWalker;
            _currentIconsOrder = new List<string>();
            for (AutomationElement child = walker.GetFirstChild(el);
                child != null;
                child = walker.GetNextSibling(child))
            {
                _currentIconsOrder.Add(child.Current.Name);
            }
        }

        private int GetIconsNumber()
        {
            return (int)Win32.SendMessage(_desktopHandle, Win32.LVM_GETITEMCOUNT, IntPtr.Zero, IntPtr.Zero);
        }

        public NamedDesktopPoint[] GetIconsPositions()
        {
            uint desktopProcessId;
            Win32.GetWindowThreadProcessId(_desktopHandle, out desktopProcessId);

            IntPtr desktopProcessHandle = IntPtr.Zero;
            try
            {
                desktopProcessHandle = Win32.OpenProcess(Win32.ProcessAccess.VmOperation | Win32.ProcessAccess.VmRead |
                    Win32.ProcessAccess.VmWrite, false, desktopProcessId);

                return GetIconsPositions(desktopProcessHandle);
            }
            finally
            {
                if (desktopProcessHandle != IntPtr.Zero)
                { Win32.CloseHandle(desktopProcessHandle); }
            }
        }

        private NamedDesktopPoint[] GetIconsPositions(IntPtr desktopProcessHandle)
        {
            IntPtr sharedMemoryPointer = IntPtr.Zero;

            try
            {
                sharedMemoryPointer = Win32.VirtualAllocEx(desktopProcessHandle, IntPtr.Zero, 4096, Win32.AllocationType.Reserve | Win32.AllocationType.Commit, Win32.MemoryProtection.ReadWrite);

                return GetIconsPositions(desktopProcessHandle, sharedMemoryPointer);
            }
            finally
            {
                if (sharedMemoryPointer != IntPtr.Zero)
                {
                    Win32.VirtualFreeEx(desktopProcessHandle, sharedMemoryPointer, 0, Win32.FreeType.Release);
                }
            }

        }

        private NamedDesktopPoint[] GetIconsPositions(IntPtr desktopProcessHandle, IntPtr sharedMemoryPointer)
        {
            var listOfPoints = new LinkedList<NamedDesktopPoint>();

            var numberOfIcons = GetIconsNumber();

            for (int itemIndex = 0; itemIndex < numberOfIcons; itemIndex++)
            {
                uint numberOfBytes = 0;
                DesktopPoint[] points = new DesktopPoint[1];

                Win32.WriteProcessMemory(desktopProcessHandle, sharedMemoryPointer,
                    Marshal.UnsafeAddrOfPinnedArrayElement(points, 0),
                    Marshal.SizeOf(typeof(DesktopPoint)),
                    ref numberOfBytes);

                Win32.SendMessage(_desktopHandle, Win32.LVM_GETITEMPOSITION, itemIndex, sharedMemoryPointer);

                Win32.ReadProcessMemory(desktopProcessHandle, sharedMemoryPointer,
                    Marshal.UnsafeAddrOfPinnedArrayElement(points, 0),
                    Marshal.SizeOf(typeof(DesktopPoint)),
                    ref numberOfBytes);

                var point = points[0];
                listOfPoints.AddLast(new NamedDesktopPoint(_currentIconsOrder[itemIndex], point.X, point.Y));
            }

            return listOfPoints.ToArray();
        }

        public void SetIconPositions(IEnumerable<NamedDesktopPoint> iconPositions)
        {
            foreach (var position in iconPositions)
            {
                var iconIndex = _currentIconsOrder.IndexOf(position.Name);
                if (iconIndex == -1)
                { continue; }

                Win32.SendMessage(_desktopHandle, Win32.LVM_SETITEMPOSITION, iconIndex, Win32.MakeLParam(position.X, position.Y));
            }
        }

        public void Refresh()
        {
            Win32.PostMessage(_desktopHandle, Win32.WM_KEYDOWN, Win32.VK_F5, 0);

            Win32.SHChangeNotify(0x8000000, 0x1000, IntPtr.Zero, IntPtr.Zero);
        }
    }
}
