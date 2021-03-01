using EvilInfo.Presentation.Business;
using EvilInfo.Presenter.Utils;
using System;
using System.Windows.Forms;

namespace EvilInfo.Presenter
{
	public partial class HomeForm : Form
	{
		public HomeForm(IHomeController homeController)
		{
			InitializeComponent();
			this.errorLabel.Visible = false;
			this.homeController = homeController;
		}

		private IHomeController homeController;

		private void loginButton_Click(object sender, EventArgs e)
		{
			try
			{
				string userRole;
				string hashedPassword = PasswordHelper.HashPassword(this.passwordTextBox.Text);

				int userId = this.homeController.Login(this.usernameTextBox.Text, hashedPassword, out userRole);

				Redirect(userId, userRole);
			}
			catch (Exception exception)
			{

				this.errorLabel.Visible = true;
				this.errorLabel.Text = exception.Message;
			}

		}

		private void Redirect(int userId, string userRole)
		{
			switch (userRole)
			{
				case "Minion":
					{
						var minionMainMenuForm = FormFactory.GetFormInstance<MinionMainMenuForm>();
						minionMainMenuForm.Show();
					}
					break;
				case "Villain":
					{
						throw new NotImplementedException();
						//MinionMainMenuForm mainMenuForm = new MinionMainMenuForm();
						//mainMenuForm.Show();
					}
					break;
				default:
					break;
			}

			this.Hide();
		}

		private void registerButton_Click(object sender, EventArgs e)
		{
			this.Hide();

			var registerForm = FormFactory.GetFormInstance<RegisterForm>();
			registerForm.Show();
		}
	}
}
