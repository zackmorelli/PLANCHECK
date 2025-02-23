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
    
    public partial class ChartQA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChartQA()
        {
            this.ChartQATreatments = new HashSet<ChartQATreatment>();
        }
    
        public long ChartQASer { get; set; }
        public long PatientSer { get; set; }
        public System.DateTime ChartQADateTime { get; set; }
        public string ChartQABy { get; set; }
        public string Comment { get; set; }
        public Nullable<long> ActivityInstanceSer { get; set; }
        public string HstryUserName { get; set; }
        public byte[] HstryTimeStamp { get; set; }
        public System.DateTime HstryDateTime { get; set; }
        public string HstryTaskName { get; set; }
    
        public virtual ActivityInstance ActivityInstance { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChartQATreatment> ChartQATreatments { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
