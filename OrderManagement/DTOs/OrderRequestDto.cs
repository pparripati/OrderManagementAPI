using Newtonsoft.Json;
using System;

namespace OrderManagement.DTOs
{
    /// <summary>
    /// Data Transfer Object used for request to create a new order 
    /// </summary>
    public class OrderRequestDto
    {
        [JsonProperty(PropertyName = "productId")]
        public Guid ProductId { get; set; }

        [JsonProperty(PropertyName = "customerId")]
        public Guid CustomerId { get; set; }

        [JsonProperty(PropertyName = "orderDate")]
        public DateTime? OrderDate { get; set; }

        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }

        [JsonProperty(PropertyName = "pricePaid")]
        public double PricePaid { get; set; }

        [JsonProperty(PropertyName = "shippedDate")]
        public DateTime? ShippedDate { get; set; }
    }
}