using EvilInfo.Business.Interfaces;
using EvilInfo.Models.ViewModels;
using EvilInfo.Services.DAO;
using EvilInfo.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace EvilInfo.Business.Controllers
{
	public class VillainController : IVillainController
	{
		public int AddJobApplication(string description, int userId)
		{
			return this.jobDAO.CreateJobApplication(description, userId);
		}

		public List<JobOfferViewModel> GetAllJobApplicationsInfoByUserId(int userId)
		{
			var jobOffers = this.jobDAO.GetAllJobApplicationsInfoByUserId(userId);

			return jobOffers.Select(j => new JobOfferViewModel { JobOfferId = j.Id, JobName = j.Name, Jobapplications = JobOfferMapper(j.Jobapplications.ToList()) }).ToList();
		}

		private List<JobApplicantViewModel> JobOfferMapper(List<Jobapplications> jobapplications)
		{
			List<JobApplicantViewModel> jobApplicants = new List<JobApplicantViewModel>();
			foreach (var jobapplication in jobapplications)
			{
				JobApplicantViewModel jobApplicantViewModel = new JobApplicantViewModel();
				jobApplicantViewModel.Id = jobapplication.UserId;
				jobApplicantViewModel.FirstName = jobapplication.User.FirstName;
				jobApplicantViewModel.LastName = jobapplication.User.LastName;
				jobApplicants.Add(jobApplicantViewModel);
			}

			return jobApplicants;
		}

		public int HireApplicant(int applicantId, int employeerId, int jobId)
		{
			return this.jobDAO.HireApplicant(applicantId, employeerId, jobId);
		}

		public RegistrationViewModel GetVillain(int id)
		{
			VillainUsers villain = this.villainDAO.GetVillainById(id); ;
			RegistrationViewModel registrationViewModel = new RegistrationViewModel
			{
				FirstName = villain.User.FirstName,
				LastName = villain.User.LastName,
				TownName = villain.User.Town.Name,
				CountryName = villain.User.Country.Name,
				EvilnessFactor = villain.EvilnessFactor.Name
			};

			return registrationViewModel;
		}

		//public int UpdateVillain(int id, string firstName, string lastName, string townName, string countryName, string evilnessFactor)
		//{
		//    Town t = new Town(0, townName, new Country(0, countryName));
		//    Villain v = new Villain(id, firstName, lastName, t, "", evilnessFactor);

		//    return villainDAO.UpdateVillainData(v);
		//}

		private readonly VillainDAO villainDAO;
		private readonly JobDAO jobDAO;
		public VillainController(VillainDAO villainDAO, JobDAO jobDAO)
		{
			this.villainDAO = villainDAO;
			this.jobDAO = jobDAO;
		}
	}
}
