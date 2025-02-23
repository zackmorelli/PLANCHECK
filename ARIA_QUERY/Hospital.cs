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
    
    public partial class Hospital
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Hospital()
        {
            this.AccountBillingCodes = new HashSet<AccountBillingCode>();
            this.BillSysChrgWrks = new HashSet<BillSysChrgWrk>();
            this.BillSysHospDeptActivities = new HashSet<BillSysHospDeptActivity>();
            this.ChargesControls = new HashSet<ChargesControl>();
            this.Departments = new HashSet<Department>();
            this.PatientHospitals = new HashSet<PatientHospital>();
            this.Transportations = new HashSet<Transportation>();
        }
    
        public long HospitalSer { get; set; }
        public string HospitalName { get; set; }
        public Nullable<long> AddressSer { get; set; }
        public string HospitalLocation { get; set; }
        public string ObjectStatus { get; set; }
        public string Organization { get; set; }
        public string WebAddress { get; set; }
        public byte[] Logo { get; set; }
        public string HstryUserName { get; set; }
        public byte[] HstryTimeStamp { get; set; }
        public System.DateTime HstryDateTime { get; set; }
        public string HstryTaskName { get; set; }
        public string MailServerAddress { get; set; }
        public string MailUserName { get; set; }
        public string MailPassword { get; set; }
        public Nullable<int> MailPortNumber { get; set; }
        public int MailSSLFlag { get; set; }
        public int MailAnonymousFlag { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AccountBillingCode> AccountBillingCodes { get; set; }
        public virtual Address Address { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillSysChrgWrk> BillSysChrgWrks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BillSysHospDeptActivity> BillSysHospDeptActivities { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChargesControl> ChargesControls { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Department> Departments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatientHospital> PatientHospitals { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Transportation> Transportations { get; set; }
    }
}
