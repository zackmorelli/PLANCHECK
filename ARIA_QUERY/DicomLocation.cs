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
    
    public partial class DicomLocation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DicomLocation()
        {
            this.ObjectPointers = new HashSet<ObjectPointer>();
        }
    
        public long DicomLocationSer { get; set; }
        public string MediaFileSetID { get; set; }
        public string MediaFileSetUID { get; set; }
        public string AETitle { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ObjectPointer> ObjectPointers { get; set; }
    }
}
