using Newtonsoft.Json;
using System;

namespace OrderManagement.DTOs
{
    /// <summary>
    /// Data Transfer Object used for response for order that is not yet shipped
    /// </summary>
    public class OrderPendingResponseDto
    {
        [JsonProperty(PropertyName = "customerId")]
        public Guid CustomerId { get; set; }

        [JsonProperty(PropertyName = "customerName")]
        public string CustomerName { get; set; }

        [JsonProperty(PropertyName = "orderId")]
        public Guid OrderId { get; set; }

        [JsonProperty(PropertyName = "orderDate")]
        public DateTime? OrderDate { get; set; }

        [JsonProperty(PropertyName = "quantity")]
        public int? Quantity { get; set; }

        [JsonProperty(PropertyName = "pricePaid")]
        public double? PricePaid { get; set; }
    }
}