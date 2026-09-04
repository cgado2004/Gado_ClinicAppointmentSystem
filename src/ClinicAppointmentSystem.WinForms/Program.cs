using ClinicAppointmentSystem.WinForms.Forms;

namespace ClinicAppointmentSystem.WinForms;

internal static class Program
{
    /// <summary>
    /// Application entry point.
    ///
    /// [STAThread] sets a Single-Threaded Apartment, which Windows Forms
    /// requires for COM interop — the clipboard, drag-and-drop, and the common
    /// file dialogs will not work without it.
    /// </summary>
    [STAThread]
    static void Main()
    {
        // .NET 6+ shorthand for EnableVisualStyles + SetCompatibleTextRenderingDefault
        ApplicationConfiguration.Initialize();

        // Application.Run starts the Windows MESSAGE LOOP — the loop that pulls
        // events (clicks, key presses, repaints) from the OS queue and dispatches
        // them to controls. This is the "repetition" in an event-driven program:
        // you never write the WHILE loop yourself.
        Application.Run(new MainForm());
    }
}
