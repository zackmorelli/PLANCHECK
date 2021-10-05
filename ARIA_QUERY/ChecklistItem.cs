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
    
    public partial class ChecklistItem
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChecklistItem()
        {
            this.ActInstChecklistItems = new HashSet<ActInstChecklistItem>();
            this.ActivityChecklistItems = new HashSet<ActivityChecklistItem>();
            this.ChecklistItemGroups = new HashSet<ChecklistItemGroup>();
        }
    
        public long ChecklistItemSer { get; set; }
        public Nullable<long> DepartmentSer { get; set; }
        public string ChecklistItemDesc { get; set; }
        public string ObjectStatus { get; set; }
        public string HstryUserName { get; set; }
        public byte[] HstryTimeStamp { get; set; }
        public System.DateTime HstryDateTime { get; set; }
        public string HstryTaskName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActInstChecklistItem> ActInstChecklistItems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActivityChecklistItem> ActivityChecklistItems { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChecklistItemGroup> ChecklistItemGroups { get; set; }
        public virtual Department Department { get; set; }
    }
}
