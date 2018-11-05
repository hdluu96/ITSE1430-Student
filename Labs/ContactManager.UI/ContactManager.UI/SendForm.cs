using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactManager.UI
{
    public partial class SendForm : Form
    {
        public SendForm()
        {
            InitializeComponent();
        }

        public SendMessage Send { get; set; }

        private void SendForm_Load(object sender, EventArgs e)
        {
            if (Send != null)
            {
                _txtSubject.Text = Send.Subject;
                _txtMessage.Text = Send.Message;
            };

            ValidateChildren();
        }

        private void OnCancel(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OnSend(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;

            var subject = new SendMessage()
            {
                Subject = _txtSubject.Text,
            };

            var results = ObjectValidator.Validate(subject);
            foreach (var result in results)
            {
                MessageBox.Show(this, result.ErrorMessage, "Invalid Input",
                                 MessageBoxButtons.OK);
                return;
            };

            Send = subject;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
