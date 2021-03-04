using EvilInfo.Presentation.Business;
using EvilInfo.Presentation.CustomExceptions;
using EvilInfo.Presentation.ViewModels;
using EvilInfo.Presenter.Test.Dummies;
using EvilInfo.Services;
using EvilInfo.Services.DAO;
using EvilInfo.Services.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Linq;

namespace EvilInfo.Presenter.Test
{
	[TestFixture]
	public class HomeControllerTest
	{
		[Test]
		public void LoginUserSuccessfully()
		{
			EvilInfoDBContext context = new EvilInfoDBContext();
			CountryDAO countryDAO = new CountryDAO(context);

			IHomeDAO homeDAO = new HomeDAODummy();

			RoleDAO role = new RoleDAO(context);
			TownDAO townDAO = new TownDAO(context);
			VillainDAO villainDAO = new VillainDAO(context);
			RoleDAO roleDAO = new RoleDAO(context);
			MinionDAO minionDAO = new MinionDAO(context);
			JobDAO jobDAO = new JobDAO(context);

			HomeController homeController = new HomeController(homeDAO, villainDAO, countryDAO, townDAO, roleDAO);

			string username = "testUser";
			string password = "1234";
			int actualUserId = 0;

			int userIdResult = homeController.Login(username, password, out _);

			Assert.That(userIdResult, Is.EqualTo(actualUserId));

		}

		[Test]
		public void LoginUserWrongeCredentialsThrowsIncorectCredetialsException()
		{
			//Arrange
			EvilInfoDBContext context = new EvilInfoDBContext();
			CountryDAO countryDAO = new CountryDAO(context);

			IHomeDAO homeDAO = new HomeDAODummy();

			RoleDAO role = new RoleDAO(context);
			TownDAO townDAO = new TownDAO(context);
			VillainDAO villainDAO = new VillainDAO(context);
			RoleDAO roleDAO = new RoleDAO(context);
			MinionDAO minionDAO = new MinionDAO(context);
			JobDAO jobDAO = new JobDAO(context);

			HomeController homeController = new HomeController(homeDAO, villainDAO, countryDAO, townDAO, roleDAO);

			string username = "wrongUsername";
			string password = "1234";

			//Act/Assert
			var exception = Assert.Throws<IncorectCredentialsException>(() => homeController.Login(username, password, out _));

			Assert.That(exception.Message, Is.EqualTo("Incorect credentials"));
		}

		[Test]
		public void RegisterMinionUserSuccessfully()
		{
			//Arrange
			EvilInfoDBContext context = new EvilInfoDBContext();
			CountryDAO countryDAO = new CountryDAO(context);
			HomeDAO homeDAO = new HomeDAO(context);
			RoleDAO role = new RoleDAO(context);
			TownDAO townDAO = new TownDAO(context);
			VillainDAO villainDAO = new VillainDAO(context);
			RoleDAO roleDAO = new RoleDAO(context);
			MinionDAO minionDAO = new MinionDAO(context);
			JobDAO jobDAO = new JobDAO(context);

			HomeController homeController = new HomeController(homeDAO, villainDAO, countryDAO, townDAO, roleDAO);

			RegistrationViewModel registrationViewModel = new RegistrationViewModel();
			registrationViewModel.FirstName = "Ivan";
			registrationViewModel.LastName = "Ivanov";
			registrationViewModel.RoleName = "Minion";
			registrationViewModel.CountryName = "Bulgaria";
			registrationViewModel.TownName = "Ruse";
			registrationViewModel.Username = "TestUsername";
			registrationViewModel.Password = "testPassword";

			homeController.Register(registrationViewModel);

			Logins loginUser = context.Logins
								.Include(l => l.Users)
								.Where(l => l.Username.Equals(registrationViewModel.Username) &&
											l.Password.Equals(registrationViewModel.Password))
								?.FirstOrDefault();
			Assert.That(registrationViewModel.Username, Is.EqualTo(loginUser.Username));

			context.Users.Remove(loginUser.Users);
			context.Logins.Remove(loginUser);
			context.SaveChanges();
		}
	}
}
