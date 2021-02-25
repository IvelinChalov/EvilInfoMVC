using EvilInfo.Business;
using EvilInfo.Presentation.Utils;
using EvilInfo.Presentation.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvilInfo.Presentation.Menus
{
    class MinionMenu
    {
        private const float CloseCommand = 6;
        private MinionController minionController;
        private int userId;

        public MinionMenu(MinionController minionController, int userId)
        {
            this.minionController = minionController;
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
                        ShowMinionData();
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Not inplemented");
                        //UpdateMinionData();
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Not inplemented");
                        //ShowJobApplications();
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Not inplemented");
                        //JobApplication();
                        break;
                    case 5:
                        Console.Clear();
                        return;
                    case 6:
                        Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            } while (operation != CloseCommand);
        }

        //private void ShowJobApplications()
        //{
        //    List<JobApplication> jobs = this.minionController.GetAllJobs();

        //    Console.WriteLine(new string(' ', 10) + "All available jobs" + new string(' ', 18));
        //    foreach (var job in jobs)
        //    {
        //        Console.WriteLine("Job id: {0}", job.Id);
        //        Console.WriteLine("Job description: {0}", job.Description);
        //        Console.WriteLine("Job creator id: {0}", job.UserId);
        //        Console.WriteLine("Job creator: {0} ", job.JobCreatorName);
        //        Console.WriteLine();
        //    }

        //    Console.Write("Press eny key to return to menu");
        //    Console.ReadLine();
        //}

        public void ShowMenu()
        {
            Console.Clear();
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 10) + "Minion Information" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));

            Console.WriteLine("1 Show personal data");
            Console.WriteLine("2 Edit personal data");
            Console.WriteLine("3 Show job applications");
            Console.WriteLine("4 Job application");
            Console.WriteLine("5 Back to main menu");
            Console.WriteLine("6. Exit");
        }

        private void ShowMinionData()
        {
            RegistrationViewModel minionInfo = minionController.GetMinionById(this.userId);
            Console.WriteLine(new string(' ', 10) + "Personal information" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("First name: {0}", minionInfo.FirstName);
            Console.WriteLine("Last name: {0}", minionInfo.LastName);
            Console.WriteLine("Town name: {0}", minionInfo.TownName);
            Console.WriteLine("Country name: {0}", minionInfo.CountryName);
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("Press any key to return...");
            Console.ReadLine();
        }

        //private void UpdateMinionData()
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

        //    int result = minionController.UpdateMinion(this.userId, minionFirstName, minionLastName, townName, countryName);
        //    if (result > 0)
        //    {
        //        Console.WriteLine("Minion data updated!");
        //        Console.WriteLine("Press any key to return...");
        //        Console.ReadLine();
        //    }
        //}

        //private void JobApplication()
        //{
        //    Console.Write("Enter the id of the job to apply for: ");
        //    int jobId = int.Parse(Console.ReadLine());
        //    Console.Write("Enter the id of the villain to apply for: ");
        //    int villainId = int.Parse(Console.ReadLine());

        //    int result = this.minionController.JobApplication(jobId, villainId);
        //    if (result > 0)
        //    {
        //        Console.WriteLine("Successfully apply for the job!");
        //        Console.WriteLine("Press any key to continue.");
        //        Console.ReadLine();
        //    }
        //}
    }
}
