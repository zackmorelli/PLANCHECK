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
    
    public partial class PrescriptionTemplateAnatomy
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PrescriptionTemplateAnatomy()
        {
            this.PrescriptionTemplateAnatomyItems = new HashSet<PrescriptionTemplateAnatomyItem>();
        }
    
        public long PrescriptionTemplateAnatomySer { get; set; }
        public string PrescriptionAnatomyTemplateName { get; set; }
        public Nullable<long> PrescriptionTemplateSer { get; set; }
        public Nullable<short> AnatomyRole { get; set; }
        public string AnatomyName { get; set; }
        public string UserCUID { get; set; }
        public string HstryUserName { get; set; }
        public System.DateTime HstryDateTime { get; set; }
        public byte[] HstryTimeStamp { get; set; }
        public string HstryTaskName { get; set; }
    
        public virtual PrescriptionTemplate PrescriptionTemplate { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PrescriptionTemplateAnatomyItem> PrescriptionTemplateAnatomyItems { get; set; }
    }
}
