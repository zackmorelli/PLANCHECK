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
    
    public partial class Tracking
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tracking()
        {
            this.ExternalFields = new HashSet<ExternalField>();
            this.RefWaveformRelations = new HashSet<RefWaveformRelation>();
            this.RefWaveformRelations1 = new HashSet<RefWaveformRelation>();
            this.TrackingFields = new HashSet<TrackingField>();
            this.TrackingImages = new HashSet<TrackingImage>();
        }
    
        public long TrackingSer { get; set; }
        public long SeriesSer { get; set; }
        public Nullable<long> PlanSetupSer { get; set; }
        public string TrackingId { get; set; }
        public string TrackingName { get; set; }
        public string TrackingUID { get; set; }
        public System.DateTime CreationDate { get; set; }
        public string Comment { get; set; }
        public string FileName { get; set; }
        public short TrackingType { get; set; }
        public Nullable<long> EquipmentSer { get; set; }
        public string HstryUserName { get; set; }
        public byte[] HstryTimeStamp { get; set; }
        public System.DateTime HstryDateTime { get; set; }
        public string HstryTaskName { get; set; }
        public string CharacterSet { get; set; }
    
        public virtual Equipment Equipment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExternalField> ExternalFields { get; set; }
        public virtual PlanSetup PlanSetup { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RefWaveformRelation> RefWaveformRelations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RefWaveformRelation> RefWaveformRelations1 { get; set; }
        public virtual Series Series { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrackingField> TrackingFields { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TrackingImage> TrackingImages { get; set; }
    }
}
