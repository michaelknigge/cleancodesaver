namespace MK.CleanCodeSaver.Core
{
    using System;
    using System.Windows.Forms;

    /// <summary>
    /// This is the main class of CleanCodeSaver.
    /// </summary> 
    public static class Program
    {
        /// <summary>
        /// This is the entry point of CleanCodeSaver.
        /// </summary>
        /// <param name="args">Arguments specified at the command line</param>
        [STAThread]
        public static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length > 0)
            {
                // The secondsArg contains the parent window handle. This may be given like "/P 12345" (two separate
                // arguments) or like "/C:12345" (one argument)...
                string firstArg = args[0];
                string secondArg = args.Length > 1 ? args[1] : firstArg.Length > 3 ? firstArg.Substring(3) : "0";
                long windowHandleValue = long.Parse(secondArg);

                if (args[0].Equals("/S", StringComparison.InvariantCultureIgnoreCase))
                    RunInFullScreenMode();
                else if (args[0].Equals("/C", StringComparison.InvariantCultureIgnoreCase))
                    ShowConfigurationDialog(windowHandleValue);
                else if (args[0].Equals("/P", StringComparison.InvariantCultureIgnoreCase) && windowHandleValue != -1)
                    RunInPreviewMode(windowHandleValue);
                else if (args[0].Equals("/P", StringComparison.InvariantCultureIgnoreCase))
                    MessageBox.Show("Sorry - no preview.", "CleanCodeSaver", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                else
                    MessageBox.Show("CleanCodeSaver has been started with the unknown argument " + args[0], "CleanCodeSaver", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                ShowConfigurationDialog(0);
            }            
        }

        /// <summary>
        /// Runs CleanCodeSaver in full screen mode.
        /// </summary>
        private static void RunInFullScreenMode()
        {
            foreach (Screen screen in Screen.AllScreens)
                new ScreenSaverForm(screen.Bounds).Show();

            Application.Run();
        }

        /// <summary>
        /// Runs CleanCodeSaver in preview mode.
        /// </summary>
        /// <param name="windowHandle">Value of the window handle of the parent window.</param>
        private static void RunInPreviewMode(long windowHandle)
        {
           Application.Run(new ScreenSaverForm(new IntPtr(windowHandle)));
        }

        /// <summary>
        /// Shows the configuration dialog.
        /// </summary>
        /// <param name="windowHandle">Value of the window handle of the parent window.</param>
        private static void ShowConfigurationDialog(long windowHandle)
        {
            // Later.....  --> Application.Run(new SettingsForm());
            MessageBox.Show("The commandments are not negotiable (means: you can not configure CleanCodeSaver).", "CleanCodeSaver", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
