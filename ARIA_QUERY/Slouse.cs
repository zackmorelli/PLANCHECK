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
    
    public partial class Slouse
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Slouse()
        {
            this.ContrastBolus = new HashSet<ContrastBolu>();
            this.DerivedImageCodes = new HashSet<DerivedImageCode>();
            this.DerivedInstanceUIDs = new HashSet<DerivedInstanceUID>();
            this.ImageSlice = new HashSet<ImageSlouse>();
            this.SlicePortalDoseAnalysis = new HashSet<SlicePortalDoseAnalysi>();
        }
    
        public long SliceSer { get; set; }
        public long SeriesSer { get; set; }
        public string SliceUID { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public string CreationUserName { get; set; }
        public Nullable<int> SliceNumber { get; set; }
        public Nullable<double> Position { get; set; }
        public string FileName { get; set; }
        public string SliceType { get; set; }
        public string SliceModality { get; set; }
        public Nullable<long> ResourceSer { get; set; }
        public string SliceFormat { get; set; }
        public int HeaderSize { get; set; }
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public Nullable<int> AcqWindow { get; set; }
        public Nullable<int> AcqLevel { get; set; }
        public double ResolutionX { get; set; }
        public double ResolutionY { get; set; }
        public int CalibratedFlag { get; set; }
        public Nullable<int> PixelOffset { get; set; }
        public Nullable<double> PixelSlope { get; set; }
        public byte[] Transformation { get; set; }
        public string SliceCharacteristics { get; set; }
        public string PhotometricInterpretation { get; set; }
        public int BitsAllocated { get; set; }
        public Nullable<int> BitsStored { get; set; }
        public Nullable<double> CouchVrt { get; set; }
        public Nullable<double> CouchLng { get; set; }
        public Nullable<double> CouchLat { get; set; }
        public Nullable<double> PatientSupportAngle { get; set; }
        public Nullable<double> TableTopEccentricAngle { get; set; }
        public string ConversionType { get; set; }
        public int HighBit { get; set; }
        public Nullable<double> PatSupportPitchAngle { get; set; }
        public Nullable<double> PatSupportRollAngle { get; set; }
        public Nullable<double> Thickness { get; set; }
        public Nullable<long> EquipmentSer { get; set; }
        public Nullable<int> NumberOfFrames { get; set; }
        public Nullable<long> DCTransferSyntaxSer { get; set; }
        public int IsLockedFlag { get; set; }
        public string HstryUserName { get; set; }
        public byte[] HstryTimeStamp { get; set; }
        public System.DateTime HstryDateTime { get; set; }
        public string HstryTaskName { get; set; }
        public Nullable<int> PixelIntensityRel { get; set; }
        public Nullable<int> PixelIntensitySign { get; set; }
        public int PixelRepresentation { get; set; }
        public string TransactionId { get; set; }
        public Nullable<double> ActualPatientWeight { get; set; }
        public Nullable<double> ActualPatientHeight { get; set; }
        public Nullable<long> ContributingEquipmentSer { get; set; }
        public long SOPClassSer { get; set; }
        public Nullable<System.DateTime> AcquisitionDateTime { get; set; }
        public string IrradiationEventUID { get; set; }
        public string CharacterSet { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ContrastBolu> ContrastBolus { get; set; }
        public virtual DCTransferSyntax DCTransferSyntax { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DerivedImageCode> DerivedImageCodes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DerivedInstanceUID> DerivedInstanceUIDs { get; set; }
        public virtual Equipment Equipment { get; set; }
        public virtual Equipment Equipment1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImageSlouse> ImageSlice { get; set; }
        public virtual Machine Machine { get; set; }
        public virtual Series Series { get; set; }
        public virtual SliceCT SliceCT { get; set; }
        public virtual SliceMR SliceMR { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SlicePortalDoseAnalysi> SlicePortalDoseAnalysis { get; set; }
        public virtual SliceRT SliceRT { get; set; }
        public virtual SOPClass SOPClass { get; set; }
    }
}
