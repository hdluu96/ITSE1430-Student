/* Hoa Luu
 * ITSE 1430
 * 10/18/2018
 */

using System;
using System.ComponentModel;
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

        private int GetInt32 (TextBox textBox)
        {
            if (String.IsNullOrEmpty(textBox.Text))
                return -1;
            if (Int32.TryParse(textBox.Text, out var value))
                return value;

            return -1;
        }

        private void CharacterForm_Load( object sender, EventArgs e )
        {
            if (Character != null)
            {
                _txtName.Text = Character.Name;
                _comboProfession.Text = Character.Profession;
                _comboRace.Text = Character.Race;
                _txtStrength.Text = Character.Strength.ToString();
                _txtIntelligence.Text = Character.Intelligence.ToString();
                _txtAgility.Text = Character.Agility.ToString();
                _txtConstitution.Text = Character.Constitution.ToString();
                _txtCharisma.Text = Character.Charisma.ToString();
            };

            ValidateChildren();
        }

        private void OnSave( object sender, EventArgs e )
        {
            var character = new Character();
            if (!ValidateChildren())
                return;

            character.Name = _txtName.Text;
            character.Profession = _comboProfession.Text;
            character.Race = _comboRace.Text;
            character.Strength = GetInt32(_txtStrength);
            character.Intelligence = GetInt32(_txtIntelligence);
            character.Agility = GetInt32(_txtAgility);
            character.Constitution = GetInt32(_txtConstitution);
            character.Charisma = GetInt32(_txtCharisma);

            Character = character;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void OnCancel( object sender, EventArgs e )
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OnValidateName( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;

            if (String.IsNullOrEmpty(control.Text))
            {
                _errors.SetError(control, "A name is required");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }

        private void OnValidateAttributes( object sender, CancelEventArgs e )
        {
            var control = sender as TextBox;
            var result = GetInt32(control);
            if (result < 0 || result > 100)
            {
                _errors.SetError(control, "Value between 1-100");
                e.Cancel = true;
            } else
                _errors.SetError(control, "");
        }
    }
}
