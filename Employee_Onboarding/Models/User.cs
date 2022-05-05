using System;
using System.Collections.Generic;

namespace Employee_Onboarding.Models
{
    public partial class User
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailId { get; set; }
        public string UserPassword { get; set; }
    }
}
