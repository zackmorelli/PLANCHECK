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
    
    public partial class ImportExportTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ImportExportTable()
        {
            this.ImportExportColumns = new HashSet<ImportExportColumn>();
        }
    
        public string TableName { get; set; }
        public string PreprocessingMethodName { get; set; }
        public string PostprocessingMethodName { get; set; }
        public int CheckObjectStatusOnExport { get; set; }
        public string InsertionStoredProcedure { get; set; }
        public int ContinueIfInsertFails { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ImportExportColumn> ImportExportColumns { get; set; }
    }
}
