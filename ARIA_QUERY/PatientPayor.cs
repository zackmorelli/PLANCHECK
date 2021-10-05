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
    
    public partial class PatientPayor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PatientPayor()
        {
            this.PatientAuthorizations = new HashSet<PatientAuthorization>();
            this.PatientPayorMHs = new HashSet<PatientPayorMH>();
        }
    
        public long PatientPayorSer { get; set; }
        public int PatientPayorRevCount { get; set; }
        public long PayorSer { get; set; }
        public string PolicyNumber { get; set; }
        public int PrimaryFlag { get; set; }
        public long PatientSer { get; set; }
        public string PreadmitNumber { get; set; }
        public string AccountNumber { get; set; }
        public Nullable<double> PrcntOfPaymnt { get; set; }
        public Nullable<decimal> CoPayment { get; set; }
        public string InsrdName { get; set; }
        public string InsrdMdclNmbr { get; set; }
        public string Relationship { get; set; }
        public string InsrdGroupNumber { get; set; }
        public string InsrdGroupName { get; set; }
        public string InsrdGroupEmpId { get; set; }
        public string InsrdGroupEmpName { get; set; }
        public Nullable<System.DateTime> VerificationDate { get; set; }
        public string CreatedByHL7 { get; set; }
        public string HstryUserName { get; set; }
        public byte[] HstryTimeStamp { get; set; }
        public System.DateTime HstryDateTime { get; set; }
        public string HstryTaskName { get; set; }
    
        public virtual Patient Patient { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatientAuthorization> PatientAuthorizations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatientPayorMH> PatientPayorMHs { get; set; }
        public virtual Payor Payor { get; set; }
    }
}
