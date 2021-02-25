using EvilInfo.Presentation.ViewModels;
using EvilInfo.Services.DAO;
using EvilInfo.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EvilInfo.Business
{
    class VillainController
    {
        public int AddJobApplication(string description, int userId)
        {
            return this.jobDAO.CreateJobApplication(description, userId);
        }

        public List<JobOfferViewModel> GetAllJobApplicationsInfoByUserId(int userId)
        {
            var jobOffers = this.jobDAO.GetAllJobApplicationsInfoByUserId(userId);

            return jobOffers.Select(j => new JobOfferViewModel{  JobOfferId = j.Id, JobName = j.Name, Jobapplications = j.Jobapplications.ToList() }).ToList();
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
