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
    
    public partial class LookupServiceCache
    {
        public long LookupServiceCacheSer { get; set; }
        public string LookupName { get; set; }
        public string LookupType { get; set; }
        public int CacheInClient { get; set; }
        public int CacheInServer { get; set; }
        public int ClientCacheExpiryMinutes { get; set; }
        public int ServerCacheExpiryMinutes { get; set; }
        public string LookupQuery { get; set; }
    }
}
