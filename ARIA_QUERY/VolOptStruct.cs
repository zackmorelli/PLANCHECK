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
    
    public partial class VolOptStruct
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VolOptStruct()
        {
            this.VolOptStructCstrs = new HashSet<VolOptStructCstr>();
        }
    
        public long VolOptStructSer { get; set; }
        public long VolOptConstraintsSer { get; set; }
        public long StructureSer { get; set; }
        public string VolOptStructId { get; set; }
        public string VolOptStructName { get; set; }
        public string Parameters { get; set; }
        public int ParametersLen { get; set; }
        public string HstryUserName { get; set; }
        public byte[] HstryTimeStamp { get; set; }
        public System.DateTime HstryDateTime { get; set; }
        public string HstryTaskName { get; set; }
    
        public virtual Structure Structure { get; set; }
        public virtual VolOptConstraint VolOptConstraint { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VolOptStructCstr> VolOptStructCstrs { get; set; }
    }
}
