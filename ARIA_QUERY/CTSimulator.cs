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
    
    public partial class CTSimulator
    {
        public long ResourceSer { get; set; }
        public long SimulatorResourceSer { get; set; }
        public Nullable<System.DateTime> CalibrationDate { get; set; }
        public string CollimatorType { get; set; }
        public string MaterialType { get; set; }
    
        public virtual ImagingDevice ImagingDevice { get; set; }
        public virtual Simulator Simulator { get; set; }
    }
}
