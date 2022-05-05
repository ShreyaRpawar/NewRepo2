using System;
using System.Collections.Generic;

namespace Employee_Onboarding.Models
{
    public partial class User
    {
        public int Userid { get; set; }
        public string Email { get; set; }
        public string UserPassword { get; set; }
        public object SignIn { get; internal set; }
    }
}
