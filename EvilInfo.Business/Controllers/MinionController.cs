using EvilInfo.Business.Interfaces;
using EvilInfo.Models.ViewModels;
using EvilInfo.Services.DAO;
using EvilInfo.Services.Models;

namespace EvilInfo.Business.Controllers
{
	/// <summary>
	/// Encapsulate all the logic for <see cref="Users"/> Minions/Users
	/// </summary>
	public class MinionController : IMinionController
	{
		/// <summary>
		/// Gets user info from database
		/// </summary>
		/// <param name="id">The minion/user id</param>
		/// <returns>Object to be displayed from the user <see cref="RegistrationViewModel">Test</see> </returns>
		public RegistrationViewModel GetMinionById(int id)
		{
			Users user = minionDAO.GetMinionById(id);
			RegistrationViewModel registrationViewModel = new RegistrationViewModel();
			registrationViewModel.FirstName = user.FirstName;
			registrationViewModel.LastName = user.LastName;
			registrationViewModel.CountryName = user.Country.Name;
			registrationViewModel.TownName = user.Town.Name;

			return registrationViewModel;
		}

		//public int UpdateMinion(int id, string firstName, string lastName, string townName, string countryName)
		//{
		//    Town t = new Town(0, townName, new Country(0, countryName));
		//    User u = new User(id, firstName, lastName, t, "");

		//    return minionDAO.UpdateMinionPersonalData(u);
		//}

		//public List<JobApplication> GetAllJobs()
		//{
		//    return this.jobDAO.GetAllJobApplications();
		//}

		//public int JobApplication(int jobId, int userId)
		//{
		//    return this.jobDAO.JobApplication(jobId, userId);
		//}

		private MinionDAO minionDAO = null;
		private TownDAO townDAO = null;
		//private JobDAO jobDAO = null;
		public MinionController(MinionDAO minionDAO, TownDAO townDAO)
		{
			this.minionDAO = minionDAO;
			this.townDAO = townDAO;
			// this.jobDAO = jobDAO;
		}
	}
}
