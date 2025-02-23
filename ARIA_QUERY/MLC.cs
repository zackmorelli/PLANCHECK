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
    
    public partial class MLC
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public MLC()
        {
            this.MLCBanks = new HashSet<MLCBank>();
        }
    
        public long AddOnSer { get; set; }
        public string ManufacturerName { get; set; }
        public string MLCSerialNumber { get; set; }
        public string MLCModel { get; set; }
        public Nullable<double> Rotation { get; set; }
        public string SupportedFiles { get; set; }
        public int ArcEnableFlag { get; set; }
        public int DoseEnableFlag { get; set; }
        public double MinDoseDynamicLeafGap { get; set; }
        public double MinArcDynamicLeafGap { get; set; }
        public double MaxLeafSpeed { get; set; }
        public double DoseDynamicLeafTolerance { get; set; }
        public double ArcDynamicLeafTolerance { get; set; }
        public Nullable<double> MinStaticLeafGap { get; set; }
        public double MinSegmentThreshold { get; set; }
        public int MaxControlPoints { get; set; }
        public Nullable<double> SourceDistance { get; set; }
        public Nullable<double> ParallelJawSetBack { get; set; }
        public Nullable<double> PerpendicularJawSetBack { get; set; }
        public Nullable<double> MaxPerpendicularJawOpening { get; set; }
        public double NominalLeafLength { get; set; }
        public Nullable<double> FitMLCToBlockMarginDefault { get; set; }
        public Nullable<short> FitMLCToBlockMarginMethodDefault { get; set; }
    
        public virtual AddOn AddOn { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<MLCBank> MLCBanks { get; set; }
    }
}
