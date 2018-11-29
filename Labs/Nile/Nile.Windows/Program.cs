/*
 * Hoa Luu
 * ITSE 1430
 * Lab 4
 * 11/25/2018 
 */

using System;
using System.Windows.Forms;

namespace Nile.Windows
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
            Application.Run(new MainForm());
        }
    }
}
