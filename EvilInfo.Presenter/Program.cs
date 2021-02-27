using Autofac;
using EvilInfo.Presenter.Autofac;
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
			var container = ContainerConfig.Configure();

			using (var scope = container.BeginLifetimeScope())
			{
				Application.SetHighDpiMode(HighDpiMode.SystemAware);
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);

				var homeForm = scope.Resolve<HomeForm>();
				Application.Run(homeForm);

			}
		}
	}
}
