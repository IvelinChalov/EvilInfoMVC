using System;
using System.Collections.Generic;

namespace EvilInfo.Services.Models
{
    public partial class EvilnessFactors
    {
        public EvilnessFactors()
        {
            VillainUsers = new HashSet<VillainUsers>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<VillainUsers> VillainUsers { get; set; }
    }
}
