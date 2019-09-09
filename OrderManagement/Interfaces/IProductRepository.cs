using OrderManagement.Models;
using System;
using System.Collections.Generic;

namespace OrderManagement.Interfaces
{
    /// <summary>
    /// Interface for Product repository
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Gets all products sorted by average rating by custimer highest to lowest
        /// </summary>
        /// <returns>List of products</returns>
        List<Product> GetProductsByRating();

        /// <summary>
        /// Checks if product is valid in database
        /// </summary>
        /// <param name="productId">Product Id (Guid)</param>
        /// <returns>If product is valid then true otherwise false</returns>
        bool isValidProduct(Guid productId);
    }
}
