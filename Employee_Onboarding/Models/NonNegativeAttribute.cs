using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;

namespace Employee_Onboarding.Models
{
    public class NonNegativeAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (Convert.ToInt32(value) > 0 && Convert.ToInt32(value) <= 100)
            {
                return true;

            }
            return false;
        }

    }

    public class numberattribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int a = 0;
            if (a <= 0 && a >= 100)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
  
}

