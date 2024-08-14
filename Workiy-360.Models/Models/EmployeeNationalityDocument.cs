using System;
using System.Collections.Generic;

namespace Workiy_360.EntityFramework
{
    public partial class EmployeeNationalityDocument
    {
        public int NatPkId { get; set; }
        public int? FkId { get; set; }
        public string? NationalityGpName { get; set; }
        public string? NationalityGpNumber { get; set; }
        public string? NationalityGpLink { get; set; }
        public bool? StatusInd { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual EmployeeInformation? Fk { get; set; }
    }
}
