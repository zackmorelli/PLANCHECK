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
    
    public partial class SlicePortalDoseAnalysi
    {
        public long SlicePortalDoseAnalysisSer { get; set; }
        public long PortalDoseAnalysisSer { get; set; }
        public long SliceSer { get; set; }
        public int DoseImageRole { get; set; }
    
        public virtual PortalDoseAnalysi PortalDoseAnalysi { get; set; }
        public virtual Slouse Slouse { get; set; }
    }
}
