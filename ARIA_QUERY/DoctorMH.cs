//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ARIA_QUERY
{
    using System;
    using System.Collections.Generic;
    
    public partial class DoctorMH
    {
        public long ResourceSer { get; set; }
        public int ResourceRevCount { get; set; }
        public string DoctorId { get; set; }
        public string Honorific { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string NameSuffix { get; set; }
        public string AliasName { get; set; }
        public string Specialty { get; set; }
        public string Institution { get; set; }
        public string Comment { get; set; }
        public int OncologistFlag { get; set; }
        public string HstryUserName { get; set; }
        public byte[] HstryTimeStamp { get; set; }
        public System.DateTime HstryDateTime { get; set; }
        public string HstryTaskName { get; set; }
        public int ExternalMedOncFlag { get; set; }
    
        public virtual Doctor Doctor { get; set; }
    }
}
