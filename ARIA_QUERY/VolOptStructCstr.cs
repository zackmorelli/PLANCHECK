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
    
    public partial class VolOptStructCstr
    {
        public long VolOptStructCstrSer { get; set; }
        public long VolOptStructSer { get; set; }
        public string VolOptStructCstrId { get; set; }
        public string VolOptStructCstrName { get; set; }
        public string Parameters { get; set; }
        public int ParametersLen { get; set; }
        public string HstryUserName { get; set; }
        public byte[] HstryTimeStamp { get; set; }
        public System.DateTime HstryDateTime { get; set; }
        public string HstryTaskName { get; set; }
    
        public virtual VolOptStruct VolOptStruct { get; set; }
    }
}
