using EvilInfo.Business.Controllers;
using EvilInfo.Presentation.Menus;
using EvilInfo.Services;
using EvilInfo.Services.DAO;
namespace EvilInfo
{
	class Program
	{
		static void Main(string[] args)
		{
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
