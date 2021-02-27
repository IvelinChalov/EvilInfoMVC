using EvilInfo.Business;
using EvilInfo.CustomExceptions;
using EvilInfo.Presentation.Utils;
using EvilInfo.Presentation.ViewModels;
using System;
using System.Security.Cryptography;
using System.Text;

namespace EvilInfo.Presentation.Menus
{
	class HomeMenu
	{
		private readonly float CloseCommand = 3;
		private HomeController homeController;
		private MinionController minionController;
		private VillainController villainController;

		public void Input()
		{
			int operation = -1;
			do
			{
				ShowMenu();
				if (!int.TryParse(Console.ReadLine(), out operation)) throw new FormatException("Value must be integer nuber!");
				switch (operation)
				{
					case 1:
						Console.Clear();
						LoginUser();
						break;
					case 2:
						RegisterUser();
						break;
					default:
						break;
				}
			} while (operation != CloseCommand);
		}

		private void RegisterUser()
		{
			RegistrationViewModel registrationViewModel = new RegistrationViewModel();

			Console.Write("Username: ");
			string username = Console.ReadLine();
			Console.Write("Password: ");
			string password = Console.ReadLine();
			Console.Write("Repeat password: ");
			string repPasswod = Console.ReadLine();
			if (!IsSame(password, repPasswod)) throw new Exception("Password mismatch");

			Console.Write("First name: ");
			string firstName = Console.ReadLine();
			if (!Validator.IsStrigValid(firstName)) throw new FormatException("Invalid charecter for first name");
			Console.Write("Last name: ");
			string lastName = Console.ReadLine();
			if (!Validator.IsStrigValid(lastName)) throw new FormatException("Invalid charecter for last name");
			Console.Write("Country name: ");
			string countryName = Console.ReadLine();
			if (!Validator.IsStrigValid(countryName)) throw new FormatException("Invalid charecter for country name");
			Console.Write("Town name: ");
			string townName = Console.ReadLine();
			if (!Validator.IsStrigValid(townName)) throw new FormatException("Invalid charecter for town name");
			Console.Write("Role name: ");
			string roleName = Console.ReadLine();
			if (!Validator.IsStrigValid(roleName)) throw new FormatException("Invalid charecter for role name");

			registrationViewModel.FirstName = firstName;
			registrationViewModel.LastName = lastName;
			registrationViewModel.TownName = townName;
			registrationViewModel.CountryName = countryName;
			registrationViewModel.Username = username;
			registrationViewModel.Password = HashPassword(password);
			registrationViewModel.RoleName = roleName;

			if (roleName.ToLower().Equals("villain"))
			{
				Console.Write("Evilness factor:");
				registrationViewModel.EvilnessFactor = Console.ReadLine();
				if (!Validator.IsStrigValid(registrationViewModel.EvilnessFactor)) throw new FormatException("Invalid  evilnessFactor");
			}

			this.homeController.Register(registrationViewModel);
		}

		private string HashPassword(string password)
		{
			var provider = new SHA1CryptoServiceProvider();
			var encoding = new UnicodeEncoding();
			return Convert.ToBase64String(provider.ComputeHash(encoding.GetBytes(password)));
		}

		private bool IsSame(string first, string second)
		{
			return string.Equals(first, second);
		}

		private void Redirect(int userId, string userRole)
		{
			switch (userRole)
			{
				case "Minion":
					{
						MinionMenu m = new MinionMenu(this.minionController, userId);
					}
					break;
				case "Villain":
					{
						VillainMenu v = new VillainMenu(this.villainController, userId);
					}
					break;
				default:
					break;
			}
		}

		private void LoginUser()
		{
			Console.Write("Username: ");
			string username = Console.ReadLine();
			Console.Write("Password: ");
			string password = HashPassword(Console.ReadLine());

			string userRole;
			int userId = this.homeController.Login(username, password, out userRole);

			Redirect(userId, userRole);
		}

		public void ShowMenu()
		{
			Console.WriteLine(new string('-', 40));
			Console.WriteLine(new string(' ', 10) + "WELCOME TO EVIL.INFO" + new string(' ', 18));
			Console.WriteLine(new string('-', 40));
			Console.WriteLine("1. Login");
			Console.WriteLine("2. Register");
			Console.WriteLine("3. Exit");
		}

		public HomeMenu(HomeController homeController, MinionController minionController, VillainController villainController)
		{
			if (homeController == null) throw new ArgumentNullException("loginController");
			if (minionController == null) throw new ArgumentNullException("minionController");
			if (villainController == null) throw new ArgumentNullException("villainController");

			this.homeController = homeController;
			this.minionController = minionController;
			this.villainController = villainController;

			try
			{
				Input();
			}
			catch (IncorectCredentialsException e)
			{

				Console.WriteLine(e.Message);
			}
			catch (FormatException e)
			{

				Console.WriteLine(e.Message);
			}
			catch (Exception e)
			{

				Console.WriteLine(e.Message);
			}
			finally
			{
				Input();
			}
		}
	}
}
