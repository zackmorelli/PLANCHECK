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
    
    public partial class RadioactiveSource
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RadioactiveSource()
        {
            this.SourcePositions = new HashSet<SourcePosition>();
        }
    
        public long RadioactiveSourceSer { get; set; }
        public long RadioactiveSourceModelSer { get; set; }
        public Nullable<long> ResourceSer { get; set; }
        public string RadioactiveSourceId { get; set; }
        public string RadioactiveSourceName { get; set; }
        public Nullable<int> SourceNumber { get; set; }
        public string SourceSerialNo { get; set; }
        public Nullable<double> SourceStrength { get; set; }
        public Nullable<System.DateTime> CalibrationDate { get; set; }
        public string Comment { get; set; }
        public string ObjectStatus { get; set; }
        public string HstryUserName { get; set; }
        public System.DateTime HstryDateTime { get; set; }
        public byte[] HstryTimeStamp { get; set; }
        public string HstryTaskName { get; set; }
    
        public virtual RadiationDevice RadiationDevice { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SourcePosition> SourcePositions { get; set; }
        public virtual RadioactiveSourceModel RadioactiveSourceModel { get; set; }
    }
}
