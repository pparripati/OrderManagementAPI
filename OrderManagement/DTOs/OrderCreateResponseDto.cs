using Newtonsoft.Json;
using System;

namespace OrderManagement.DTOs
{
    /// <summary>
    /// Data Transfer Object used for response after a new order is created
    /// </summary>
    public class OrderCreateResponseDto
    {
        [JsonProperty(PropertyName = "orderId")]
        public Guid OrderId { get; set; }
    }
}