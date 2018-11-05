/* 
 * Hoa Luu
 * ITSE 1430
 * November 03, 2018
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ContactManager.Memory;

namespace ContactManager.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            _listBoxContacts.DisplayMember = "Name";
            RefreshContacts();
        }

        private void OnFileExit( object sender, EventArgs e )
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Close",
                MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            Close();
        }

        private void OnHelpAbout( object sender, EventArgs e )
        {
            MessageBox.Show(this, "Hoa Luu\nITSE1430\nCharacter Creator", "Info",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OnContactAdd( object sender, EventArgs e )
        {
            var form = new ContactForm();
            if (form.ShowDialog(this) == DialogResult.Cancel)
                return;

            _database.Add(form.Contact);
            RefreshContacts();
        }

        private void RefreshContacts()
        {
            var movies = from m in _database.GetAll()
                         orderby m.Name
                         select m;

            _listBoxContacts.Items.Clear();
            _listBoxContacts.Items.AddRange(movies.ToArray());
        }

        private void OnContactEdit( object sender, EventArgs e )
        {
            EditContact();
        }

        private void EditContact()
        {
            var item = GetSelectedContact();
            if (item == null)
                return;

            var form = new ContactForm();
            //form.Text = "Edit Contact";
            form.Contact = item;
            if (form.ShowDialog(this) == DialogResult.Cancel)
                return;

            _database.Edit(item.Name, form.Contact);
            RefreshContacts();
        }

        private Contact GetSelectedContact()
        {
            return _listBoxContacts.SelectedItem as Contact;
        }

        private void OnContactDoubleClick( object sender, EventArgs e )
        {
            EditContact();
        }

        private IContactDatabase _database = new MemoryContactDatabase();

        private void OnContactDelete( object sender, EventArgs e )
        {
            DeleteContact();
        }

        private void DeleteContact()
        {
            var item = GetSelectedContact();
            if (item == null)
                return;

            if (MessageBox.Show("Are you sure you want to delete this Contact?",
                     "Delete Contact", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            _database.Remove(item.Name);
            RefreshContacts();
        }

        private void OnListKeyUp( object sender, KeyEventArgs e )
        {
            if (e.KeyData == Keys.Delete)
            {
                DeleteContact();
            };
        }

        private void OnSendMessage(object sender, EventArgs e)
        {
            var form = new SendForm();
            if (form.ShowDialog(this) == DialogResult.Cancel)
                return;
        }

        private SendMessage GetSend()
        {
            return _listBoxSend.SelectedItem as SendMessage;
        }
    }
}
