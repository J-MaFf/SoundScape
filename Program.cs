namespace SoundScape;

using COMPSCI366.Models;
using System.Threading;

static partial class Program
{
    [System.Runtime.InteropServices.LibraryImport("kernel32.dll")]
    [return: System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.Bool)]
    private static partial bool AllocConsole();
    /// <summary>
    ///  The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        //AllocConsole();

        ApplicationConfiguration.Initialize();
        Application.Run(new Form1());
    }
}
