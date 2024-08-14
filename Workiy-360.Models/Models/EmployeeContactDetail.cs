using System;
using System.Collections.Generic;

namespace Workiy_360.EntityFramework
{
    public partial class EmployeeContactDetail
    {
        public EmployeeContactDetail()
        {
            EmployeeAddressDetails = new HashSet<EmployeeAddressDetail>();
        }

        public int ContactPkId { get; set; }
        public int? FkId { get; set; }
        public int? TypeId { get; set; }
        public string? EmergencyConName { get; set; }
        public string? Relation { get; set; }
        public string? ConNum { get; set; }
        public bool? StatusInd { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual EmployeeInformation? Fk { get; set; }
        public virtual ContactType? Type { get; set; }
        public virtual ICollection<EmployeeAddressDetail> EmployeeAddressDetails { get; set; }
    }
}
