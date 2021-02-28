using EvilInfo.Presentation.CustomExceptions;
using EvilInfo.Presentation.ViewModels;
using EvilInfo.Services.DAO;
using EvilInfo.Services.Models;

namespace EvilInfo.Presentation.Business
{
	public class HomeController : IHomeController
	{
		/// <summary>
		/// Used to log in users in to the program
		/// </summary>
		/// <param name="username">The username</param>
		/// <param name="password">The password</param>
		/// <param name="userRole">The role of the logged user</param>
		/// <returns></returns>
		public int Login(string username, string password, out string userRole)
		{
			Users user = this.homeDAO.LogIn(username, password);
			if (user == null)
				throw new IncorectCredentialsException("Incorect credentials");

			userRole = user.Role.Name;
			return user.Id;
		}

		public void Register(RegistrationViewModel registrationViewModel)
		{
			Users user = new Users();
			user.FirstName = registrationViewModel.FirstName;
			user.LastName = registrationViewModel.LastName;
			user.Country = this.countryDAO.GetCoutry(registrationViewModel.CountryName);
			user.Town = this.townDAO.GetTown(registrationViewModel.TownName);
			user.Role = this.roleDAO.GetRole(registrationViewModel.RoleName);

			Logins loginInfo = new Logins();
			loginInfo.Username = registrationViewModel.Username;
			loginInfo.Password = registrationViewModel.Password;
			loginInfo.Users = user;

			if (registrationViewModel.EvilnessFactor != null)
			{
				VillainUsers villainUsers = new VillainUsers();
				EvilnessFactors evilnessFactor = this.villainDAO.GetEvilnessFactor(registrationViewModel.EvilnessFactor);
				villainUsers.EvilnessFactor = evilnessFactor;
				villainUsers.User = user;

				this.homeDAO.RegisterVillain(villainUsers, loginInfo);
			}
			else
			{
				this.homeDAO.RegisterUser(loginInfo);
			}
		}

		private IHomeDAO homeDAO = null;
		private IVillainDAO villainDAO = null;
		private ICountryDAO countryDAO = null;
		private ITownDAO townDAO = null;
		private IRoleDAO roleDAO = null;
		public HomeController(IHomeDAO homeDAO, IVillainDAO villainDAO, ICountryDAO countryDAO, ITownDAO townDAO, IRoleDAO roleDAO)
		{
			this.homeDAO = homeDAO;
			this.villainDAO = villainDAO;
			this.countryDAO = countryDAO;
			this.townDAO = townDAO;
			this.roleDAO = roleDAO;
		}
	}
}
