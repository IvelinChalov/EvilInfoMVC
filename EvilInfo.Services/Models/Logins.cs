using System;
using System.Collections.Generic;

namespace EvilInfo.Services.Models
{
    public partial class Logins
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public virtual Users Users { get; set; }
    }
}
