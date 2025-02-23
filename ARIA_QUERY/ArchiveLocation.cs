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
    
    public partial class ArchiveLocation
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ArchiveLocation()
        {
            this.LTAScheduledTasks = new HashSet<LTAScheduledTask>();
            this.TrackingInformations = new HashSet<TrackingInformation>();
        }
    
        public long ArchiveLocationSer { get; set; }
        public string ArchiveLocationPath { get; set; }
        public string ArchiveMediaType { get; set; }
        public string ArchiveMediaStatus { get; set; }
        public string ArchiveMediaLabel { get; set; }
        public string ArchiveMediaId { get; set; }
        public System.DateTime ArchiveMediaStartDate { get; set; }
        public Nullable<System.DateTime> ArchiveMediaCloseDate { get; set; }
        public string ObjectStatus { get; set; }
        public string HstryUserName { get; set; }
        public byte[] HstryTimeStamp { get; set; }
        public System.DateTime HstryDateTime { get; set; }
        public string HstryTaskName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<LTAScheduledTask> LTAScheduledTasks { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrackingInformation> TrackingInformations { get; set; }
    }
}
