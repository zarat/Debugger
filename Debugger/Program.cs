using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace IDE
{
    static class Program
    {
        #region Public Static Methods

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Debugger());
        }

        #endregion
    }
}