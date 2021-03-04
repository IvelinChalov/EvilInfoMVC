using EvilInfo.Services.DAO;
using EvilInfo.Services.Models;

namespace EvilInfo.Presenter.Test.Dummies
{
	class HomeDAODummy : IHomeDAO
	{
		private string username = "testUser";
		private string password = "1234";
		public Users LogIn(string username, string password)
		{
			if (this.username.Equals(username) && this.password.Equals(password))
			{
				return CreateDummyUser();
			}

			return null;
		}

		private Users CreateDummyUser()
		{
			Users user = new Users();
			user.Role = new Roles() { Name = "Minion" };
			user.Id = 0;

			return user;
		}

		public void RegisterUser(Logins loginInfo)
		{
			throw new System.NotImplementedException();
		}

		public void RegisterVillain(VillainUsers user, Logins loginInfo)
		{
			throw new System.NotImplementedException();
		}
	}
}
