using OrderManagement.DTOs;
using OrderManagement.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace OrderManagement.Controllers
{
    /// <summary>
    /// Provides all available end points related to Product
    /// </summary>
    public class ProductController : ApiController
    {
        private IProductRepository _productRepository;

        /// <summary>
        /// Public constructor. All parameters (repositories needed) are injected using DI 
        /// </summary>
        /// <param name="productRepository"></param>
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// Get all products available sorted by average customer rating (best on top)
        /// </summary>
        /// <returns>List of products</returns>
        [HttpGet]
        [Route("api/product")]
        public List<ProductResponseDto> GetProductsByRating()
        {
            // use a response DTO to return
            return _productRepository.GetProductsByRating()
                .Select(i => new ProductResponseDto
                {
                    ProductId = i.ProductId,
                    ProductName = i.ProductName,
                    PricePerItem = i.PricePerItem,
                    AverageCustomerRating = i.AverageCustomerRating
                }).ToList();            
        }
    }
}
