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
    
    public partial class Service
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Service()
        {
            this.ClientService = new HashSet<ClientService>();
        }
    
        public int Id { get; set; }
        public string Title { get; set; }
        public Nullable<decimal> Cost { get; set; }
        public Nullable<int> DurationInSeconds { get; set; }
        public string Description { get; set; }
        public Nullable<double> Discount { get; set; }
        public byte[] MainImagePath { get; set; }
        public Nullable<bool> IsDelete { get; set; }
        public byte[] MainLogo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ClientService> ClientService { get; set; }
    }
}
