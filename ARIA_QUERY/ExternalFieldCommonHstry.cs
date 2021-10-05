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
    
    public partial class ExternalFieldCommonHstry
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ExternalFieldCommonHstry()
        {
            this.TFHAddOns = new HashSet<TFHAddOn>();
        }
    
        public long RadiationHstrySer { get; set; }
        public Nullable<double> PlannedMeterset { get; set; }
        public Nullable<double> ActualMeterset { get; set; }
        public byte MetersetOverrideFlag { get; set; }
        public Nullable<double> SSD { get; set; }
        public Nullable<double> CouchCorrectionLat { get; set; }
        public Nullable<double> CouchCorrectionLng { get; set; }
        public Nullable<double> CouchCorrectionVrt { get; set; }
        public Nullable<double> CouchLat { get; set; }
        public byte CouchLatOverrideFlag { get; set; }
        public Nullable<double> CouchLatPlanned { get; set; }
        public Nullable<double> CouchLng { get; set; }
        public byte CouchLngOverrideFlag { get; set; }
        public Nullable<double> CouchLngPlanned { get; set; }
        public Nullable<double> CouchVrt { get; set; }
        public byte CouchVrtOverrideFlag { get; set; }
        public Nullable<double> CouchVrtPlanned { get; set; }
        public byte TableTopEccAngleOverFlag { get; set; }
        public Nullable<double> TableTopEccentricAngle { get; set; }
        public Nullable<double> PatientSupportAngle { get; set; }
        public byte PatientSupportAngleOverFlag { get; set; }
        public byte PatSupPitchOverrideFlag { get; set; }
        public Nullable<double> PatSupportPitchAngle { get; set; }
        public Nullable<double> PatSupportRollAngle { get; set; }
        public byte PatSupRollOverrideFlag { get; set; }
        public string PFFlag { get; set; }
        public byte PFMUSubFlag { get; set; }
        public string PIFlag { get; set; }
        public Nullable<long> ToleranceSer { get; set; }
        public Nullable<int> NominalEnergy { get; set; }
        public byte EnergyModeOverrideFlag { get; set; }
        public byte SSDOverrideFlag { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TFHAddOn> TFHAddOns { get; set; }
        public virtual ExternalFieldHstry ExternalFieldHstry { get; set; }
        public virtual RadiationHstry RadiationHstry { get; set; }
        public virtual Tolerance Tolerance { get; set; }
    }
}
