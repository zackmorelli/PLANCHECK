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
    
    public partial class EnergyMode
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EnergyMode()
        {
            this.ApplicatorJawSizes = new HashSet<ApplicatorJawSize>();
            this.ConfiguredEMTs = new HashSet<ConfiguredEMT>();
            this.DemExternalBeams = new HashSet<DemExternalBeam>();
            this.DoseRates = new HashSet<DoseRate>();
            this.DosimetricDatas = new HashSet<DosimetricData>();
            this.ExternalBeams = new HashSet<ExternalBeam>();
            this.ExternalFieldCommons = new HashSet<ExternalFieldCommon>();
        }
    
        public long EnergyModeSer { get; set; }
        public long ResourceSer { get; set; }
        public string RadiationType { get; set; }
        public int Energy { get; set; }
        public Nullable<int> MaxEnergy { get; set; }
        public string ObjectStatus { get; set; }
        public Nullable<int> MinDoseRate { get; set; }
        public Nullable<int> MaxDoseRate { get; set; }
        public Nullable<int> DefaultFlag { get; set; }
        public string DisplayCode { get; set; }
        public Nullable<int> InternalCode { get; set; }
        public Nullable<int> LevelCode { get; set; }
        public string Comment { get; set; }
        public string HstryUserName { get; set; }
        public byte[] HstryTimeStamp { get; set; }
        public System.DateTime HstryDateTime { get; set; }
        public string HstryTaskName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ApplicatorJawSize> ApplicatorJawSizes { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ConfiguredEMT> ConfiguredEMTs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DemExternalBeam> DemExternalBeams { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DoseRate> DoseRates { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DosimetricData> DosimetricDatas { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExternalBeam> ExternalBeams { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ExternalFieldCommon> ExternalFieldCommons { get; set; }
        public virtual ExternalBeam ExternalBeam { get; set; }
    }
}
