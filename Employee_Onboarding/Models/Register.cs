using System;
using System.Collections.Generic;

namespace Employee_Onboarding.Models
{
    public partial class Register
    {
        public int Userid { get; set; }
        public string Email { get; set; }
        public string UserPassword { get; set; }
        public int Roleid { get; set; }
        public virtual Role Role { get; set; }
    }
}
