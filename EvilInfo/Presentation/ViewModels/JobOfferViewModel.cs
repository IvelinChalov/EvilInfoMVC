using EvilInfo.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace EvilInfo.Presentation.ViewModels
{
    public class JobOfferViewModel
    {
        public int JobOfferId { get; set; }
        public string JobName { get; set; }
        public List<Jobapplications> Jobapplications { get; set; }
    }
}
