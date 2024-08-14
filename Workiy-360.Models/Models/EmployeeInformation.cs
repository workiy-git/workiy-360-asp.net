using System;
using System.Collections.Generic;

namespace Workiy_360.EntityFramework
{
    public partial class EmployeeInformation
    {
        public EmployeeInformation()
        {
   
            EmployeeAddressDetails = new HashSet<EmployeeAddressDetail>();
           
            EmployeeContactDetails = new HashSet<EmployeeContactDetail>();
            EmployeeEducationalDetails = new HashSet<EmployeeEducationalDetail>();
            EmployeeExperienceDetails = new HashSet<EmployeeExperienceDetail>();
       
            EmployeeNationalityDocuments = new HashSet<EmployeeNationalityDocument>();
          
        }

        public int PkEmployeeId { get; set; }
        public int? EmployeeId { get; set; }
        public string? Prefix { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? FatherName { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public int? Age { get; set; }
        public string? Gender { get; set; }
        public string? BloodGroup { get; set; }
        public string? MaritalStatus { get; set; }
        public string? MobileNo { get; set; }
        public string? PersonalMail { get; set; }
        public bool? StatusInd { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual ICollection<EmployeeAddressDetail> EmployeeAddressDetails { get; set; }
       
        public virtual ICollection<EmployeeContactDetail> EmployeeContactDetails { get; set; }
        public virtual ICollection<EmployeeEducationalDetail> EmployeeEducationalDetails { get; set; }
        public virtual ICollection<EmployeeExperienceDetail> EmployeeExperienceDetails { get; set; }

        public virtual ICollection<EmployeeNationalityDocument> EmployeeNationalityDocuments { get; set; }

    }
}
