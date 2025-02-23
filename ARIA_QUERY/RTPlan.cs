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
    
    public partial class RTPlan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RTPlan()
        {
            this.DoseContributions = new HashSet<DoseContribution>();
            this.PlanRelationships = new HashSet<PlanRelationship>();
            this.PlanRelationships1 = new HashSet<PlanRelationship>();
            this.RadiationRefPoints = new HashSet<RadiationRefPoint>();
            this.SessionRTPlans = new HashSet<SessionRTPlan>();
            this.SessionProcedureParts = new HashSet<SessionProcedurePart>();
            this.TreatmentRecords = new HashSet<TreatmentRecord>();
        }
    
        public long RTPlanSer { get; set; }
        public long PlanSOPClassSer { get; set; }
        public string PlanUID { get; set; }
        public long PlanSetupSer { get; set; }
        public string RTPlanId { get; set; }
        public string RTPlanName { get; set; }
        public System.DateTime CreationDate { get; set; }
        public string CreationUserName { get; set; }
        public Nullable<int> NoFractions { get; set; }
        public Nullable<int> StartDelay { get; set; }
        public int DicomSeqNumber { get; set; }
        public string Comment { get; set; }
        public Nullable<int> InterfaceStamp { get; set; }
        public Nullable<double> PrescribedDose { get; set; }
        public long SeriesSer { get; set; }
        public byte[] PlanIntegrityHash { get; set; }
        public Nullable<int> PlanHashVersion { get; set; }
        public string HstryUserName { get; set; }
        public System.DateTime HstryDateTime { get; set; }
        public byte[] HstryTimeStamp { get; set; }
        public string HstryTaskName { get; set; }
        public Nullable<int> TreatmentOrder { get; set; }
        public string FileName { get; set; }
        public Nullable<int> FractionPatternDigitsPerDay { get; set; }
        public string FractionPattern { get; set; }
        public string CharacterSet { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DoseContribution> DoseContributions { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlanRelationship> PlanRelationships { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PlanRelationship> PlanRelationships1 { get; set; }
        public virtual PlanSetup PlanSetup { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RadiationRefPoint> RadiationRefPoints { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SessionRTPlan> SessionRTPlans { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SessionProcedurePart> SessionProcedureParts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TreatmentRecord> TreatmentRecords { get; set; }
        public virtual Series Series { get; set; }
        public virtual SOPClass SOPClass { get; set; }
    }
}
