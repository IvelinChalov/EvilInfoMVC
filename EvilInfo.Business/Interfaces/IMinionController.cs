using EvilInfo.Models.ViewModels;

namespace EvilInfo.Business.Interfaces
{
	public interface IMinionController
	{
		RegistrationViewModel GetMinionById(int id);
	}
}