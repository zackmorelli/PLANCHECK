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
    
    public partial class BreakPoint
    {
        public long BreakPointSer { get; set; }
        public long RefPointSer { get; set; }
        public int BreakPointNum { get; set; }
        public Nullable<double> BreakPointDose { get; set; }
        public string BreakPointCondition { get; set; }
        public string AuthorizationName { get; set; }
        public string Note { get; set; }
        public Nullable<System.DateTime> AuthorizationDate { get; set; }
        public string HstryUserName { get; set; }
        public byte[] HstryTimeStamp { get; set; }
        public System.DateTime HstryDateTime { get; set; }
        public string HstryTaskName { get; set; }
    
        public virtual RefPoint RefPoint { get; set; }
    }
}
