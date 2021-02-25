using System;
using System.Collections.Generic;

namespace EvilInfo.Services.Models
{
    public partial class Users
    {
        public Users()
        {
            Jobapplications = new HashSet<Jobapplications>();
            Joboffers = new HashSet<Joboffers>();
            VillainuserUsers = new HashSet<VillainuserUsers>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int RoleId { get; set; }
        public int CountryId { get; set; }
        public int TownId { get; set; }

        public virtual Countries Country { get; set; }
        public virtual Logins IdNavigation { get; set; }
        public virtual Roles Role { get; set; }
        public virtual Towns Town { get; set; }
        public virtual VillainUsers VillainUsers { get; set; }
        public virtual ICollection<Jobapplications> Jobapplications { get; set; }
        public virtual ICollection<Joboffers> Joboffers { get; set; }
        public virtual ICollection<VillainuserUsers> VillainuserUsers { get; set; }
    }
}
