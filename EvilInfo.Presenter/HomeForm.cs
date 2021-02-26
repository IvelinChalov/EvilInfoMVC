using EvilInfo.Services;
using EvilInfo.Services.DAO;
using EvilInfo.Services.Models;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;

namespace EvilInfo.Presenter
{
	public partial class HomeForm : Form
	{
		public HomeForm(HomeDAO homeDAO, EvilInfoDBContext evilInfoDBContext)
		{
			InitializeComponent();
			this.homeDAO = homeDAO;
			this.evilInfoDBContext = evilInfoDBContext;
		}

		private EvilInfoDBContext evilInfoDBContext;
		private HomeDAO homeDAO;

		private void loginButton_Click(object sender, EventArgs e)
		{
			string username = usernameTextBox.Text;
			string password = passwordTextBox.Text;

			Users user = this.homeDAO.LogIn(username, HashPassword(password));
			//Users user = this.homeDAO.LogIn(username, password);

			string userRole = user.Role.Name;
			int userId = user.Id;

			Redirect(userId, userRole);

		}

		private void Redirect(int userId, string userRole)
		{
			switch (userRole)
			{
				case "Minion":
					{

						MinionMainMenuForm minionMainMenuForm = new MinionMainMenuForm();
						minionMainMenuForm.Show();
					}
					break;
				case "Villain":
					{
						MinionMainMenuForm mainMenuForm = new MinionMainMenuForm();
						mainMenuForm.Show();
					}
					break;
				default:
					break;
			}

			this.Hide();
		}

		private string HashPassword(string password)
		{
			var provider = new SHA1CryptoServiceProvider();
			var encoding = new UnicodeEncoding();
			return Convert.ToBase64String(provider.ComputeHash(encoding.GetBytes(password)));
		}


		private void registerButton_Click(object sender, EventArgs e)
		{
			this.Hide();
			RegisterForm registerForm = new RegisterForm(homeDAO, new CountryDAO(evilInfoDBContext), new TownDAO(evilInfoDBContext),
															new RoleDAO(evilInfoDBContext), new VillainDAO(evilInfoDBContext), this);
			registerForm.Show();
		}
	}
}
