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
    
    public partial class ActivityInstanceMH
    {
        public long ActivityInstanceSer { get; set; }
        public int ActivityInstanceRevCount { get; set; }
        public Nullable<long> TemplateCycleSer { get; set; }
        public Nullable<int> TemplateCycleRevCount { get; set; }
        public long ActivitySer { get; set; }
        public int ActivityRevCount { get; set; }
        public Nullable<long> DepartmentSer { get; set; }
        public int AppointmentInstanceFlag { get; set; }
        public string ObjectStatus { get; set; }
        public Nullable<long> PredecessorSer { get; set; }
        public int AppointmentDependentFlag { get; set; }
        public Nullable<int> NotificationPriorTime { get; set; }
        public Nullable<int> Duration { get; set; }
        public int ExclusiveFlag { get; set; }
        public Nullable<int> ActivityGroup { get; set; }
        public Nullable<int> MinPostDuration { get; set; }
        public Nullable<int> MinTrtmntOccurence { get; set; }
        public Nullable<int> MaxTrtmntOccurence { get; set; }
        public Nullable<int> DefaultTrtmntOccurence { get; set; }
        public Nullable<int> WeekNumber { get; set; }
        public Nullable<int> DayOfWeek { get; set; }
        public Nullable<int> PriorPostDueDurUnits { get; set; }
        public string ActivityNote { get; set; }
        public int ActInstReadOnly { get; set; }
        public string HstryUserName { get; set; }
        public byte[] HstryTimeStamp { get; set; }
        public System.DateTime HstryDateTime { get; set; }
        public string HstryTaskName { get; set; }
        public string ActivityInstanceId { get; set; }
        public Nullable<long> StudySer { get; set; }
        public string WorklistType { get; set; }
        public string PlacerOrderNumber { get; set; }
        public string FillerOrderNumber { get; set; }
        public int NotificationPriorTimeFlag { get; set; }
        public Nullable<long> LastStatusUpdatedByResourceSer { get; set; }
        public Nullable<System.DateTime> LastStatusUpdatedDate { get; set; }
        public Nullable<long> LastNoteUpdatedByResourceSer { get; set; }
        public Nullable<System.DateTime> LastNoteUpdatedDate { get; set; }
        public Nullable<long> WorkFlowOverrideByResourceSer { get; set; }
        public Nullable<System.DateTime> WorkFlowOverrideDate { get; set; }
        public int AnchorActivityFlag { get; set; }
        public int AutoAssignOncologistFlag { get; set; }
    
        public virtual ActivityInstance ActivityInstance { get; set; }
    }
}
