using EvilInfo.Services.DAO;
using EvilInfo.Services.Models;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace EvilInfo.Presenter
{
	public partial class RegisterForm : Form
	{
		public RegisterForm(IHomeDAO homeDAO, ICountryDAO countryDAO, ITownDAO townDAO, IRoleDAO roleDAO, IVillainDAO villainDAO, HomeForm homeForm)
		{
			this.homeDAO = homeDAO;
			this.countryDAO = countryDAO;
			this.townDAO = townDAO;
			this.roleDAO = roleDAO;
			this.villainDAO = villainDAO;
			this.homeForm = homeForm;

			InitializeComponent();
			this.errorLable.Visible = false;
		}

		private IHomeDAO homeDAO;
		private ICountryDAO countryDAO;
		private ITownDAO townDAO;
		private IRoleDAO roleDAO;
		private IVillainDAO villainDAO;
		private HomeForm homeForm;

		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			this.evilnessFactorTextBox.Visible = !this.evilnessFactorTextBox.Visible;
			this.evilnessFactorLabel.Visible = !this.evilnessFactorLabel.Visible;
		}

		private string GetSelectedRole()
		{
			if (this.villainRoleCheckBox.Checked)
			{
				return "villain";
			}
			else if (this.minionRoleCheckbox.Checked)
			{
				return "minion";
			}

			throw new Exception("Please select role");
		}

		private string HashPassword(string password)
		{
			var provider = new SHA1CryptoServiceProvider();
			var encoding = new UnicodeEncoding();
			return Convert.ToBase64String(provider.ComputeHash(encoding.GetBytes(password)));
		}

		private void RegisterButton_Click(object sender, EventArgs e)
		{
			try
			{
				if (!IsSame(this.passwordTextBox.Text, this.repeatPasswordTextBox.Text)) throw new Exception("Password mismatch");

				Users users = new Users();
				users.FirstName = this.firstNameTextBox.Text;
				users.LastName = this.lastNameTextBox.Text;
				users.Country = this.countryDAO.GetCoutry(this.countryNameTextBox.Text);
				users.Town = this.townDAO.GetTown(this.townNameTextBox.Text);
				users.Role = this.roleDAO.GetRole(GetSelectedRole());

				Logins logins = new Logins();
				logins.Username = this.usernameTextBox.Text;
				logins.Password = this.HashPassword(this.passwordTextBox.Text);
				logins.Users = users;

				if (this.villainRoleCheckBox.Checked)
				{
					VillainUsers villainUsers = new VillainUsers();
					EvilnessFactors evilnessFactor = this.villainDAO.GetEvilnessFactor(this.evilnessFactorTextBox.Text);
					villainUsers.EvilnessFactor = evilnessFactor;
					villainUsers.User = users;

					this.homeDAO.RegisterVillain(villainUsers, logins);
				}
				else
				{
					this.homeDAO.RegisterUser(logins);
				}

				this.Close();
				this.homeForm.Show();
			}
			catch (Exception error)
			{

				this.errorLable.Visible = true;
				this.errorLable.Text = error.Message;
			}


		}

		private bool IsSame(string first, string second)
		{
			return string.Equals(first, second);
		}

		private void firstNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			var regex = new Regex(@"[^a-zA-Z\s]");
			if (regex.IsMatch(e.KeyChar.ToString()))
			{
				e.Handled = true;
			}
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
			this.homeForm.Show();
		}
	}
}
