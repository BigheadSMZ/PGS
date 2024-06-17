using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
#pragma warning disable 0219, 0414, 0162
public class FolderSelectDialog
{
    private string _initialDirectory;
    private string _title;
    private string _message;
    private string _fileName = "";

    public string InitialDirectory
    {
        get { return string.IsNullOrEmpty(_initialDirectory) ? Environment.CurrentDirectory : _initialDirectory; }
        set { _initialDirectory = value; }
    }

    public string Title
    {
        get { return _title ?? "Select a folder"; }
        set { _title = value; }
    }

    public string Message
    {
        get { return _message ?? _title ?? "Select a folder"; }
        set { _message = value; }
    }

    public string FileName { get { return _fileName; } }

    public FolderSelectDialog(string defaultPath = "MyComputer", string title = "Select a folder", string message = "")
    {
        InitialDirectory = defaultPath;
        Title = title;
        Message = message;
    }

    public bool Show() { return Show(IntPtr.Zero); }

    public bool Show(IntPtr? hWndOwnerNullable = null)
    {
        IntPtr hWndOwner = IntPtr.Zero;
        if (hWndOwnerNullable != null)
            hWndOwner = (IntPtr)hWndOwnerNullable;
        if (Environment.OSVersion.Version.Major >= 6)
        {
            try
            {
                var resulta = VistaDialog.Show(hWndOwner, InitialDirectory, Title, Message);
                _fileName = resulta.FileName;
                return resulta.Result;
            }
            catch (Exception)
            {
                var resultb = ShowXpDialog(hWndOwner, InitialDirectory, Title, Message);
                _fileName = resultb.FileName;
                return resultb.Result;
            }
        }
        var result = ShowXpDialog(hWndOwner, InitialDirectory, Title, Message);
        _fileName = result.FileName;
        return result.Result;
    }
    private struct ShowDialogResult
    {
        public bool Result { get; set; }
        public string FileName { get; set; }
    }
    private static ShowDialogResult ShowXpDialog(IntPtr ownerHandle, string initialDirectory, string title, string message)
    {
        var folderBrowserDialog = new FolderBrowserDialog
        {
            Description = message,
            SelectedPath = initialDirectory,
            ShowNewFolderButton = true
        };
        var dialogResult = new ShowDialogResult();
        if (folderBrowserDialog.ShowDialog(new WindowWrapper(ownerHandle)) == DialogResult.OK)
        {
            dialogResult.Result = true;
            dialogResult.FileName = folderBrowserDialog.SelectedPath;
        }
        return dialogResult;
    }
    private static class VistaDialog
    {
        private const string c_foldersFilter = "Folders|\n";
        private const BindingFlags c_flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;
        private readonly static Assembly s_windowsFormsAssembly = typeof(FileDialog).Assembly;
        private readonly static Type s_iFileDialogType = s_windowsFormsAssembly.GetType("System.Windows.Forms.FileDialogNative+IFileDialog");
        private readonly static MethodInfo s_createVistaDialogMethodInfo = typeof(OpenFileDialog).GetMethod("CreateVistaDialog", c_flags);
        private readonly static MethodInfo s_onBeforeVistaDialogMethodInfo = typeof(OpenFileDialog).GetMethod("OnBeforeVistaDialog", c_flags);
        private readonly static MethodInfo s_getOptionsMethodInfo = typeof(FileDialog).GetMethod("GetOptions", c_flags);
        private readonly static MethodInfo s_setOptionsMethodInfo = s_iFileDialogType.GetMethod("SetOptions", c_flags);
        private readonly static uint s_fosPickFoldersBitFlag = (uint)s_windowsFormsAssembly
            .GetType("System.Windows.Forms.FileDialogNative+FOS")
            .GetField("FOS_PICKFOLDERS")
            .GetValue(null);
        private readonly static ConstructorInfo s_vistaDialogEventsConstructorInfo = s_windowsFormsAssembly
            .GetType("System.Windows.Forms.FileDialog+VistaDialogEvents")
            .GetConstructor(c_flags, null, new[] { typeof(FileDialog) }, null);
        private readonly static MethodInfo s_adviseMethodInfo = s_iFileDialogType.GetMethod("Advise");
        private readonly static MethodInfo s_unAdviseMethodInfo = s_iFileDialogType.GetMethod("Unadvise");
        private readonly static MethodInfo s_showMethodInfo = s_iFileDialogType.GetMethod("Show");
        public static ShowDialogResult Show(IntPtr ownerHandle, string initialDirectory, string title, string description)
        {
            var openFileDialog = new OpenFileDialog
            {
                AddExtension = false,
                CheckFileExists = false,
                DereferenceLinks = true,
                Filter = c_foldersFilter,
                InitialDirectory = initialDirectory,
                Multiselect = false,
                Title = title
            };
            var iFileDialog = s_createVistaDialogMethodInfo.Invoke(openFileDialog, new object[] { });
            s_onBeforeVistaDialogMethodInfo.Invoke(openFileDialog, new[] { iFileDialog });
            s_setOptionsMethodInfo.Invoke(iFileDialog, new object[] { (uint)s_getOptionsMethodInfo.Invoke(openFileDialog, new object[] { }) | s_fosPickFoldersBitFlag });
            var adviseParametersWithOutputConnectionToken = new[] { s_vistaDialogEventsConstructorInfo.Invoke(new object[] { openFileDialog }), 0U };
            s_adviseMethodInfo.Invoke(iFileDialog, adviseParametersWithOutputConnectionToken);
            try
            {
                int retVal = (int)s_showMethodInfo.Invoke(iFileDialog, new object[] { ownerHandle });
                return new ShowDialogResult
                {
                    Result = retVal == 0,
                    FileName = openFileDialog.FileName
                };
            }
            finally
            {
                s_unAdviseMethodInfo.Invoke(iFileDialog, new[] { adviseParametersWithOutputConnectionToken[1] });
            }
        }
    }

    private class WindowWrapper : IWin32Window
    {
        private readonly IntPtr _handle;
        public WindowWrapper(IntPtr handle) { _handle = handle; }
        public IntPtr Handle { get { return _handle; } }
    }

    public string getPath()
    {
        if (Show())
        {
            return FileName;
        }
        return "";
    }
}
