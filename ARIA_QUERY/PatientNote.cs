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
    
    public partial class PatientNote
    {
        public long PatientNoteSer { get; set; }
        public long PatientSer { get; set; }
        public string Note { get; set; }
        public string PatientNoteCode { get; set; }
        public System.DateTime DisplayDateTime { get; set; }
        public string WrittenByAppUserName { get; set; }
        public string ReadByAppUserName { get; set; }
        public Nullable<System.DateTime> ReadDateTime { get; set; }
        public string ObjectStatus { get; set; }
        public string HstryUserName { get; set; }
        public byte[] HstryTimeStamp { get; set; }
        public System.DateTime HstryDateTime { get; set; }
        public string HstryTaskName { get; set; }
    
        public virtual Patient Patient { get; set; }
    }
}
