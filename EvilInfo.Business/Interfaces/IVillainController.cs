using EvilInfo.Models.ViewModels;

namespace EvilInfo.Business.Interfaces
{
	public interface IVillainController
	{
		int AddJobApplication(string description, int userId);
		System.Collections.Generic.List<JobOfferViewModel> GetAllJobApplicationsInfoByUserId(int userId);
		RegistrationViewModel GetVillain(int id);
		int HireApplicant(int applicantId, int employeerId, int jobId);
	}
}