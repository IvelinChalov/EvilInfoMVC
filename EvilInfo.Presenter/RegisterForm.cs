using EvilInfo.Presentation.Business;
using EvilInfo.Presentation.Utils;
using EvilInfo.Presentation.ViewModels;
using EvilInfo.Presenter.Utils;
using System;
using System.Windows.Forms;

namespace EvilInfo.Presenter
{
	public partial class RegisterForm : Form
	{
		public RegisterForm(IHomeController homeController)
		{
			this.homeController = homeController;

			InitializeComponent();
			this.errorLable.Visible = false;
		}

		private IHomeController homeController;

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

		private void RegisterButton_Click(object sender, EventArgs e)
		{
			try
			{

				if (!PasswordHelper.IsSame(this.passwordTextBox.Text, this.repeatPasswordTextBox.Text)) throw new Exception("Password mismatch");

				RegistrationViewModel registrationViewModel = new RegistrationViewModel();

				registrationViewModel.FirstName = this.firstNameTextBox.Text;
				registrationViewModel.LastName = this.lastNameTextBox.Text;
				registrationViewModel.CountryName = this.countryNameTextBox.Text;
				registrationViewModel.TownName = this.townNameTextBox.Text;
				registrationViewModel.RoleName = GetSelectedRole();

				registrationViewModel.Username = this.usernameTextBox.Text;
				registrationViewModel.Password = PasswordHelper.HashPassword(this.passwordTextBox.Text);

				if (this.villainRoleCheckBox.Checked)
				{
					registrationViewModel.EvilnessFactor = this.evilnessFactorTextBox.Text;
				}

				this.homeController.Register(registrationViewModel);
				this.Close();
				var homeForm = FormFactory.GetFormInstance<HomeForm>();
				homeForm.Show();
			}
			catch (Exception error)
			{

				this.errorLable.Visible = true;
				this.errorLable.Text = error.Message;
			}


		}

		private void firstNameTextBox_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (ValidatorHelper.IsStrigValid(e.KeyChar.ToString()))
			{
				e.Handled = true;
			}
		}

		private void cancelButton_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void RegisterForm_FormClosed(object sender, FormClosedEventArgs e)
		{

			var homeForm = FormFactory.GetFormInstance<HomeForm>();
			homeForm.Show();
		}
	}
}
