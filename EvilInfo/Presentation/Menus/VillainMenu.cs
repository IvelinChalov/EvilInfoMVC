using EvilInfo.Business.Controllers;
using EvilInfo.Models.ViewModels;
using EvilInfo.Presentation.Utils;
using System;
using System.Collections.Generic;

namespace EvilInfo.Presentation.Menus
{
	class VillainMenu
	{
		private const float CloseCommand = 6;
		private VillainController villainController;
		private int userId;

		public void Input()
		{
			int operation = -1;
			do
			{
				ShowMenu();
				if (!int.TryParse(Console.ReadLine(), out operation)) throw new FormatException("Value must be integer nuber!");
				switch (operation)
				{
					case 1:
						Console.Clear();
						ShowVillainData();
						break;
					case 2:
						Console.Clear();
						Console.WriteLine("Not inplemented");
						// UpdateVillainData();
						break;
					case 3:
						Console.Clear();
						CreateJobOffer();
						break;
					case 4:
						Console.Clear();
						ShowAllJobApplicants();
						break;
					case 5:
						Console.Clear();
						HireApplicant();
						return;
					case 6:
						Environment.Exit(0);
						break;
					default:
						break;
				}
			} while (operation != CloseCommand);
		}

		private void ShowVillainData()
		{
			RegistrationViewModel villain = villainController.GetVillain(userId);
			Console.WriteLine(new string(' ', 10) + "Personal information" + new string(' ', 18));
			Console.WriteLine(new string('-', 40));
			Console.WriteLine("First name: {0}", villain.FirstName);
			Console.WriteLine("Last name: {0}", villain.LastName);
			Console.WriteLine("Town name: {0}", villain.TownName);
			Console.WriteLine("Country name: {0}", villain.CountryName);
			Console.WriteLine("Evilness factor: {0}", villain.EvilnessFactor);
			Console.WriteLine(new string('-', 40));
			Console.Write("Press any key to return...");
			Console.ReadLine();
		}

		//private void UpdateVillainData()
		//{
		//    Console.Write("Enter new name: ");
		//    string minionFirstName = Console.ReadLine();
		//    if (!Validator.IsStrigValid(minionFirstName)) throw new FormatException("Invalid charecter for minion name");

		//    Console.Write("Enter new Last name: ");
		//    string minionLastName = Console.ReadLine();
		//    if (!Validator.IsStrigValid(minionFirstName)) throw new FormatException("Invalid charecter for minion Last name");

		//    Console.Write("Enter town name: ");
		//    string townName = Console.ReadLine();
		//    if (!Validator.IsStrigValid(townName)) throw new FormatException("Invalid charecter for town name");

		//    Console.Write("Enter country name: ");
		//    string countryName = Console.ReadLine();
		//    if (!Validator.IsStrigValid(countryName)) throw new FormatException("Invalid charecter for town name");

		//    Console.Write("Enter evilness factor: ");
		//    string evilnessFctor = Console.ReadLine();
		//    if (!Validator.IsStrigValid(countryName)) throw new FormatException("Invalid charecter for town name");

		//    int result = villainController.UpdateVillain(this.userId, minionFirstName, minionLastName, townName, countryName, evilnessFctor);
		//    if (result > 0) Console.WriteLine("Villain data updated!");
		//}

		private void HireApplicant()
		{
			Console.Write("Id of the applicant: ");
			int applicantId = int.Parse(Console.ReadLine());

			Console.Write("Id of the job: ");
			int jobId = int.Parse(Console.ReadLine());

			int result = this.villainController.HireApplicant(applicantId, this.userId, jobId);
			if (result > 1)
			{
				Console.WriteLine("Applicant hired successfully");
			}
		}

		private void CreateJobOffer()
		{
			Console.Clear();
			Console.Write("Job description: ");
			string jobDescription = Console.ReadLine();
			Validator.IsStrigValid(jobDescription);

			int result = this.villainController.AddJobApplication(jobDescription, this.userId);
			if (result > 1)
			{
				Console.WriteLine("Job added successfully");
				Console.Write("Press any key to continue");
				Console.ReadLine();
			}

		}

		private void ShowAllJobApplicants()
		{
			Console.Clear();
			List<JobOfferViewModel> jobs = this.villainController.GetAllJobApplicationsInfoByUserId(this.userId);

			foreach (var job in jobs)
			{
				Console.WriteLine("JobID: {0}", job.JobOfferId);
				Console.WriteLine("Job titile: {0}", job.JobName);
				foreach (var application in job.Jobapplications)
				{
					foreach (var ja in job.Jobapplications)
						Console.WriteLine($"Job applicant name {ja.FirstName} {ja.LastName} with id: {ja.Id}");
				}

				Console.WriteLine();
			}

			Console.Write("Press any key to continue...");
			Console.ReadLine();
		}

		public void ShowMenu()
		{
			Console.Clear();
			Console.WriteLine(new string('-', 40));
			Console.WriteLine(new string(' ', 10) + "Villain Information" + new string(' ', 18));
			Console.WriteLine(new string('-', 40));

			Console.WriteLine("1 Show personal data");
			Console.WriteLine("2 Edit personal data");
			Console.WriteLine("3 Create job offer");
			Console.WriteLine("4 Show job applicants");
			Console.WriteLine("5 Hire applicants");
			Console.WriteLine("6. Exit");
		}

		public VillainMenu(VillainController villainController, int userId)
		{
			this.villainController = villainController;
			this.userId = userId;
			try
			{
				Input();
			}
			catch (FormatException e)
			{

				Console.WriteLine(e.Message);
			}
			catch (Exception e)
			{

				Console.WriteLine(e.Message);
			}
			finally
			{
				Console.Write("Press eny key to return to main menu");
				Console.ReadLine();
				Input();
			}
		}
	}
}
