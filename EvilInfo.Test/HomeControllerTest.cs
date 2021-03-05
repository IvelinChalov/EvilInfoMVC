using EvilInfo.Business;
using EvilInfo.CustomExceptions;
using EvilInfo.Services;
using EvilInfo.Services.DAO;
using NUnit.Framework;
using System;
using System.Security.Cryptography;
using System.Text;

namespace EvilInfo.Test
{
	[TestFixture]
	public class HomeControllerTest
	{
		[Test]
		public void UserSuccessfullyLogged()
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
			string username = "minion";
			string password = HashPassword("1234");
			string userRole = string.Empty;

			//Act
			int actualUserId = 8;
			int result = homeController.Login(username, password, out userRole);
			//Assert
			Assert.That(result, Is.EqualTo(actualUserId));
		}

		[Test]
		public void UserUsesWrongeCredentialsReturnsIncorectCredentialsException()
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
			string username = "notExistingUsername";
			string password = HashPassword("1234");
			string userRole = string.Empty;

			var exception = Assert.Throws<IncorectCredentialsException>(() => homeController.Login(username, password, out userRole));
			//Assert.AreEqual("Incorect credentials", exception.Message);
			// or:
			Assert.That(exception.Message, Is.EqualTo("Incorect credentials"));
		}

		private string HashPassword(string password)
		{
			var provider = new SHA1CryptoServiceProvider();
			var encoding = new UnicodeEncoding();
			return Convert.ToBase64String(provider.ComputeHash(encoding.GetBytes(password)));
		}
	}
}
