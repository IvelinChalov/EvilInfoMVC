
namespace EvilInfo.Presenter
{
	partial class RegisterForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.evilnessFactorLabel = new System.Windows.Forms.Label();
			this.usernameTextBox = new System.Windows.Forms.TextBox();
			this.passwordTextBox = new System.Windows.Forms.TextBox();
			this.repeatPasswordTextBox = new System.Windows.Forms.TextBox();
			this.firstNameTextBox = new System.Windows.Forms.TextBox();
			this.lastNameTextBox = new System.Windows.Forms.TextBox();
			this.countryNameTextBox = new System.Windows.Forms.TextBox();
			this.townNameTextBox = new System.Windows.Forms.TextBox();
			this.evilnessFactorTextBox = new System.Windows.Forms.TextBox();
			this.RegisterButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.villainRoleCheckBox = new System.Windows.Forms.CheckBox();
			this.minionRoleCheckbox = new System.Windows.Forms.CheckBox();
			this.errorLable = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(105, 35);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(63, 15);
			this.label1.TabIndex = 0;
			this.label1.Text = "Username:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(110, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(60, 15);
			this.label2.TabIndex = 1;
			this.label2.Text = "Password:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(71, 101);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(99, 15);
			this.label3.TabIndex = 2;
			this.label3.Text = "Repeat password:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(105, 143);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(65, 15);
			this.label4.TabIndex = 3;
			this.label4.Text = "First name:";
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(106, 179);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(64, 15);
			this.label5.TabIndex = 4;
			this.label5.Text = "Last name:";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(84, 206);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(86, 15);
			this.label6.TabIndex = 5;
			this.label6.Text = "Country name:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(99, 242);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(71, 15);
			this.label7.TabIndex = 6;
			this.label7.Text = "Town name:";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(137, 281);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(33, 15);
			this.label8.TabIndex = 7;
			this.label8.Text = "Role:";
			// 
			// evilnessFactorLabel
			// 
			this.evilnessFactorLabel.AutoSize = true;
			this.evilnessFactorLabel.Location = new System.Drawing.Point(84, 338);
			this.evilnessFactorLabel.Name = "evilnessFactorLabel";
			this.evilnessFactorLabel.Size = new System.Drawing.Size(85, 15);
			this.evilnessFactorLabel.TabIndex = 8;
			this.evilnessFactorLabel.Text = "Evilness factor:";
			this.evilnessFactorLabel.Visible = false;
			// 
			// usernameTextBox
			// 
			this.usernameTextBox.Location = new System.Drawing.Point(185, 35);
			this.usernameTextBox.Name = "usernameTextBox";
			this.usernameTextBox.Size = new System.Drawing.Size(100, 23);
			this.usernameTextBox.TabIndex = 9;
			// 
			// passwordTextBox
			// 
			this.passwordTextBox.Location = new System.Drawing.Point(185, 65);
			this.passwordTextBox.Name = "passwordTextBox";
			this.passwordTextBox.Size = new System.Drawing.Size(100, 23);
			this.passwordTextBox.TabIndex = 10;
			// 
			// repeatPasswordTextBox
			// 
			this.repeatPasswordTextBox.Location = new System.Drawing.Point(185, 101);
			this.repeatPasswordTextBox.Name = "repeatPasswordTextBox";
			this.repeatPasswordTextBox.Size = new System.Drawing.Size(100, 23);
			this.repeatPasswordTextBox.TabIndex = 11;
			// 
			// firstNameTextBox
			// 
			this.firstNameTextBox.Location = new System.Drawing.Point(185, 134);
			this.firstNameTextBox.Name = "firstNameTextBox";
			this.firstNameTextBox.Size = new System.Drawing.Size(100, 23);
			this.firstNameTextBox.TabIndex = 12;
			this.firstNameTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.firstNameTextBox_KeyPress);
			// 
			// lastNameTextBox
			// 
			this.lastNameTextBox.Location = new System.Drawing.Point(185, 171);
			this.lastNameTextBox.Name = "lastNameTextBox";
			this.lastNameTextBox.Size = new System.Drawing.Size(100, 23);
			this.lastNameTextBox.TabIndex = 13;
			// 
			// countryNameTextBox
			// 
			this.countryNameTextBox.Location = new System.Drawing.Point(185, 206);
			this.countryNameTextBox.Name = "countryNameTextBox";
			this.countryNameTextBox.Size = new System.Drawing.Size(100, 23);
			this.countryNameTextBox.TabIndex = 14;
			// 
			// townNameTextBox
			// 
			this.townNameTextBox.Location = new System.Drawing.Point(185, 242);
			this.townNameTextBox.Name = "townNameTextBox";
			this.townNameTextBox.Size = new System.Drawing.Size(100, 23);
			this.townNameTextBox.TabIndex = 15;
			// 
			// evilnessFactorTextBox
			// 
			this.evilnessFactorTextBox.Location = new System.Drawing.Point(185, 329);
			this.evilnessFactorTextBox.Name = "evilnessFactorTextBox";
			this.evilnessFactorTextBox.Size = new System.Drawing.Size(100, 23);
			this.evilnessFactorTextBox.TabIndex = 17;
			this.evilnessFactorTextBox.Visible = false;
			// 
			// RegisterButton
			// 
			this.RegisterButton.Location = new System.Drawing.Point(210, 376);
			this.RegisterButton.Name = "RegisterButton";
			this.RegisterButton.Size = new System.Drawing.Size(75, 23);
			this.RegisterButton.TabIndex = 18;
			this.RegisterButton.Text = "Register";
			this.RegisterButton.UseVisualStyleBackColor = true;
			this.RegisterButton.Click += new System.EventHandler(this.RegisterButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(105, 376);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.Size = new System.Drawing.Size(75, 23);
			this.cancelButton.TabIndex = 19;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.UseVisualStyleBackColor = true;
			this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
			// 
			// villainRoleCheckBox
			// 
			this.villainRoleCheckBox.AutoSize = true;
			this.villainRoleCheckBox.Location = new System.Drawing.Point(185, 281);
			this.villainRoleCheckBox.Name = "villainRoleCheckBox";
			this.villainRoleCheckBox.Size = new System.Drawing.Size(58, 19);
			this.villainRoleCheckBox.TabIndex = 20;
			this.villainRoleCheckBox.Text = "Villain";
			this.villainRoleCheckBox.UseVisualStyleBackColor = true;
			this.villainRoleCheckBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
			// 
			// minionRoleCheckbox
			// 
			this.minionRoleCheckbox.AutoSize = true;
			this.minionRoleCheckbox.Location = new System.Drawing.Point(185, 304);
			this.minionRoleCheckbox.Name = "minionRoleCheckbox";
			this.minionRoleCheckbox.Size = new System.Drawing.Size(64, 19);
			this.minionRoleCheckbox.TabIndex = 21;
			this.minionRoleCheckbox.Text = "Minion";
			this.minionRoleCheckbox.UseVisualStyleBackColor = true;
			// 
			// errorLable
			// 
			this.errorLable.AutoSize = true;
			this.errorLable.ForeColor = System.Drawing.Color.Red;
			this.errorLable.Location = new System.Drawing.Point(185, 9);
			this.errorLable.Name = "errorLable";
			this.errorLable.Size = new System.Drawing.Size(0, 15);
			this.errorLable.TabIndex = 22;
			this.errorLable.Visible = false;
			// 
			// RegisterForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(382, 411);
			this.Controls.Add(this.errorLable);
			this.Controls.Add(this.minionRoleCheckbox);
			this.Controls.Add(this.villainRoleCheckBox);
			this.Controls.Add(this.cancelButton);
			this.Controls.Add(this.RegisterButton);
			this.Controls.Add(this.evilnessFactorTextBox);
			this.Controls.Add(this.townNameTextBox);
			this.Controls.Add(this.countryNameTextBox);
			this.Controls.Add(this.lastNameTextBox);
			this.Controls.Add(this.firstNameTextBox);
			this.Controls.Add(this.repeatPasswordTextBox);
			this.Controls.Add(this.passwordTextBox);
			this.Controls.Add(this.usernameTextBox);
			this.Controls.Add(this.evilnessFactorLabel);
			this.Controls.Add(this.label8);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Name = "RegisterForm";
			this.Text = "RegisterForm";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label evilnessFactorLabel;
		private System.Windows.Forms.TextBox usernameTextBox;
		private System.Windows.Forms.TextBox passwordTextBox;
		private System.Windows.Forms.TextBox repeatPasswordTextBox;
		private System.Windows.Forms.TextBox firstNameTextBox;
		private System.Windows.Forms.TextBox lastNameTextBox;
		private System.Windows.Forms.TextBox countryNameTextBox;
		private System.Windows.Forms.TextBox townNameTextBox;
		private System.Windows.Forms.TextBox evilnessFactorTextBox;
		private System.Windows.Forms.Button RegisterButton;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.CheckBox villainRoleCheckBox;
		private System.Windows.Forms.CheckBox minionRoleCheckbox;
		private System.Windows.Forms.Button cancelButton;
		private System.Windows.Forms.Label errorLable;
	}
}