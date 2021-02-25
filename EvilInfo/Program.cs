using EvilInfo.Business;
using EvilInfo.Presentation.Menus;
using EvilInfo.Services;
using EvilInfo.Services.DAO;
using System;

namespace EvilInfo
{
    [System.Runtime.InteropServices.Guid("E4F7C2AA-0660-4562-8E07-C67F8E08DD6F")]
    class Program
    {
        static void Main(string[] args)
        {
			for (int i = 0; i < 10; i++)
			{
				Console.WriteLine("ddf");
			}


            EvilInfoDBContext context = new EvilInfoDBContext();
            CountryDAO countryDAO = new CountryDAO(context);
            HomeDAO homeDAO = new HomeDAO(context);
            RoleDAO role = new RoleDAO(context); 
            TownDAO townDAO = new TownDAO(context);
            VillainDAO villainDAO = new VillainDAO(context);
            RoleDAO roleDAO = new RoleDAO(context);
            MinionDAO minionDAO = new MinionDAO(context);
            JobDAO jobDAO = new JobDAO(context);

            HomeController homeController = new HomeController(homeDAO, villainDAO, countryDAO, townDAO, roleDAO);
            MinionController minionController = new MinionController(minionDAO, townDAO);
            VillainController villainController = new VillainController(villainDAO, jobDAO);

            HomeMenu homeMenu = new HomeMenu(homeController, minionController, villainController);
        }
    }
}
