using System;
using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Models
{
    /// <summary>
    /// Model object used in repository
    /// </summary>
    public class Product
    {
        [Required]
        public Guid ProductId { get; set; }

        [Required]
        [MaxLength(255)]
        public string ProductName { get; set; }

        [Required]
        public double PricePerItem { get; set; }
        public double? AverageCustomerRating { get; set; }
    }
}
