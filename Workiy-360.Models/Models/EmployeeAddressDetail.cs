using System;
using System.Collections.Generic;

namespace Workiy_360.EntityFramework
{
    public partial class EmployeeAddressDetail
    {
        public int AddressPkId { get; set; }
        public int? ContactFkId { get; set; }
        public int? FkId { get; set; }
        public string? AddressType { get; set; }
        public string? Address1 { get; set; }
        public string? Address2 { get; set; }
        public int? Pincode { get; set; }
        public string? Area { get; set; }
        public string? City { get; set; }
        public string? State { get; set; }
        public string? Country { get; set; }

        public virtual EmployeeContactDetail? ContactFk { get; set; }
        public virtual EmployeeInformation? Fk { get; set; }
    }
}
