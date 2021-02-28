using Autofac;
using System;

namespace EvilInfo.Presenter.Utils
{
	class FormFactory
	{

		public static ILifetimeScope _scope;

		public static T GetFormInstance<T>()
		{
			return _scope is null ? throw new ArgumentException("scope") : _scope.Resolve<T>();
		}
	}
}
