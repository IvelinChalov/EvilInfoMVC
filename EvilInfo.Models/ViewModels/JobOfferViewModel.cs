using System.Collections.Generic;

namespace EvilInfo.Models.ViewModels
{
	public class JobOfferViewModel
	{
		public int JobOfferId { get; set; }
		public string JobName { get; set; }
		public List<JobApplicantViewModel> Jobapplications { get; set; }
	}
}
