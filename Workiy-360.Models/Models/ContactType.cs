using System;
using System.Collections.Generic;

namespace Workiy_360.EntityFramework
{
    public partial class ContactType
    {
        public ContactType()
        {
            EmployeeContactDetails = new HashSet<EmployeeContactDetail>();
        }

        public int TypeId { get; set; }
        public string? TypeName { get; set; }

        public virtual ICollection<EmployeeContactDetail> EmployeeContactDetails { get; set; }
    }
}
