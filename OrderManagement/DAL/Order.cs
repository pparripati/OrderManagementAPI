//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrderManagement.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order
    {
        public System.Guid OrderId { get; set; }
        public System.Guid ProductId { get; set; }
        public System.Guid CustomerId { get; set; }
        public Nullable<System.DateTime> OrderDate { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<double> PricePaid { get; set; }
        public Nullable<System.DateTime> ShippedDate { get; set; }
        public Nullable<System.DateTime> CreationDate { get; set; }
        public string CreationUser { get; set; }
        public Nullable<System.DateTime> LastUpdateDate { get; set; }
        public string LastUpdateUser { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
    }
}