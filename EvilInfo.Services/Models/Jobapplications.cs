using System;
using System.Collections.Generic;

namespace EvilInfo.Services.Models
{
    public partial class Jobapplications
    {
        public int UserId { get; set; }
        public int JobOfferId { get; set; }

        public virtual Joboffers JobOffer { get; set; }
        public virtual Users User { get; set; }
    }
}
