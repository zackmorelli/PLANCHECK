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
    
    public partial class Payor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Payor()
        {
            this.ActivityCaptures = new HashSet<ActivityCapture>();
            this.PatientPayors = new HashSet<PatientPayor>();
            this.PayorAuthorizations = new HashSet<PayorAuthorization>();
            this.Templates = new HashSet<Template>();
        }
    
        public long PayorSer { get; set; }
        public Nullable<long> PlanTypeSer { get; set; }
        public string PlanNumber { get; set; }
        public string CompanyName { get; set; }
        public string StreetAddress1 { get; set; }
        public string StreetAddress2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string PrimaryContactName { get; set; }
        public string Phone { get; set; }
        public string FAX { get; set; }
        public string EmailAddress { get; set; }
        public Nullable<System.DateTime> EffectiveDate { get; set; }
        public Nullable<System.DateTime> EndDate { get; set; }
        public Nullable<int> NumOfPlanMmbrs { get; set; }
        public Nullable<decimal> MnthlyPaymntPerMmbr { get; set; }
        public Nullable<decimal> TotalPaymntPerDiag { get; set; }
        public Nullable<decimal> PlanDeductible { get; set; }
        public Nullable<decimal> PlanLimitAmount { get; set; }
        public Nullable<int> PlanLimitDays { get; set; }
        public string ObjectStatus { get; set; }
        public string HstryUserName { get; set; }
        public byte[] HstryTimeStamp { get; set; }
        public System.DateTime HstryDateTime { get; set; }
        public string HstryTaskName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActivityCapture> ActivityCaptures { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatientPayor> PatientPayors { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PayorAuthorization> PayorAuthorizations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Template> Templates { get; set; }
        public virtual PlanType PlanType { get; set; }
    }
}
