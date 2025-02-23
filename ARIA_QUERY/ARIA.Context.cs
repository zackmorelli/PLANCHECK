﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ARIA : DbContext
    {
        public ARIA()
            : base("name=variansystemEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AccessStatu> AccessStatus { get; set; }
        public virtual DbSet<AccountBillingCode> AccountBillingCodes { get; set; }
        public virtual DbSet<AccountBillingCodeMH> AccountBillingCodeMHs { get; set; }
        public virtual DbSet<ActCaptDiagnosi> ActCaptDiagnosis { get; set; }
        public virtual DbSet<ActCaptDiagnosisMH> ActCaptDiagnosisMHs { get; set; }
        public virtual DbSet<ActCaptTreatment> ActCaptTreatments { get; set; }
        public virtual DbSet<ActInstChecklistItem> ActInstChecklistItems { get; set; }
        public virtual DbSet<ActInstProcCode> ActInstProcCodes { get; set; }
        public virtual DbSet<ActInstProcCodeMH> ActInstProcCodeMHs { get; set; }
        public virtual DbSet<Activity> Activities { get; set; }
        public virtual DbSet<ActivityAssociation> ActivityAssociations { get; set; }
        public virtual DbSet<ActivityAttribute> ActivityAttributes { get; set; }
        public virtual DbSet<ActivityAttributeMH> ActivityAttributeMHs { get; set; }
        public virtual DbSet<ActivityCapture> ActivityCaptures { get; set; }
        public virtual DbSet<ActivityCaptureAttribute> ActivityCaptureAttributes { get; set; }
        public virtual DbSet<ActivityCaptureAttributeMH> ActivityCaptureAttributeMHs { get; set; }
        public virtual DbSet<ActivityCaptureMH> ActivityCaptureMHs { get; set; }
        public virtual DbSet<ActivityCategory> ActivityCategories { get; set; }
        public virtual DbSet<ActivityChecklistItem> ActivityChecklistItems { get; set; }
        public virtual DbSet<ActivityCodeMd> ActivityCodeMds { get; set; }
        public virtual DbSet<ActivityCodeMdMH> ActivityCodeMdMHs { get; set; }
        public virtual DbSet<ActivityInstance> ActivityInstances { get; set; }
        public virtual DbSet<ActivityInstanceLink> ActivityInstanceLinks { get; set; }
        public virtual DbSet<ActivityInstanceLinkMH> ActivityInstanceLinkMHs { get; set; }
        public virtual DbSet<ActivityInstanceMH> ActivityInstanceMHs { get; set; }
        public virtual DbSet<ActivityMH> ActivityMHs { get; set; }
        public virtual DbSet<ActivityPttrn> ActivityPttrns { get; set; }
        public virtual DbSet<ActivityPttrnPerCycle> ActivityPttrnPerCycles { get; set; }
        public virtual DbSet<ActivityPttrnResrc> ActivityPttrnResrcs { get; set; }
        public virtual DbSet<ActivityPttrnToSchedActivity> ActivityPttrnToSchedActivities { get; set; }
        public virtual DbSet<ActivitySession> ActivitySessions { get; set; }
        public virtual DbSet<ActivityToProcedureCode> ActivityToProcedureCodes { get; set; }
        public virtual DbSet<ActivityToProcedureItem> ActivityToProcedureItems { get; set; }
        public virtual DbSet<ActtyCatgryResrcType> ActtyCatgryResrcTypes { get; set; }
        public virtual DbSet<AddOn> AddOns { get; set; }
        public virtual DbSet<AddOnMaterial> AddOnMaterials { get; set; }
        public virtual DbSet<AddOnValidation> AddOnValidations { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<ADT08> ADT08 { get; set; }
        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<ApplicationAccessLog> ApplicationAccessLogs { get; set; }
        public virtual DbSet<ApplicationPrintReport> ApplicationPrintReports { get; set; }
        public virtual DbSet<Applicator> Applicators { get; set; }
        public virtual DbSet<ApplicatorJawSize> ApplicatorJawSizes { get; set; }
        public virtual DbSet<AppObject> AppObjects { get; set; }
        public virtual DbSet<Approval> Approvals { get; set; }
        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<ArchiveLocation> ArchiveLocations { get; set; }
        public virtual DbSet<ArchiveRestoredFile> ArchiveRestoredFiles { get; set; }
        public virtual DbSet<AriaConnectIntfTrgr> AriaConnectIntfTrgrs { get; set; }
        public virtual DbSet<Attendee> Attendees { get; set; }
        public virtual DbSet<AttendeeMH> AttendeeMHs { get; set; }
        public virtual DbSet<AuditLog> AuditLogs { get; set; }
        public virtual DbSet<Auxiliary> Auxiliaries { get; set; }
        public virtual DbSet<AvailPrefPttrnDetail> AvailPrefPttrnDetails { get; set; }
        public virtual DbSet<AvailPrefWeeklyPttrn> AvailPrefWeeklyPttrns { get; set; }
        public virtual DbSet<BeamlineOption> BeamlineOptions { get; set; }
        public virtual DbSet<BillingService> BillingServices { get; set; }
        public virtual DbSet<BillSysChrgWrk> BillSysChrgWrks { get; set; }
        public virtual DbSet<BillSysHospDeptActivity> BillSysHospDeptActivities { get; set; }
        public virtual DbSet<BillSysSentCharge> BillSysSentCharges { get; set; }
        public virtual DbSet<Block> Blocks { get; set; }
        public virtual DbSet<BrachyApplicator> BrachyApplicators { get; set; }
        public virtual DbSet<BrachyField> BrachyFields { get; set; }
        public virtual DbSet<BrachyFieldHstry> BrachyFieldHstries { get; set; }
        public virtual DbSet<BrachySolidApplicator> BrachySolidApplicators { get; set; }
        public virtual DbSet<BrachyUnit> BrachyUnits { get; set; }
        public virtual DbSet<BreakPoint> BreakPoints { get; set; }
        public virtual DbSet<Channel> Channels { get; set; }
        public virtual DbSet<ChargesControl> ChargesControls { get; set; }
        public virtual DbSet<ChartQA> ChartQAs { get; set; }
        public virtual DbSet<ChartQATreatment> ChartQATreatments { get; set; }
        public virtual DbSet<ChecklistGroup> ChecklistGroups { get; set; }
        public virtual DbSet<ChecklistItem> ChecklistItems { get; set; }
        public virtual DbSet<ChecklistItemGroup> ChecklistItemGroups { get; set; }
        public virtual DbSet<ChildMachine> ChildMachines { get; set; }
        public virtual DbSet<ChildProcessing> ChildProcessings { get; set; }
        public virtual DbSet<CodeStructureCode> CodeStructureCodes { get; set; }
        public virtual DbSet<Compensator> Compensators { get; set; }
        public virtual DbSet<ConfigurationGuard> ConfigurationGuards { get; set; }
        public virtual DbSet<ConfigurationItem> ConfigurationItems { get; set; }
        public virtual DbSet<ConfigurationSet> ConfigurationSets { get; set; }
        public virtual DbSet<ConfiguredEMT> ConfiguredEMTs { get; set; }
        public virtual DbSet<ContrastBolu> ContrastBolus { get; set; }
        public virtual DbSet<ContrastBolusCode> ContrastBolusCodes { get; set; }
        public virtual DbSet<ContrastFlow> ContrastFlows { get; set; }
        public virtual DbSet<ControlPoint> ControlPoints { get; set; }
        public virtual DbSet<ControlPointProton> ControlPointProtons { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<CourseDiagnosi> CourseDiagnosis { get; set; }
        public virtual DbSet<CoursePrintInfo> CoursePrintInfoes { get; set; }
        public virtual DbSet<Credit> Credits { get; set; }
        public virtual DbSet<CreditMH> CreditMHs { get; set; }
        public virtual DbSet<CTScanner> CTScanners { get; set; }
        public virtual DbSet<CTSimulator> CTSimulators { get; set; }
        public virtual DbSet<DBHistory> DBHistories { get; set; }
        public virtual DbSet<DCObjectPointerSery> DCObjectPointerSeries { get; set; }
        public virtual DbSet<DCObjectPointerStudy> DCObjectPointerStudies { get; set; }
        public virtual DbSet<DCObjectTrackingInfo> DCObjectTrackingInfoes { get; set; }
        public virtual DbSet<DCTransferSyntax> DCTransferSyntaxes { get; set; }
        public virtual DbSet<DeliverySetupDevice> DeliverySetupDevices { get; set; }
        public virtual DbSet<DeliverySetupDeviceMachine> DeliverySetupDeviceMachines { get; set; }
        public virtual DbSet<DemExternalBeam> DemExternalBeams { get; set; }
        public virtual DbSet<DemGroup> DemGroups { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DepartmentPttrnDetail> DepartmentPttrnDetails { get; set; }
        public virtual DbSet<DeptGrpAssociation> DeptGrpAssociations { get; set; }
        public virtual DbSet<DerivedImageCode> DerivedImageCodes { get; set; }
        public virtual DbSet<DerivedInstanceUID> DerivedInstanceUIDs { get; set; }
        public virtual DbSet<DiagnosisStage> DiagnosisStages { get; set; }
        public virtual DbSet<DICOMCodeMeaning> DICOMCodeMeanings { get; set; }
        public virtual DbSet<DICOMCodeScheme> DICOMCodeSchemes { get; set; }
        public virtual DbSet<DICOMCodeValue> DICOMCodeValues { get; set; }
        public virtual DbSet<DicomLocation> DicomLocations { get; set; }
        public virtual DbSet<Directive> Directives { get; set; }
        public virtual DbSet<Doctor> Doctors { get; set; }
        public virtual DbSet<DoctorBillingService> DoctorBillingServices { get; set; }
        public virtual DbSet<DoctorMH> DoctorMHs { get; set; }
        public virtual DbSet<DoseContribution> DoseContributions { get; set; }
        public virtual DbSet<DoseCorrectionLog> DoseCorrectionLogs { get; set; }
        public virtual DbSet<DoseMatrix> DoseMatrices { get; set; }
        public virtual DbSet<DoseRate> DoseRates { get; set; }
        public virtual DbSet<DoseTemplate> DoseTemplates { get; set; }
        public virtual DbSet<DosimetricData> DosimetricDatas { get; set; }
        public virtual DbSet<DrillBit> DrillBits { get; set; }
        public virtual DbSet<DVH> DVHs { get; set; }
        public virtual DbSet<DVHEstimationTrainingSet> DVHEstimationTrainingSets { get; set; }
        public virtual DbSet<DVHEstimationTrainingSetPlanSetup> DVHEstimationTrainingSetPlanSetups { get; set; }
        public virtual DbSet<DVHEstimationTrainingSetPlanSetupStructureMapping> DVHEstimationTrainingSetPlanSetupStructureMappings { get; set; }
        public virtual DbSet<DVHEstimationTrainingSetStructure> DVHEstimationTrainingSetStructures { get; set; }
        public virtual DbSet<DynamicWedge> DynamicWedges { get; set; }
        public virtual DbSet<Employer> Employers { get; set; }
        public virtual DbSet<EnergyMode> EnergyModes { get; set; }
        public virtual DbSet<Equipment> Equipments { get; set; }
        public virtual DbSet<ErrorMsg> ErrorMsgs { get; set; }
        public virtual DbSet<EstimatedDVH> EstimatedDVHs { get; set; }
        public virtual DbSet<ExternalBeam> ExternalBeams { get; set; }
        public virtual DbSet<ExternalField> ExternalFields { get; set; }
        public virtual DbSet<ExternalFieldCommon> ExternalFieldCommons { get; set; }
        public virtual DbSet<ExternalFieldCommonHstry> ExternalFieldCommonHstries { get; set; }
        public virtual DbSet<ExternalFieldHstry> ExternalFieldHstries { get; set; }
        public virtual DbSet<ExternalIntegration> ExternalIntegrations { get; set; }
        public virtual DbSet<FieldAddOn> FieldAddOns { get; set; }
        public virtual DbSet<FieldPhoto> FieldPhotoes { get; set; }
        public virtual DbSet<FieldProton> FieldProtons { get; set; }
        public virtual DbSet<FieldSpecificTargetParameter> FieldSpecificTargetParameters { get; set; }
        public virtual DbSet<FieldStructure> FieldStructures { get; set; }
        public virtual DbSet<FieldVariation> FieldVariations { get; set; }
        public virtual DbSet<FileLocation> FileLocations { get; set; }
        public virtual DbSet<GraphicAnnotation> GraphicAnnotations { get; set; }
        public virtual DbSet<GraphicAnnotationType> GraphicAnnotationTypes { get; set; }
        public virtual DbSet<GroupResource> GroupResources { get; set; }
        public virtual DbSet<Hospital> Hospitals { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Image4D> Image4D { get; set; }
        public virtual DbSet<ImageMatchResult> ImageMatchResults { get; set; }
        public virtual DbSet<ImageSlouse> ImageSlice { get; set; }
        public virtual DbSet<ImagingDevice> ImagingDevices { get; set; }
        public virtual DbSet<ImportExportColumn> ImportExportColumns { get; set; }
        public virtual DbSet<ImportExportReference> ImportExportReferences { get; set; }
        public virtual DbSet<ImportExportTable> ImportExportTables { get; set; }
        public virtual DbSet<IntfTrgr> IntfTrgrs { get; set; }
        public virtual DbSet<InVivoDosimetry> InVivoDosimetries { get; set; }
        public virtual DbSet<LanguageLookup> LanguageLookups { get; set; }
        public virtual DbSet<LinkUsage> LinkUsages { get; set; }
        public virtual DbSet<LocalizationJig> LocalizationJigs { get; set; }
        public virtual DbSet<LookupMapping> LookupMappings { get; set; }
        public virtual DbSet<LookupServiceCache> LookupServiceCaches { get; set; }
        public virtual DbSet<LookupTable> LookupTables { get; set; }
        public virtual DbSet<LTAScheduledTask> LTAScheduledTasks { get; set; }
        public virtual DbSet<LTAScheduledTaskPatient> LTAScheduledTaskPatients { get; set; }
        public virtual DbSet<Machine> Machines { get; set; }
        public virtual DbSet<MatchResult> MatchResults { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<Matrix> Matrices { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<MillingMachine> MillingMachines { get; set; }
        public virtual DbSet<MLC> MLCs { get; set; }
        public virtual DbSet<MLCBank> MLCBanks { get; set; }
        public virtual DbSet<MLCLeaf> MLCLeaves { get; set; }
        public virtual DbSet<MLCPlan> MLCPlans { get; set; }
        public virtual DbSet<MobilePhoneProvider> MobilePhoneProviders { get; set; }
        public virtual DbSet<NextKeyTable> NextKeyTables { get; set; }
        public virtual DbSet<NonScheduledActivity> NonScheduledActivities { get; set; }
        public virtual DbSet<NonScheduledActivityMH> NonScheduledActivityMHs { get; set; }
        public virtual DbSet<ObjectPointer> ObjectPointers { get; set; }
        public virtual DbSet<ObsoleteObject> ObsoleteObjects { get; set; }
        public virtual DbSet<OperatingLimit> OperatingLimits { get; set; }
        public virtual DbSet<ParameterType> ParameterTypes { get; set; }
        public virtual DbSet<PatEdHstryRelevance> PatEdHstryRelevances { get; set; }
        public virtual DbSet<Patient> Patients { get; set; }
        public virtual DbSet<PatientActual> PatientActuals { get; set; }
        public virtual DbSet<PatientAddress> PatientAddresses { get; set; }
        public virtual DbSet<PatientAuthorization> PatientAuthorizations { get; set; }
        public virtual DbSet<PatientDepartment> PatientDepartments { get; set; }
        public virtual DbSet<PatientDirective> PatientDirectives { get; set; }
        public virtual DbSet<PatientDoctor> PatientDoctors { get; set; }
        public virtual DbSet<PatientHospital> PatientHospitals { get; set; }
        public virtual DbSet<PatientHospitalMH> PatientHospitalMHs { get; set; }
        public virtual DbSet<PatientLocation> PatientLocations { get; set; }
        public virtual DbSet<PatientLocationMH> PatientLocationMHs { get; set; }
        public virtual DbSet<PatientNote> PatientNotes { get; set; }
        public virtual DbSet<PatientParticular> PatientParticulars { get; set; }
        public virtual DbSet<PatientPayor> PatientPayors { get; set; }
        public virtual DbSet<PatientPayorMH> PatientPayorMHs { get; set; }
        public virtual DbSet<PatientStaff> PatientStaffs { get; set; }
        public virtual DbSet<PatientSupportDevice> PatientSupportDevices { get; set; }
        public virtual DbSet<PatientTransportation> PatientTransportations { get; set; }
        public virtual DbSet<PatientVolume> PatientVolumes { get; set; }
        public virtual DbSet<Payor> Payors { get; set; }
        public virtual DbSet<PayorAuthorization> PayorAuthorizations { get; set; }
        public virtual DbSet<PerformedProcedure> PerformedProcedures { get; set; }
        public virtual DbSet<Photo> Photos { get; set; }
        public virtual DbSet<PhotonCompensator> PhotonCompensators { get; set; }
        public virtual DbSet<PhysicalMaterial> PhysicalMaterials { get; set; }
        public virtual DbSet<PhysicianIntent> PhysicianIntents { get; set; }
        public virtual DbSet<PlanConcurrency> PlanConcurrencies { get; set; }
        public virtual DbSet<PlanningSystem> PlanningSystems { get; set; }
        public virtual DbSet<PlanRelationship> PlanRelationships { get; set; }
        public virtual DbSet<PlanSetup> PlanSetups { get; set; }
        public virtual DbSet<PlanSetupStructureModelStructure> PlanSetupStructureModelStructures { get; set; }
        public virtual DbSet<PlanSource> PlanSources { get; set; }
        public virtual DbSet<PlanSum> PlanSums { get; set; }
        public virtual DbSet<PlanSumPlanSetup> PlanSumPlanSetups { get; set; }
        public virtual DbSet<PlanType> PlanTypes { get; set; }
        public virtual DbSet<PlanVariation> PlanVariations { get; set; }
        public virtual DbSet<PointOfContact> PointOfContacts { get; set; }
        public virtual DbSet<PortalDoseAnalysi> PortalDoseAnalysis { get; set; }
        public virtual DbSet<PortImager> PortImagers { get; set; }
        public virtual DbSet<Prescription> Prescriptions { get; set; }
        public virtual DbSet<PrescriptionAnatomy> PrescriptionAnatomies { get; set; }
        public virtual DbSet<PrescriptionAnatomyItem> PrescriptionAnatomyItems { get; set; }
        public virtual DbSet<PrescriptionProperty> PrescriptionProperties { get; set; }
        public virtual DbSet<PrescriptionPropertyItem> PrescriptionPropertyItems { get; set; }
        public virtual DbSet<PrescriptionTemplate> PrescriptionTemplates { get; set; }
        public virtual DbSet<PrescriptionTemplateAnatomy> PrescriptionTemplateAnatomies { get; set; }
        public virtual DbSet<PrescriptionTemplateAnatomyItem> PrescriptionTemplateAnatomyItems { get; set; }
        public virtual DbSet<PrescriptionTemplateProperty> PrescriptionTemplateProperties { get; set; }
        public virtual DbSet<PrescriptionTemplatePropertyItem> PrescriptionTemplatePropertyItems { get; set; }
        public virtual DbSet<PrimaryFluenceMode> PrimaryFluenceModes { get; set; }
        public virtual DbSet<PrintReport> PrintReports { get; set; }
        public virtual DbSet<ProcedureCode> ProcedureCodes { get; set; }
        public virtual DbSet<ProcedureCodeMH> ProcedureCodeMHs { get; set; }
        public virtual DbSet<ProcedureItem> ProcedureItems { get; set; }
        public virtual DbSet<ProcedureItemResource> ProcedureItemResources { get; set; }
        public virtual DbSet<ProcedureItemSOPClass> ProcedureItemSOPClasses { get; set; }
        public virtual DbSet<Processing> Processings { get; set; }
        public virtual DbSet<ProtonBeamSpot> ProtonBeamSpots { get; set; }
        public virtual DbSet<ProtonCompensator> ProtonCompensators { get; set; }
        public virtual DbSet<ProtonLateralSpreader> ProtonLateralSpreaders { get; set; }
        public virtual DbSet<PttrnRelatedNonSchActivity> PttrnRelatedNonSchActivities { get; set; }
        public virtual DbSet<Radiation> Radiations { get; set; }
        public virtual DbSet<RadiationDeliverySetupDevice> RadiationDeliverySetupDevices { get; set; }
        public virtual DbSet<RadiationDevice> RadiationDevices { get; set; }
        public virtual DbSet<RadiationHstry> RadiationHstries { get; set; }
        public virtual DbSet<RadiationRefPoint> RadiationRefPoints { get; set; }
        public virtual DbSet<RadioactiveSource> RadioactiveSources { get; set; }
        public virtual DbSet<RadioactiveSourceModel> RadioactiveSourceModels { get; set; }
        public virtual DbSet<RangeModulator> RangeModulators { get; set; }
        public virtual DbSet<RangeShifter> RangeShifters { get; set; }
        public virtual DbSet<Recipient> Recipients { get; set; }
        public virtual DbSet<RecurrenceElement> RecurrenceElements { get; set; }
        public virtual DbSet<RecurrenceRule> RecurrenceRules { get; set; }
        public virtual DbSet<RefPoint> RefPoints { get; set; }
        public virtual DbSet<RefPointHstry> RefPointHstries { get; set; }
        public virtual DbSet<RefPointLocation> RefPointLocations { get; set; }
        public virtual DbSet<RefPointLog> RefPointLogs { get; set; }
        public virtual DbSet<RefWaveformField> RefWaveformFields { get; set; }
        public virtual DbSet<RefWaveformRelation> RefWaveformRelations { get; set; }
        public virtual DbSet<ReminderAck> ReminderAcks { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<ReportLinkage> ReportLinkages { get; set; }
        public virtual DbSet<ReportParameter> ReportParameters { get; set; }
        public virtual DbSet<Resource> Resources { get; set; }
        public virtual DbSet<ResourceAddress> ResourceAddresses { get; set; }
        public virtual DbSet<ResourceDepartment> ResourceDepartments { get; set; }
        public virtual DbSet<ResourceGroup> ResourceGroups { get; set; }
        public virtual DbSet<ResourceIdentifier> ResourceIdentifiers { get; set; }
        public virtual DbSet<ResourceIdentifierType> ResourceIdentifierTypes { get; set; }
        public virtual DbSet<ResourceType> ResourceTypes { get; set; }
        public virtual DbSet<ResourceVenue> ResourceVenues { get; set; }
        public virtual DbSet<RTPlan> RTPlans { get; set; }
        public virtual DbSet<ScheduledActivity> ScheduledActivities { get; set; }
        public virtual DbSet<ScheduledActivityMH> ScheduledActivityMHs { get; set; }
        public virtual DbSet<ScheduledObjectPointer> ScheduledObjectPointers { get; set; }
        public virtual DbSet<ScheduledPerformedProcedure> ScheduledPerformedProcedures { get; set; }
        public virtual DbSet<ScheduledProcedure> ScheduledProcedures { get; set; }
        public virtual DbSet<ScheduledProcedureItem> ScheduledProcedureItems { get; set; }
        public virtual DbSet<ScheduleHoliday> ScheduleHolidays { get; set; }
        public virtual DbSet<Series> Series { get; set; }
        public virtual DbSet<ServiceControl> ServiceControls { get; set; }
        public virtual DbSet<Session> Sessions { get; set; }
        public virtual DbSet<SessionProcedure> SessionProcedures { get; set; }
        public virtual DbSet<SessionProcedurePart> SessionProcedureParts { get; set; }
        public virtual DbSet<SessionProcedureTemplate> SessionProcedureTemplates { get; set; }
        public virtual DbSet<SessionProcedureTemplatePart> SessionProcedureTemplateParts { get; set; }
        public virtual DbSet<SessionRTPlan> SessionRTPlans { get; set; }
        public virtual DbSet<SimulationImager> SimulationImagers { get; set; }
        public virtual DbSet<Simulator> Simulators { get; set; }
        public virtual DbSet<Slouse> Slice { get; set; }
        public virtual DbSet<SliceCT> SliceCTs { get; set; }
        public virtual DbSet<SliceMR> SliceMRs { get; set; }
        public virtual DbSet<SlicePortalDoseAnalysi> SlicePortalDoseAnalysis { get; set; }
        public virtual DbSet<SliceRT> SliceRTs { get; set; }
        public virtual DbSet<Slot> Slots { get; set; }
        public virtual DbSet<SlotAddOn> SlotAddOns { get; set; }
        public virtual DbSet<Snout> Snouts { get; set; }
        public virtual DbSet<SOPClass> SOPClasses { get; set; }
        public virtual DbSet<SourcePosition> SourcePositions { get; set; }
        public virtual DbSet<SpatialRegistration> SpatialRegistrations { get; set; }
        public virtual DbSet<SpatialRegistrationImage> SpatialRegistrationImages { get; set; }
        public virtual DbSet<SpatialRegistrationIOD> SpatialRegistrationIODs { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<StaffMH> StaffMHs { get; set; }
        public virtual DbSet<StandardWedge> StandardWedges { get; set; }
        public virtual DbSet<Structure> Structures { get; set; }
        public virtual DbSet<StructureCode> StructureCodes { get; set; }
        public virtual DbSet<StructureIdStructureCode> StructureIdStructureCodes { get; set; }
        public virtual DbSet<StructureSet> StructureSets { get; set; }
        public virtual DbSet<StructureStructureCode> StructureStructureCodes { get; set; }
        public virtual DbSet<StructureType> StructureTypes { get; set; }
        public virtual DbSet<STTFile> STTFiles { get; set; }
        public virtual DbSet<Study> Studies { get; set; }
        public virtual DbSet<SystemRoot> SystemRoots { get; set; }
        public virtual DbSet<Technique> Techniques { get; set; }
        public virtual DbSet<Template> Templates { get; set; }
        public virtual DbSet<TemplateCycle> TemplateCycles { get; set; }
        public virtual DbSet<TemplateCycleMH> TemplateCycleMHs { get; set; }
        public virtual DbSet<TemplateDiagnosi> TemplateDiagnosis { get; set; }
        public virtual DbSet<TemplateMH> TemplateMHs { get; set; }
        public virtual DbSet<TFHAddOn> TFHAddOns { get; set; }
        public virtual DbSet<TickerChannel> TickerChannels { get; set; }
        public virtual DbSet<TickerMessage> TickerMessages { get; set; }
        public virtual DbSet<TickerMessageChannel> TickerMessageChannels { get; set; }
        public virtual DbSet<Tolerance> Tolerances { get; set; }
        public virtual DbSet<ToleranceLimit> ToleranceLimits { get; set; }
        public virtual DbSet<Tracking> Trackings { get; set; }
        public virtual DbSet<TrackingField> TrackingFields { get; set; }
        public virtual DbSet<TrackingImage> TrackingImages { get; set; }
        public virtual DbSet<TrackingInformation> TrackingInformations { get; set; }
        public virtual DbSet<Transportation> Transportations { get; set; }
        public virtual DbSet<Tray> Trays { get; set; }
        public virtual DbSet<TreatmentCycle> TreatmentCycles { get; set; }
        public virtual DbSet<TreatmentPhase> TreatmentPhases { get; set; }
        public virtual DbSet<TreatmentRecord> TreatmentRecords { get; set; }
        public virtual DbSet<UserDefActAttr> UserDefActAttrs { get; set; }
        public virtual DbSet<UserDefActAttrMH> UserDefActAttrMHs { get; set; }
        public virtual DbSet<UserDefActAttrValue> UserDefActAttrValues { get; set; }
        public virtual DbSet<Venue> Venues { get; set; }
        public virtual DbSet<VideoDigitizer> VideoDigitizers { get; set; }
        public virtual DbSet<VolOptConstraint> VolOptConstraints { get; set; }
        public virtual DbSet<VolOptMatrix> VolOptMatrices { get; set; }
        public virtual DbSet<VolOptStruct> VolOptStructs { get; set; }
        public virtual DbSet<VolOptStructCstr> VolOptStructCstrs { get; set; }
        public virtual DbSet<VolumeCode> VolumeCodes { get; set; }
        public virtual DbSet<VolumeType> VolumeTypes { get; set; }
        public virtual DbSet<Wedge> Wedges { get; set; }
        public virtual DbSet<WeeklyChargeLink> WeeklyChargeLinks { get; set; }
        public virtual DbSet<Workspace> Workspaces { get; set; }
        public virtual DbSet<Workstation> Workstations { get; set; }
        public virtual DbSet<CoursePrintInfo1> CoursePrintInfo1 { get; set; }
        public virtual DbSet<LinkRTTemp> LinkRTTemps { get; set; }
        public virtual DbSet<PatEdHstryControl> PatEdHstryControls { get; set; }
        public virtual DbSet<PatientEditingLog> PatientEditingLogs { get; set; }
        public virtual DbSet<PatientRTStatu> PatientRTStatus { get; set; }
        public virtual DbSet<pbcatcol> pbcatcols { get; set; }
        public virtual DbSet<pbcatedt> pbcatedts { get; set; }
        public virtual DbSet<pbcatfmt> pbcatfmts { get; set; }
        public virtual DbSet<pbcattbl> pbcattbls { get; set; }
        public virtual DbSet<pbcatvld> pbcatvlds { get; set; }
        public virtual DbSet<PurgePatientTemp> PurgePatientTemps { get; set; }
        public virtual DbSet<AttributeMetaData> AttributeMetaDatas { get; set; }
        public virtual DbSet<AuraConfiguration> AuraConfigurations { get; set; }
        public virtual DbSet<ChangeTrackingTableList> ChangeTrackingTableLists { get; set; }
        public virtual DbSet<InitialCTDetail> InitialCTDetails { get; set; }
        public virtual DbSet<RadiationHstryPrintInfo> RadiationHstryPrintInfoes { get; set; }
        public virtual DbSet<stgDimPrescription> stgDimPrescriptions { get; set; }
        public virtual DbSet<stgDimPrescriptionAnatomy> stgDimPrescriptionAnatomies { get; set; }
        public virtual DbSet<stgDimPrescriptionProperty> stgDimPrescriptionProperties { get; set; }
        public virtual DbSet<stgDimTreatmentTransaction> stgDimTreatmentTransactions { get; set; }
        public virtual DbSet<Temp_DoseFiguresApp> Temp_DoseFiguresApp { get; set; }
        public virtual DbSet<Temp_DoseFiguresAppSum> Temp_DoseFiguresAppSum { get; set; }
        public virtual DbSet<Temp_DoseRefPoint> Temp_DoseRefPoint { get; set; }
        public virtual DbSet<Temp_TRTEventsCorrelated> Temp_TRTEventsCorrelated { get; set; }
        public virtual DbSet<Temp_TRTHistoryRecords> Temp_TRTHistoryRecords { get; set; }
    }
}
