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
    
    public partial class FieldStructure
    {
        public long FieldStructureSer { get; set; }
        public long RadiationSer { get; set; }
        public long StructureSer { get; set; }
        public string StructUsageType { get; set; }
        public string HstryUserName { get; set; }
        public byte[] HstryTimeStamp { get; set; }
        public System.DateTime HstryDateTime { get; set; }
        public string HstryTaskName { get; set; }
        public Nullable<long> BlockSer { get; set; }
        public string CustomCode { get; set; }
    
        public virtual Block Block { get; set; }
        public virtual ExternalFieldCommon ExternalFieldCommon { get; set; }
        public virtual Structure Structure { get; set; }
    }
}
