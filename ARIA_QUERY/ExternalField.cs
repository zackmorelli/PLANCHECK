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
    
    public partial class ExternalField
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ExternalField()
        {
            this.Matrices = new HashSet<Matrix>();
            this.Series = new HashSet<Series>();
        }
    
        public long RadiationSer { get; set; }
        public Nullable<double> GantryRtn { get; set; }
        public Nullable<double> CollRtn { get; set; }
        public string CollMode { get; set; }
        public Nullable<double> CollX1 { get; set; }
        public Nullable<double> CollY1 { get; set; }
        public Nullable<double> CollX2 { get; set; }
        public Nullable<double> CollY2 { get; set; }
        public Nullable<double> TimepGy { get; set; }
        public string GantryRtnDirection { get; set; }
        public string GantryRtnExt { get; set; }
        public Nullable<int> DoseRate { get; set; }
        public Nullable<double> StopAngle { get; set; }
        public Nullable<double> WedgeDose { get; set; }
        public int BEVMarginFlag { get; set; }
        public Nullable<double> CollMarginBottom { get; set; }
        public string CalculationLog { get; set; }
        public int CalculationLogLen { get; set; }
        public Nullable<double> DirectionPointDistance { get; set; }
        public int EllipticalMarginFlag { get; set; }
        public Nullable<double> FldNormFactor { get; set; }
        public string FldNormMethod { get; set; }
        public Nullable<double> CollMarginLeft { get; set; }
        public Nullable<double> MUCoeff { get; set; }
        public Nullable<double> MUCoeffMWOpen { get; set; }
        public Nullable<double> MUCoeffMWWedged { get; set; }
        public Nullable<double> MUCoeffMWVirtual { get; set; }
        public int OptimizeCollRtnFlag { get; set; }
        public int SkinFlashFlag { get; set; }
        public string DRRTemplateFileName { get; set; }
        public Nullable<double> RefDose { get; set; }
        public Nullable<double> RefDoseMWOpen { get; set; }
        public Nullable<double> RefDoseMWWedged { get; set; }
        public Nullable<double> RefDoseMWVirtual { get; set; }
        public Nullable<double> CollMarginRight { get; set; }
        public Nullable<double> CollMarginTop { get; set; }
        public Nullable<double> WedgeWeightFactor { get; set; }
        public Nullable<double> WeightFactor { get; set; }
        public Nullable<long> TrackingSer { get; set; }
        public Nullable<double> DesiredDoseAtIsocenter { get; set; }
        public string MuCoeffUnit { get; set; }
        public Nullable<long> BaselinePortalDoseSer { get; set; }
    
        public virtual FieldProton FieldProton { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Matrix> Matrices { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Series> Series { get; set; }
        public virtual ExternalFieldCommon ExternalFieldCommon { get; set; }
        public virtual Image Image { get; set; }
        public virtual Tracking Tracking { get; set; }
    }
}
