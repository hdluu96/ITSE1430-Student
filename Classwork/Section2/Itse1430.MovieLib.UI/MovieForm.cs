using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Itse1430.MovieLib.UI
{
    public partial class MovieForm : Form
    {
        public MovieForm()
        {
            InitializeComponent();
        }

        public Movie Movie { get; set; }

        private void label3_Click( object sender, EventArgs e )
        {

        }

        private void textBox1_TextChanged( object sender, EventArgs e )
        {

        }

        private void OnCancel( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OnSave( object sender, EventArgs e )
        {
            if (!ValidateChildren())
                return;

            var movie = new Movie()
            {
                Name = _txtName.Text,
                Description = _txtDescription.Text,
                ReleaseYear = GetInt32(_txtReleaseYear),
                RunLength = GetInt32(_txtRunLength),
                IsOwned = _chkOwned.Checked,
            };
            Movie = movie;
            DialogResult = DialogResult.OK;
            Close();
        }

        private int GetInt32( TextBox textBox )
        {
            if (String.IsNullOrEmpty(textBox.Text))
                return -1;

            if (Int32.TryParse(textBox.Text, out var value))
                return value;

            return -1;
        }

        private void MovieForm_Load( object sender, EventArgs e )
        {
            if (Movie != null)
            {
                _txtName.Text = Movie.Name;
                _txtDescription.Text = Movie.Description;
                _txtReleaseYear.Text = Movie.ReleaseYear.ToString();
                _txtRunLength.Text = Movie.RunLength.ToString();
                _chkOwned.Checked = Movie.IsOwned;
            };
            ValidateChildren();
        }

        private void label2_Click( object sender, EventArgs e )
        {

        }

        private void OnValidateName( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;
            {
                if (String.IsNullOrEmpty(control.Text))
                {
                    _error.SetError(control, "Name is required");
                    e.Cancel = true;
                } else
                    _error.SetError(control, "");
            }
        }

        private void OnValidatingRunLength( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;
            var result = GetInt32(control);
            if (result < 0)
            {
                _error.SetError(control, "Must be > 0");
                e.Cancel = true;
            } else
                _error.SetError(control, "");
        }

        private void OnValidatingReleaseYear( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;
            var result = GetInt32(control);
            if (result < 1900)
            {
                _error.SetError(control, "Must be > 1900");
                e.Cancel = true;
            } else
                _error.SetError(control, "");
        }
    }
}
