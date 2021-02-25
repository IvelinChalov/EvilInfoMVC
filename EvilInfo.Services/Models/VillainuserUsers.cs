using System;
using System.Collections.Generic;

namespace EvilInfo.Services.Models
{
    public partial class VillainuserUsers
    {
        public int MinionId { get; set; }
        public int VillainId { get; set; }

        public virtual Users Minion { get; set; }
        public virtual VillainUsers Villain { get; set; }
    }
}
