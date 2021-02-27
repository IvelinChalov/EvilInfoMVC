using EvilInfo.Services.Models;
using System;
using System.Linq;

namespace EvilInfo.Services.DAO
{
	public class RoleDAO
	{
		public Roles GetRole(string name)
		{
			return this.context.Roles.Where(r => r.Name.Equals(name)).FirstOrDefault();
		}

		private EvilInfoDBContext context;
		public RoleDAO(EvilInfoDBContext context)
		{
			this.context = context ?? throw new ArgumentNullException("context");
		}
	}
}
