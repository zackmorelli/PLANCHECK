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
    
    public partial class ReportParameter
    {
        public long ReportParameterSer { get; set; }
        public long ReportSer { get; set; }
        public long ParameterTypeSer { get; set; }
        public int EnabledStatus { get; set; }
        public Nullable<int> EnabledDefaultFlag { get; set; }
        public string ReportColumn { get; set; }
        public string ParameterName1 { get; set; }
        public string ParameterName2 { get; set; }
        public string ParameterName3 { get; set; }
        public string ParameterName4 { get; set; }
        public string ParameterName5 { get; set; }
        public string HstryUserName { get; set; }
        public byte[] HstryTimeStamp { get; set; }
        public System.DateTime HstryDateTime { get; set; }
        public string HstryTaskName { get; set; }
    
        public virtual ParameterType ParameterType { get; set; }
        public virtual Report Report { get; set; }
    }
}
