using Fraysa.MapleStory.reWZ;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace Fraysa.MapleStory.Studio
{
    internal static class Program
    {
        public static Dictionary<string, WZFile> WzFileCache = new Dictionary<string, WZFile>();

        [STAThread]
        private static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhandledException;
            Application.ThreadException += Application_ThreadException;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }

        private static void ShowUnhandledExceptionMessage(Exception exception)
        {
            if (MessageForm.Show(String.Format("What the heck did you do? {0}{1}I you find a developer"
                + " (one of these apes running around in town), please tell him the following weirdly looking details:"
                + "{1}{1}{2}{1}{1}Do you want to continue using the application (it might explode into cheese)?",
                exception.Message, Environment.NewLine, exception.ToString()), MessageBoxButtons.YesNo,
                MessageBoxIcon.Error) == DialogResult.No)
            {
                Application.Exit();
            }
        }

        private static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            ShowUnhandledExceptionMessage(e.Exception);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            ShowUnhandledExceptionMessage((Exception)e.ExceptionObject);
        }
    }
}
