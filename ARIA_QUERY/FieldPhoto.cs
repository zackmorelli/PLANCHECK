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
    
    public partial class FieldPhoto
    {
        public long PhotoSer { get; set; }
        public long RadiationSer { get; set; }
        public Nullable<long> CacheKeySer { get; set; }
        public string HstryUserName { get; set; }
        public byte[] HstryTimeStamp { get; set; }
        public System.DateTime HstryDateTime { get; set; }
        public string HstryTaskName { get; set; }
        public int DisplaySequence { get; set; }
    
        public virtual Photo Photo { get; set; }
        public virtual Radiation Radiation { get; set; }
    }
}
