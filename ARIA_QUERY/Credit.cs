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
    
    public partial class Credit
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Credit()
        {
            this.CreditMHs = new HashSet<CreditMH>();
        }
    
        public long CreditSer { get; set; }
        public int CreditRevCount { get; set; }
        public long ActivityCaptureSer { get; set; }
        public int ActivityCaptureRevCount { get; set; }
        public long ActInstProcCodeSer { get; set; }
        public int ActInstProcCodeRevCount { get; set; }
        public string CreditedBy { get; set; }
        public Nullable<System.DateTime> CreditedDateTime { get; set; }
        public string ExportedBy { get; set; }
        public Nullable<System.DateTime> ExportedDateTime { get; set; }
        public string Note { get; set; }
        public string ObjectStatus { get; set; }
        public string HstryUserName { get; set; }
        public byte[] HstryTimeStamp { get; set; }
        public System.DateTime HstryDateTime { get; set; }
        public string HstryTaskName { get; set; }
    
        public virtual ActInstProcCode ActInstProcCode { get; set; }
        public virtual ActivityCapture ActivityCapture { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CreditMH> CreditMHs { get; set; }
    }
}
