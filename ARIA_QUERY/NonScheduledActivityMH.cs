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
    
    public partial class NonScheduledActivityMH
    {
        public long NonScheduledActivitySer { get; set; }
        public int NonScheduledActivityRevCount { get; set; }
        public long ActivityInstanceSer { get; set; }
        public int ActivityInstanceRevCount { get; set; }
        public Nullable<long> PatientSer { get; set; }
        public Nullable<long> CreatedByResourceSer { get; set; }
        public string CreatedByUserName { get; set; }
        public System.DateTime CreationDate { get; set; }
        public string UID { get; set; }
        public string ObjectStatus { get; set; }
        public Nullable<System.DateTime> DueDateTime { get; set; }
        public string NonScheduledActivityCode { get; set; }
        public string Priority { get; set; }
        public string ActivityNote { get; set; }
        public Nullable<long> RecurrenceRuleSer { get; set; }
        public string ReadByAppUserName { get; set; }
        public Nullable<System.DateTime> ReadByDateTime { get; set; }
        public string HstryUserName { get; set; }
        public byte[] HstryTimeStamp { get; set; }
        public System.DateTime HstryDateTime { get; set; }
        public string HstryTaskName { get; set; }
        public int WorkFlowActiveFlag { get; set; }
    
        public virtual NonScheduledActivity NonScheduledActivity { get; set; }
    }
}
