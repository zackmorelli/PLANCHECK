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
    
    public partial class PatientEditingLog
    {
        public long PatientEditingLogSer { get; set; }
        public long PatientSer { get; set; }
        public string TableName { get; set; }
        public string AttribName { get; set; }
        public Nullable<int> EventId { get; set; }
        public Nullable<long> Key1 { get; set; }
        public Nullable<long> Key2 { get; set; }
        public Nullable<long> Key3 { get; set; }
        public string TableId { get; set; }
        public string UID { get; set; }
        public string OldValue { get; set; }
        public string NewValue { get; set; }
        public string HstryUserName { get; set; }
        public System.DateTime HstryDateTime { get; set; }
        public byte[] HstryTimeStamp { get; set; }
        public string HstryTaskName { get; set; }
    
        public virtual Patient Patient { get; set; }
    }
}
