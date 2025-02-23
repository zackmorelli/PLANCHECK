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
    
    public partial class ActivityCaptureAttribute
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ActivityCaptureAttribute()
        {
            this.ActivityCaptureAttributeMHs = new HashSet<ActivityCaptureAttributeMH>();
        }
    
        public long ActivityCaptureAttributeSer { get; set; }
        public int ActivityCaptureAttrRevCount { get; set; }
        public long ActivityCaptureSer { get; set; }
        public int ActivityCaptureRevCount { get; set; }
        public long ActivityAttributeSer { get; set; }
        public int ActivityAttributeRevCount { get; set; }
        public string AttributeValue { get; set; }
        public string ObjectStatus { get; set; }
        public string HstryUserName { get; set; }
        public byte[] HstryTimeStamp { get; set; }
        public System.DateTime HstryDateTime { get; set; }
        public string HstryTaskName { get; set; }
    
        public virtual ActivityAttribute ActivityAttribute { get; set; }
        public virtual ActivityCapture ActivityCapture { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ActivityCaptureAttributeMH> ActivityCaptureAttributeMHs { get; set; }
    }
}
