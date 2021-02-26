using EvilInfo.Services;
using EvilInfo.Services.DAO;
using System;
using System.Windows.Forms;

namespace EvilInfo.Presenter
{
	static class Program
	{
		/// <summary>
		///  The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			EvilInfoDBContext context = new EvilInfoDBContext();
			HomeDAO homeDAO = new HomeDAO(context);


			Application.SetHighDpiMode(HighDpiMode.SystemAware);
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new HomeForm(homeDAO, context));
		}
	}
}
