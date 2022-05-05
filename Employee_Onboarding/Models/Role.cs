using System;
using System.Collections.Generic;

namespace Employee_Onboarding.Models
{
    public partial class Role
    {
        public Role()
        {
            Registers = new HashSet<Register>();
        }

        public int Roleid { get; set; }
        public string Roles { get; set; }

        public virtual ICollection<Register> Registers { get; set; }
    }
}
