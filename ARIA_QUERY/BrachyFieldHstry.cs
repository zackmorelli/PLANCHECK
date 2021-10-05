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
    
    public partial class BrachyFieldHstry
    {
        public long RadiationHstrySer { get; set; }
        public string BrachyTreatmentType { get; set; }
        public int ChannelNumber { get; set; }
        public double ChannelLength { get; set; }
        public double SpecifiedChannelTotalTime { get; set; }
        public double ChannelReferenceAirKerma { get; set; }
        public double DeliveredChannelTotalTime { get; set; }
        public Nullable<int> SpecifiedNumberOfPulses { get; set; }
        public Nullable<int> DeliveredNumberOfPulses { get; set; }
        public Nullable<double> SpecifiedPulseRepetitionInterval { get; set; }
        public Nullable<double> DeliveredPulseRepetitionInterval { get; set; }
        public string SourceSerialNumber { get; set; }
        public string SourceIsotopeName { get; set; }
        public double ReferenceAirKermaRate { get; set; }
        public System.DateTime SourceStrengthReferenceDateTime { get; set; }
        public int NumberOfSourcePositions { get; set; }
    
        public virtual RadiationHstry RadiationHstry { get; set; }
    }
}
