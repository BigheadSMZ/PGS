using System.Runtime.InteropServices;

// Credits to Ivan Yakimov at codeproject. This is phenomenal code.
// https://www.codeproject.com/Articles/639486/Save-and-Restore-Icon-Positions-on-Desktop

namespace IconsRestorer.Code
{
    [StructLayout(LayoutKind.Sequential)]
    public struct DesktopPoint
    {
        public int X;
        public int Y;

        public DesktopPoint(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
    }

    public struct NamedDesktopPoint
    {
        public string Name;
        public int X;
        public int Y;

        public NamedDesktopPoint(string name, int x, int y)
        {
            this.Name = name;
            this.X = x;
            this.Y = y;
        }
    }
}
