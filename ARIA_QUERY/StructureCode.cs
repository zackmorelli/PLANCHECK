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
    
    public partial class StructureCode
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StructureCode()
        {
            this.CodeStructureCodes = new HashSet<CodeStructureCode>();
            this.StructureIdStructureCodes = new HashSet<StructureIdStructureCode>();
            this.StructureStructureCodes = new HashSet<StructureStructureCode>();
        }
    
        public long StructureCodeSer { get; set; }
        public long DICOMCodeValueSer { get; set; }
        public Nullable<long> PurposeDICOMCodeValueSer { get; set; }
        public string DefaultStructureId { get; set; }
        public string Synonyms { get; set; }
        public int ActiveSubsetFlag { get; set; }
        public int ProtectedSubsetFlag { get; set; }
        public string HstryUserName { get; set; }
        public System.DateTime HstryDateTime { get; set; }
        public byte[] HstryTimeStamp { get; set; }
        public string HstryTaskName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CodeStructureCode> CodeStructureCodes { get; set; }
        public virtual DICOMCodeValue DICOMCodeValue { get; set; }
        public virtual DICOMCodeValue DICOMCodeValue1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StructureIdStructureCode> StructureIdStructureCodes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StructureStructureCode> StructureStructureCodes { get; set; }
    }
}
