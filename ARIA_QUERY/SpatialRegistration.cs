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
    
    public partial class SpatialRegistration
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SpatialRegistration()
        {
            this.SpatialRegistrationImages = new HashSet<SpatialRegistrationImage>();
        }
    
        public long SpatialRegistrationSer { get; set; }
        public long SpatialRegistrationIODSer { get; set; }
        public string FrameOfReferenceUID { get; set; }
        public string Comment { get; set; }
        public string RegTypeCodeValue { get; set; }
        public string RegTypeCodeMeaning { get; set; }
        public string RegTypeCodeDesignator { get; set; }
        public string RegTypeCodeVersion { get; set; }
        public string RegSubType { get; set; }
        public byte[] Transformation { get; set; }
        public Nullable<double> AverageErrorDist { get; set; }
        public Nullable<double> MaxErrorDist { get; set; }
        public string MatchAlgorithm { get; set; }
        public string Status { get; set; }
        public System.DateTime StatusDate { get; set; }
        public string StatusUserName { get; set; }
        public string HstryUserName { get; set; }
        public byte[] HstryTimeStamp { get; set; }
        public System.DateTime HstryDateTime { get; set; }
        public string HstryTaskName { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SpatialRegistrationImage> SpatialRegistrationImages { get; set; }
        public virtual SpatialRegistrationIOD SpatialRegistrationIOD { get; set; }
    }
}
