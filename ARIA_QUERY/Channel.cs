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
    
    public partial class Channel
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Channel()
        {
            this.BrachyFields = new HashSet<BrachyField>();
        }
    
        public long ChannelSer { get; set; }
        public long ResourceSer { get; set; }
        public string ChannelId { get; set; }
        public string ChannelName { get; set; }
        public Nullable<int> ChannelNumber { get; set; }
        public Nullable<double> MinLength { get; set; }
        public Nullable<double> MaxLength { get; set; }
        public string Comment { get; set; }
        public string HstryUserName { get; set; }
        public System.DateTime HstryDateTime { get; set; }
        public byte[] HstryTimeStamp { get; set; }
        public string HstryTaskName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BrachyField> BrachyFields { get; set; }
        public virtual BrachyUnit BrachyUnit { get; set; }
    }
}
