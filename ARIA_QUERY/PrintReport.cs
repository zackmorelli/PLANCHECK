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
    
    public partial class PrintReport
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PrintReport()
        {
            this.ApplicationPrintReports = new HashSet<ApplicationPrintReport>();
        }
    
        public long PrintReportSer { get; set; }
        public string PrintReportID { get; set; }
        public string PrintReportDesc { get; set; }
        public string PrintReportTemplate { get; set; }
        public string PrintReportSP { get; set; }
        public string PrintReportArg { get; set; }
        public string PrintReportBind1 { get; set; }
        public string PrintReportBind2 { get; set; }
        public int ModeDialog1 { get; set; }
        public int ModeDialog2 { get; set; }
        public int ModeDialog3 { get; set; }
        public int ModeDialog4 { get; set; }
        public int PrintModeFlag { get; set; }
        public string HstryUserName { get; set; }
        public byte[] HstryTimeStamp { get; set; }
        public System.DateTime HstryDateTime { get; set; }
        public string HstryTaskName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ApplicationPrintReport> ApplicationPrintReports { get; set; }
    }
}
