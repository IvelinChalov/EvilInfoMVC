﻿
namespace EvilInfo.Presenter
{
	partial class HomeForm
	{
		/// <summary>
		///  Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		///  Clean up any resources being used.
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
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.usernameTextBox = new System.Windows.Forms.TextBox();
			this.passwordTextBox = new System.Windows.Forms.TextBox();
			this.usernaLabel = new System.Windows.Forms.Label();
			this.passwordLabel = new System.Windows.Forms.Label();
			this.registerButton = new System.Windows.Forms.Button();
			this.loginButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// usernameTextBox
			// 
			this.usernameTextBox.Location = new System.Drawing.Point(202, 113);
			this.usernameTextBox.Name = "usernameTextBox";
			this.usernameTextBox.Size = new System.Drawing.Size(100, 23);
			this.usernameTextBox.TabIndex = 0;
			// 
			// passwordTextBox
			// 
			this.passwordTextBox.Location = new System.Drawing.Point(202, 158);
			this.passwordTextBox.Name = "passwordTextBox";
			this.passwordTextBox.Size = new System.Drawing.Size(100, 23);
			this.passwordTextBox.TabIndex = 1;
			// 
			// usernaLabel
			// 
			this.usernaLabel.AutoSize = true;
			this.usernaLabel.Location = new System.Drawing.Point(124, 121);
			this.usernaLabel.Name = "usernaLabel";
			this.usernaLabel.Size = new System.Drawing.Size(63, 15);
			this.usernaLabel.TabIndex = 2;
			this.usernaLabel.Text = "Username:";
			// 
			// passwordLabel
			// 
			this.passwordLabel.AutoSize = true;
			this.passwordLabel.Location = new System.Drawing.Point(124, 166);
			this.passwordLabel.Name = "passwordLabel";
			this.passwordLabel.Size = new System.Drawing.Size(60, 15);
			this.passwordLabel.TabIndex = 3;
			this.passwordLabel.Text = "password:";
			// 
			// registerButton
			// 
			this.registerButton.Location = new System.Drawing.Point(146, 198);
			this.registerButton.Name = "registerButton";
			this.registerButton.Size = new System.Drawing.Size(75, 23);
			this.registerButton.TabIndex = 4;
			this.registerButton.Text = "Register";
			this.registerButton.UseVisualStyleBackColor = true;
			this.registerButton.Click += new System.EventHandler(this.registerButton_Click);
			// 
			// loginButton
			// 
			this.loginButton.Location = new System.Drawing.Point(227, 198);
			this.loginButton.Name = "loginButton";
			this.loginButton.Size = new System.Drawing.Size(75, 23);
			this.loginButton.TabIndex = 5;
			this.loginButton.Text = "Login";
			this.loginButton.UseVisualStyleBackColor = true;
			this.loginButton.Click += new System.EventHandler(this.loginButton_Click);
			// 
			// HomeForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(446, 269);
			this.Controls.Add(this.loginButton);
			this.Controls.Add(this.registerButton);
			this.Controls.Add(this.passwordLabel);
			this.Controls.Add(this.usernaLabel);
			this.Controls.Add(this.passwordTextBox);
			this.Controls.Add(this.usernameTextBox);
			this.Name = "HomeForm";
			this.Text = "Form1";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox usernameTextBox;
		private System.Windows.Forms.TextBox passwordTextBox;
		private System.Windows.Forms.Label usernaLabel;
		private System.Windows.Forms.Label passwordLabel;
		private System.Windows.Forms.Button registerButton;
		private System.Windows.Forms.Button loginButton;
	}
}
