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
    
    public partial class RefPointLog
    {
        public long RefPointLogSer { get; set; }
        public Nullable<long> DoseCorrectionLogSer { get; set; }
        public long RefPointSer { get; set; }
        public string ModificationType { get; set; }
        public System.DateTime ModificationDate { get; set; }
        public Nullable<double> DoseDelta { get; set; }
        public string OvrdAuthorizedName { get; set; }
        public string HstryUserName { get; set; }
        public byte[] HstryTimeStamp { get; set; }
        public System.DateTime HstryDateTime { get; set; }
        public string HstryTaskName { get; set; }
    
        public virtual DoseCorrectionLog DoseCorrectionLog { get; set; }
        public virtual RefPoint RefPoint { get; set; }
    }
}
