namespace CharacterCreator.Winforms
{
    partial class CharacterForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing )
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._txtName = new System.Windows.Forms.TextBox();
            this._comboProfession = new System.Windows.Forms.ComboBox();
            this._comboRace = new System.Windows.Forms.ComboBox();
            this._txtStrength = new System.Windows.Forms.TextBox();
            this._txtIntelligence = new System.Windows.Forms.TextBox();
            this._txtAgility = new System.Windows.Forms.TextBox();
            this._txtConstitution = new System.Windows.Forms.TextBox();
            this._txtCharisma = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // _txtName
            // 
            this._txtName.Location = new System.Drawing.Point(12, 39);
            this._txtName.Name = "_txtName";
            this._txtName.Size = new System.Drawing.Size(100, 20);
            this._txtName.TabIndex = 1;
            // 
            // _comboProfession
            // 
            this._comboProfession.FormattingEnabled = true;
            this._comboProfession.Location = new System.Drawing.Point(13, 66);
            this._comboProfession.Name = "_comboProfession";
            this._comboProfession.Size = new System.Drawing.Size(121, 21);
            this._comboProfession.TabIndex = 2;
            // 
            // _comboRace
            // 
            this._comboRace.FormattingEnabled = true;
            this._comboRace.Location = new System.Drawing.Point(13, 94);
            this._comboRace.Name = "_comboRace";
            this._comboRace.Size = new System.Drawing.Size(121, 21);
            this._comboRace.TabIndex = 3;
            // 
            // _txtStrength
            // 
            this._txtStrength.Location = new System.Drawing.Point(13, 122);
            this._txtStrength.Name = "_txtStrength";
            this._txtStrength.Size = new System.Drawing.Size(100, 20);
            this._txtStrength.TabIndex = 4;
            // 
            // _txtIntelligence
            // 
            this._txtIntelligence.Location = new System.Drawing.Point(120, 122);
            this._txtIntelligence.Name = "_txtIntelligence";
            this._txtIntelligence.Size = new System.Drawing.Size(100, 20);
            this._txtIntelligence.TabIndex = 5;
            // 
            // _txtAgility
            // 
            this._txtAgility.Location = new System.Drawing.Point(13, 149);
            this._txtAgility.Name = "_txtAgility";
            this._txtAgility.Size = new System.Drawing.Size(100, 20);
            this._txtAgility.TabIndex = 6;
            // 
            // _txtConstitution
            // 
            this._txtConstitution.Location = new System.Drawing.Point(120, 149);
            this._txtConstitution.Name = "_txtConstitution";
            this._txtConstitution.Size = new System.Drawing.Size(100, 20);
            this._txtConstitution.TabIndex = 7;
            // 
            // _txtCharisma
            // 
            this._txtCharisma.Location = new System.Drawing.Point(13, 176);
            this._txtCharisma.Name = "_txtCharisma";
            this._txtCharisma.Size = new System.Drawing.Size(100, 20);
            this._txtCharisma.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(120, 222);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 9;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnSave);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(201, 222);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 10;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.OnCancel);
            // 
            // CharacterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this._txtCharisma);
            this.Controls.Add(this._txtConstitution);
            this.Controls.Add(this._txtAgility);
            this.Controls.Add(this._txtIntelligence);
            this.Controls.Add(this._txtStrength);
            this.Controls.Add(this._comboRace);
            this.Controls.Add(this._comboProfession);
            this.Controls.Add(this._txtName);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(300, 300);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(300, 300);
            this.Name = "CharacterForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create New Character";
            this.Load += new System.EventHandler(this.CharacterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox _txtName;
        private System.Windows.Forms.ComboBox _comboProfession;
        private System.Windows.Forms.ComboBox _comboRace;
        private System.Windows.Forms.TextBox _txtStrength;
        private System.Windows.Forms.TextBox _txtIntelligence;
        private System.Windows.Forms.TextBox _txtAgility;
        private System.Windows.Forms.TextBox _txtConstitution;
        private System.Windows.Forms.TextBox _txtCharisma;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}