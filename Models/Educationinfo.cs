using System;
using System.Collections.Generic;

namespace Employee_Onboarding.Models
{
    public partial class Educationinfo
    {
        public int Educationid { get; set; }
        public int EmployeeId { get; set; }
        public string SscSchoolName { get; set; }
        public int? SscPercentage { get; set; }
        public int? SscPassingYear { get; set; }
        public string HscCollegeName { get; set; }
        public int? HscPercentage { get; set; }
        public int? HscPassingYear { get; set; }
        public string DegreeCollegeName { get; set; }
        public string Degree { get; set; }
        public int DegreePercentage { get; set; }
        public int? DegreePassingYear { get; set; }
        public string University { get; set; }
        public string HighestQualificaion { get; set; }

        public virtual Personalinfo Employee { get; set; }
    }
}
