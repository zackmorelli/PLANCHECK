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
    
    public partial class DVHEstimationTrainingSetStructure
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DVHEstimationTrainingSetStructure()
        {
            this.DVHEstimationTrainingSetPlanSetupStructureMappings = new HashSet<DVHEstimationTrainingSetPlanSetupStructureMapping>();
        }
    
        public long DVHEstimationTrainingSetStructureSer { get; set; }
        public long DVHEstimationTrainingSetSer { get; set; }
        public string HstryUserName { get; set; }
        public System.DateTime HstryDateTime { get; set; }
        public byte[] HstryTimeStamp { get; set; }
        public string HstryTaskName { get; set; }
        public Nullable<System.Guid> PlanningModelLibraryStructureGuid { get; set; }
    
        public virtual DVHEstimationTrainingSet DVHEstimationTrainingSet { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DVHEstimationTrainingSetPlanSetupStructureMapping> DVHEstimationTrainingSetPlanSetupStructureMappings { get; set; }
    }
}
