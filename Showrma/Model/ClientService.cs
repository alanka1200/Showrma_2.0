//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Showrma.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class ClientService
    {
        public int Id { get; set; }
        public Nullable<int> ClientId { get; set; }
        public Nullable<int> ServiceId { get; set; }
        public Nullable<System.DateTime> StartTime { get; set; }
    
        public virtual Client Client { get; set; }
        public virtual Service Service { get; set; }
    }
}
