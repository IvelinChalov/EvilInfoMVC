using System;
using System.Collections.Generic;

namespace EvilInfo.Services.Models
{
    public partial class VillainUsers
    {
        public VillainUsers()
        {
            VillainuserUsers = new HashSet<VillainuserUsers>();
        }

        public int UserId { get; set; }
        public int EvilnessFactorId { get; set; }

        public virtual EvilnessFactors EvilnessFactor { get; set; }
        public virtual Users User { get; set; }
        public virtual ICollection<VillainuserUsers> VillainuserUsers { get; set; }
    }
}
