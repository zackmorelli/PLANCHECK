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
    
    public partial class ActivityPttrnPerCycle
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ActivityPttrnPerCycle()
        {
            this.ActivityPttrnToSchedActivities = new HashSet<ActivityPttrnToSchedActivity>();
            this.PttrnRelatedNonSchActivities = new HashSet<PttrnRelatedNonSchActivity>();
        }
    
        public long ActivityPttrnPerCycleSer { get; set; }
        public long ActivityPttrnSer { get; set; }
        public Nullable<int> WeekNumber { get; set; }
        public Nullable<int> ActivityDayOfWeek { get; set; }
        public Nullable<System.DateTime> ActivityStartTime { get; set; }
        public Nullable<System.DateTime> ActivityEndTime { get; set; }
        public string HstryUserName { get; set; }
        public byte[] HstryTimeStamp { get; set; }
        public System.DateTime HstryDateTime { get; set; }
        public string HstryTaskName { get; set; }
    
        public virtual ActivityPttrn ActivityPttrn { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActivityPttrnToSchedActivity> ActivityPttrnToSchedActivities { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PttrnRelatedNonSchActivity> PttrnRelatedNonSchActivities { get; set; }
    }
}
