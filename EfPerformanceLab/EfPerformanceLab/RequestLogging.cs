//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EfPerformanceLab
{
    using System;
    using System.Collections.Generic;
    
    public partial class RequestLogging
    {
        public int Id { get; set; }
        public System.DateTime RequestTime { get; set; }
        public Nullable<int> OperationId { get; set; }
        public string IpAddress { get; set; }
        public Nullable<int> UserId { get; set; }
        public string RequestStatus { get; set; }
    
        public virtual Operation Operation { get; set; }
        public virtual User User { get; set; }
    }
}
