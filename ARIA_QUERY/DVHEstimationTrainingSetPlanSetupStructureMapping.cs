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
    
    public partial class DVHEstimationTrainingSetPlanSetupStructureMapping
    {
        public long DVHEstimationTrainingSetSer { get; set; }
        public long PlanSetupSer { get; set; }
        public long StructureSer { get; set; }
        public long DVHEstimationTrainingSetStructureSer { get; set; }
        public string HstryUserName { get; set; }
        public System.DateTime HstryDateTime { get; set; }
        public byte[] HstryTimeStamp { get; set; }
        public string HstryTaskName { get; set; }
        public Nullable<System.Guid> DVHEstimationTrainingSetPlanSetupStructureMappingGuid { get; set; }
    
        public virtual DVHEstimationTrainingSetPlanSetup DVHEstimationTrainingSetPlanSetup { get; set; }
        public virtual DVHEstimationTrainingSetStructure DVHEstimationTrainingSetStructure { get; set; }
        public virtual Structure Structure { get; set; }
    }
}
