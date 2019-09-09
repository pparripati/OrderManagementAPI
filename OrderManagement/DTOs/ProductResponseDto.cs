using Newtonsoft.Json;
using System;

namespace OrderManagement.DTOs
{
    /// <summary>
    /// Data Transfer Object used for response of a Product
    /// </summary>
    public class ProductResponseDto
    {
        [JsonProperty(PropertyName = "productId")]
        public Guid ProductId { get; set; }

        [JsonProperty(PropertyName = "productName")]
        public string ProductName { get; set; }

        [JsonProperty(PropertyName = "pricePerItem")]
        public double PricePerItem { get; set; }

        [JsonProperty(PropertyName = "averageCustomerRating")]
        public double? AverageCustomerRating { get; set; }
    }
}