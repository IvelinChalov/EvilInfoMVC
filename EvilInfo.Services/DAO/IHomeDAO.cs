using EvilInfo.Services.Models;

namespace EvilInfo.Services.DAO
{
	public interface IHomeDAO
	{
		Users LogIn(string username, string password);
		void RegisterUser(Logins loginInfo);
		void RegisterVillain(VillainUsers user, Logins loginInfo);
	}
}