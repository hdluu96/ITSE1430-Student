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
    public partial class MainForm : Form
    {
        #region Construction

        public MainForm()
        {
            InitializeComponent();
        }
        #endregion

        //This method can be overriden in a derived type
        protected virtual void SomeFunction ()
        {
            
        }

        //This method MUST BE defined in a derived type
        //protected abstract void SomeAbstractFunction();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            _listMovies.DisplayMember = "Name";
            RefreshMovies();
        }

        private void movieToolStripMenuItem_Click( object sender, EventArgs e )
        {

        }

        private void helpToolStripMenuItem_Click( object sender, EventArgs e )
        {

        }

        private void exitToolStripMenuItem_Click( object sender, EventArgs e )
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Close", MessageBoxButtons.YesNo) == DialogResult.No)
                return;

            Close();
        }

        private void OnHelpAbout( object sender, EventArgs e )
        {
            //aboutToolStripMenuItem.
            MessageBox.Show(this, "Sorry", "Help", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void fileToolStripMenuItem_Click( object sender, EventArgs e )
        {

        }

        private void OnMovieAdd( object sender, EventArgs e )
        {
            var form = new MovieForm();

            if (form.ShowDialog(this) == DialogResult.Cancel)
                return;

            //MessageBox.Show("Adding movie");
            _database.Add(form.Movie);
            //Movie.Name = "";
            RefreshMovies();
        }

        private MovieDatabase _database = new MovieDatabase();

        private void RefreshMovies ()
        {
            var movies = _database.GetAll();

            _listMovies.Items.Clear();
            _listMovies.Items.AddRange(movies);
        }

        private Movie GetSelectedMovie ()
        {
            return _listMovies.SelectedItem as Movie;
        }

        private void OnMovieDelete( object sender, EventArgs e )
        {
            if (MessageBox.Show("Are you sure you want to delete?", "Delete", MessageBoxButtons.YesNo) == DialogResult.No)
                    return;
            DeleteMovie();
        }

        private void OnMovieEdit( object sender, EventArgs e )
        {
            EditMovie();
        }

        private void OnMovieDoubleClick( object sender, EventArgs e )
        {
            EditMovie();
        }

        private void EditMovie()
        {
            var item = GetSelectedMovie();
            if (item == null)
                return;

            var form = new MovieForm();
            form.Movie = item;
            if (form.ShowDialog(this) == DialogResult.Cancel)
                return;

            // Add database and refresh
            _database.Edit(item.Name, form.Movie);
            RefreshMovies();
        }

        private void DeleteMovie()
        {
            var item = GetSelectedMovie();
            if (item == null)
                return;

            _database.Remove(item.Name);
            RefreshMovies();
        }

        private void OnListKeyUp( object sender, KeyEventArgs e )
        {
            if (e.KeyData == Keys.Delete)
            {
                    DeleteMovie();
            };
        }
    }
}
