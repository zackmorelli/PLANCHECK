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
    
    public partial class PatientHospital
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PatientHospital()
        {
            this.PatientHospitalMHs = new HashSet<PatientHospitalMH>();
        }
    
        public long HospitalSer { get; set; }
        public long PatientSer { get; set; }
        public Nullable<long> CacheKeySer { get; set; }
        public int PatientHospitalRevCount { get; set; }
        public int InPatientFlag { get; set; }
        public string PatientLocation { get; set; }
        public string PatientStatus { get; set; }
        public Nullable<System.DateTime> StartDateTime { get; set; }
        public Nullable<System.DateTime> ProjectedEndDate { get; set; }
        public Nullable<System.DateTime> EndDateTime { get; set; }
        public string HstryUserName { get; set; }
        public byte[] HstryTimeStamp { get; set; }
        public System.DateTime HstryDateTime { get; set; }
        public string HstryTaskName { get; set; }
    
        public virtual Hospital Hospital { get; set; }
        public virtual Patient Patient { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatientHospitalMH> PatientHospitalMHs { get; set; }
    }
}
