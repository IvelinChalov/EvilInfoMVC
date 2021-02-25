using System;
using System.Collections.Generic;

namespace EvilInfo.Services.Models
{
    public partial class Towns
    {
        public Towns()
        {
            Users = new HashSet<Users>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }

        public virtual Countries Country { get; set; }
        public virtual ICollection<Users> Users { get; set; }
    }
}
