using System;
using System.Collections.Generic;
using System.Text;

namespace EvilInfo.Presentation.ViewModels
{
    public class RegistrationViewModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CountryName { get; set; }
        public string TownName { get; set; }
        public string RoleName { get; set; }
        public string EvilnessFactor { get; set; }
    }
}
