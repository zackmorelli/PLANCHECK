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
    
    public partial class ActivityAssociation
    {
        public long ActivityAssociationSer { get; set; }
        public long NonSchedulableActivitySer { get; set; }
        public long SchedulableActivitySer { get; set; }
        public int DefaultFlag { get; set; }
        public Nullable<int> DefaultPriorPostDueTime { get; set; }
        public Nullable<int> NoEditFlag { get; set; }
        public string HstryUserName { get; set; }
        public byte[] HstryTimeStamp { get; set; }
        public System.DateTime HstryDateTime { get; set; }
        public string HstryTaskName { get; set; }
    
        public virtual Activity Activity { get; set; }
        public virtual Activity Activity1 { get; set; }
    }
}
