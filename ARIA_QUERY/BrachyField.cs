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
    
    public partial class BrachyField
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BrachyField()
        {
            this.SourcePositions = new HashSet<SourcePosition>();
        }
    
        public long RadiationSer { get; set; }
        public Nullable<long> ChannelSer { get; set; }
        public Nullable<long> BrachyApplicatorSer { get; set; }
        public string BrachyFieldTypeInfo { get; set; }
        public Nullable<double> ApplicatorLength { get; set; }
        public Nullable<System.DateTime> PlannedTreatmDateTime { get; set; }
        public Nullable<double> StepSize { get; set; }
        public Nullable<double> FirstSourcePosition { get; set; }
        public Nullable<double> LastSourcePosition { get; set; }
        public Nullable<int> AutomaticPosFlag { get; set; }
        public Nullable<long> BrachySolidApplicatorSer { get; set; }
        public Nullable<int> ApplicatorPartChannelUID { get; set; }
    
        public virtual BrachyApplicator BrachyApplicator { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SourcePosition> SourcePositions { get; set; }
        public virtual BrachySolidApplicator BrachySolidApplicator { get; set; }
        public virtual Channel Channel { get; set; }
        public virtual Radiation Radiation { get; set; }
    }
}
