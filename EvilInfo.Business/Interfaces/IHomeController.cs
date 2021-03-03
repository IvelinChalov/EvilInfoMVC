using EvilInfo.Models.ViewModels;

namespace EvilInfo.Business.Interfaces
{
	public interface IHomeController
	{
		int Login(string username, string password, out string userRole);
		void Register(RegistrationViewModel registrationViewModel);
	}
}