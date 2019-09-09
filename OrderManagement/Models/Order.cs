using System;
using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Models
{
    /// <summary>
    /// Model object used in repository
    /// </summary>
    public class Order
    {
        [Required]
        public Guid OrderId { get; set; }

        [Required]
        public Guid ProductId { get; set; }

        [Required]
        public Guid CustomerId { get; set; }

        public string CustomerName { get; internal set; }
        public DateTime? OrderDate { get; set; }
        public int? Quantity { get; set; }
        public double? PricePaid { get; set; }
        public DateTime? ShippedDate { get; set; }        
    }
}