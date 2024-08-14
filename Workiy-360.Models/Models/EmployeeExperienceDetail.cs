using System;
using System.Collections.Generic;

namespace Workiy_360.EntityFramework
{
    public partial class EmployeeExperienceDetail
    {
        public int ExpId { get; set; }
        public int? FkId { get; set; }
        public string? CompanyName { get; set; }
        public string? Designation { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public string? Duration { get; set; }
        public string? KeyRole { get; set; }
        public string? OtherInfo { get; set; }
        public bool? StatusInd { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual EmployeeInformation? Fk { get; set; }
    }
}
