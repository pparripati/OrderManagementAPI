using OrderManagement.DAL;
using OrderManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderManagement.Repository
{
    /// <summary>
    /// Implementation for IProductInterface
    /// Uses Data Access Layer to create and get the data
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        /// <summary>
        /// Gets all products sorted by average rating by custimer highest to lowest
        /// </summary>
        /// <returns>List of products</returns>
        public List<Models.Product> GetProductsByRating()
        {
            // Get data using Entity Framework
            using (SEIEntities context = new SEIEntities())
            {                
                // map the data to Product Model before returning
                return context.Products
                        .OrderByDescending(i => i.AverageCustomerRating) // sort by ratings best on top
                        .Select(i => new Models.Product
                        {
                            ProductId = i.ProductId,
                            ProductName = i.ProductName,
                            PricePerItem = i.PricePerItem,
                            AverageCustomerRating = i.AverageCustomerRating
                        })
                        .ToList();
            }                
        }

        /// <summary>
        /// Checks if product is valid in database
        /// </summary>
        /// <param name="productId">Product Id (Guid)</param>
        /// <returns>If product is valid then true otherwise false</returns>
        public bool isValidProduct(Guid productId)
        {
            using (SEIEntities context = new SEIEntities())
            {
                // check if any matching product exist based on product id
                return context.Products.Any(i => i.ProductId == productId);               
            }
        }
    }
}