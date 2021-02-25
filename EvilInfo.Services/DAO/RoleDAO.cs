using EvilInfo.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
            if (context == null) throw new ArgumentNullException("context");

            this.context = context;
        }
    }
}
