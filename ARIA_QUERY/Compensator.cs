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
    
    public partial class Compensator
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Compensator()
        {
            this.Matrices = new HashSet<Matrix>();
        }
    
        public long CompensatorSer { get; set; }
        public long RadiationSer { get; set; }
        public Nullable<long> AddOnMaterialSer { get; set; }
        public Nullable<long> TrayAddOnSer { get; set; }
        public string CompensatorId { get; set; }
        public string CompensatorName { get; set; }
        public string CompensatorType { get; set; }
        public int AboveTrayFlag { get; set; }
        public Nullable<double> FieldEdgeMargin { get; set; }
        public Nullable<double> ColumnOffset { get; set; }
        public int DivergingFlag { get; set; }
        public int DicomSeqNumber { get; set; }
        public string Comment { get; set; }
        public int Status { get; set; }
        public string HstryUserName { get; set; }
        public byte[] HstryTimeStamp { get; set; }
        public System.DateTime HstryDateTime { get; set; }
        public string HstryTaskName { get; set; }
        public string CustomCode { get; set; }
    
        public virtual AddOnMaterial AddOnMaterial { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Matrix> Matrices { get; set; }
        public virtual PhotonCompensator PhotonCompensator { get; set; }
        public virtual ProtonCompensator ProtonCompensator { get; set; }
        public virtual ExternalFieldCommon ExternalFieldCommon { get; set; }
        public virtual Tray Tray { get; set; }
    }
}
