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
    
    public partial class BrachySolidApplicator
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BrachySolidApplicator()
        {
            this.BrachyFields = new HashSet<BrachyField>();
        }
    
        public long BrachySolidApplicatorSer { get; set; }
        public long PlanSetupSer { get; set; }
        public string BrachySolidApplicatorId { get; set; }
        public string BrachySolidApplicatorName { get; set; }
        public string ApplicatorPartUID { get; set; }
        public string ApplicatorPartFileName { get; set; }
        public byte[] Transformation { get; set; }
        public string Comment { get; set; }
        public string HstryUserName { get; set; }
        public System.DateTime HstryDateTime { get; set; }
        public byte[] HstryTimeStamp { get; set; }
        public string HstryTaskName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BrachyField> BrachyFields { get; set; }
        public virtual PlanSetup PlanSetup { get; set; }
    }
}
