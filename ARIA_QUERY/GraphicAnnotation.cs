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
    
    public partial class GraphicAnnotation
    {
        public long GraphicAnnotationSer { get; set; }
        public long GraphicAnnotationTypeSer { get; set; }
        public long ImageSer { get; set; }
        public string GraphicAnnotationId { get; set; }
        public string GraphicAnnotationName { get; set; }
        public string Comment { get; set; }
        public Nullable<long> MaterialSer { get; set; }
        public string FileName { get; set; }
        public string HstryUserName { get; set; }
        public byte[] HstryTimeStamp { get; set; }
        public System.DateTime HstryDateTime { get; set; }
        public string HstryTaskName { get; set; }
    
        public virtual GraphicAnnotationType GraphicAnnotationType { get; set; }
        public virtual Image Image { get; set; }
        public virtual Material Material { get; set; }
    }
}
