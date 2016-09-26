using System;
using System.Threading;
using System.Windows.Forms;
using TLShoes.Common;

namespace TLShoes
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
#if !DEBUG
            // Add the event handler for handling UI thread exceptions to the event.
            Application.ThreadException += new ThreadExceptionEventHandler(ErrorControl.UIThreadException);

            // Set the unhandled exception mode to force all Windows Forms errors to go through
            // our handler.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
#endif

            // Init user account
            Authorization.LoginUser = new UserAccount(){Id = 1, TenNguoiDung = "Long Nguyen"};

            Application.Run(FormFactory<Main>.Get());
        }
    }
}
