using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CharacterCreator.Winforms
{
    public partial class CharacterForm : Form
    {
        public CharacterForm()
        {
            InitializeComponent();
        }

        public Character Character { get; set; }

        private void OnSave( object sender, EventArgs e )
        {
            var character = new Character();
            character.Name = _txtName.Text;
        }

        private void OnCancel( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            return;
        }

        private void CharacterForm_Load( object sender, EventArgs e )
        {
            if (Character != null)
            {
                _txtName.Text = Character.Name;
            }
        }
    }
}
