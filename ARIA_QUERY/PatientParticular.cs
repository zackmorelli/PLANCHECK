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
    
    public partial class PatientParticular
    {
        public long PatientSer { get; set; }
        public string UniversalPatientId { get; set; }
        public string PassportNumber { get; set; }
        public string PatientState { get; set; }
        public string MaritalStatus { get; set; }
        public string PregnancyStatus { get; set; }
        public string MedicalAlerts { get; set; }
        public string ContrastAllergies { get; set; }
        public Nullable<System.DateTime> LastMenstrualDate { get; set; }
        public string SmokingStatus { get; set; }
        public Nullable<System.DateTime> RetireDate { get; set; }
        public string RetireReason { get; set; }
        public string RetireNote { get; set; }
        public Nullable<System.DateTime> DeathDate { get; set; }
        public string DeathCause { get; set; }
        public string AutopsyStatus { get; set; }
        public string AutopsyOutcome { get; set; }
        public string BloodGroup { get; set; }
        public string UserDefAttrib01 { get; set; }
        public string UserDefAttrib02 { get; set; }
        public string UserDefAttrib03 { get; set; }
        public string UserDefAttrib04 { get; set; }
        public string UserDefAttrib05 { get; set; }
        public string UserDefAttrib06 { get; set; }
        public string UserDefAttrib07 { get; set; }
        public string UserDefAttrib08 { get; set; }
        public string UserDefAttrib09 { get; set; }
        public string UserDefAttrib10 { get; set; }
        public string UserDefAttrib11 { get; set; }
        public string UserDefAttrib12 { get; set; }
        public string UserDefAttrib13 { get; set; }
        public string UserDefAttrib14 { get; set; }
        public string UserDefAttrib15 { get; set; }
        public string UserDefAttrib16 { get; set; }
    
        public virtual Patient Patient { get; set; }
    }
}
