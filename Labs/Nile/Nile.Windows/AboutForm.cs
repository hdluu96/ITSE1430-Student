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
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void OnOkClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
