using System;
using System.Collections.Generic;

namespace Workiy_360.EntityFramework
{
    public partial class EmployeeEducationalDetail
    {
        public int EducationalPkId { get; set; }
        public int? FkId { get; set; }
        public string? Degree { get; set; }
        public string? NameOfTheDegree { get; set; }
        public string? Major { get; set; }
        public string? Institute { get; set; }
        public DateOnly? YearOfCompletion { get; set; }
        public bool? StatusInd { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }

        public virtual EmployeeInformation? Fk { get; set; }
    }
}
