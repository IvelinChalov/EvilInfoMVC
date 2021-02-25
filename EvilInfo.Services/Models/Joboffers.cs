using System;
using System.Collections.Generic;

namespace EvilInfo.Services.Models
{
    public partial class Joboffers
    {
        public Joboffers()
        {
            Jobapplications = new HashSet<Jobapplications>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public bool JobOfferStatus { get; set; }

        public virtual Users User { get; set; }
        public virtual ICollection<Jobapplications> Jobapplications { get; set; }
    }
}
