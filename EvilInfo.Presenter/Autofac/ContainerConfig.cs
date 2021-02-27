using Autofac;
using EvilInfo.Services;
using EvilInfo.Services.DAO;

namespace EvilInfo.Presenter.Autofac
{
	public static class ContainerConfig
	{
		public static IContainer Configure()
		{
			var builder = new ContainerBuilder();

			builder.RegisterType<HomeForm>().SingleInstance();
			builder.RegisterType<RegisterForm>().SingleInstance();
			builder.RegisterType<HomeDAO>().As<IHomeDAO>();
			builder.RegisterType<VillainDAO>().As<IVillainDAO>();
			builder.RegisterType<TownDAO>().As<ITownDAO>();
			builder.RegisterType<CountryDAO>().As<ICountryDAO>();
			builder.RegisterType<RoleDAO>().As<IRoleDAO>();
			builder.RegisterInstance<EvilInfoDBContext>(new EvilInfoDBContext());

			return builder.Build();
		}
	}
}
