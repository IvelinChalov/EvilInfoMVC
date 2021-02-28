using EvilInfo.Presentation.ViewModels;

namespace EvilInfo.Presentation.Business
{
	public interface IHomeController
	{
		int Login(string username, string password, out string userRole);
		void Register(RegistrationViewModel registrationViewModel);
	}
}