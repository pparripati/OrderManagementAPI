using OrderManagement.DTOs;
using OrderManagement.Interfaces;
using OrderManagement.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace OrderManagement.Controllers
{
    /// <summary>
    /// Provides all available end points related to order
    /// </summary>
    public class OrdersController : ApiController
    {
        private IOrderRepository _orderRepository;
        private IProductRepository _productRepository;
        private ICustomerRepository _customerRepository;

        /// <summary>
        /// Public constructor. All parameters (repositories needed) are injected using DI 
        /// </summary>
        /// <param name="orderRepository"></param>
        /// <param name="productRepository"></param>
        /// <param name="customerRepository"></param>
        public OrdersController(IOrderRepository orderRepository, IProductRepository productRepository, ICustomerRepository customerRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _customerRepository = customerRepository;
        }

        /// <summary>
        /// Creates a order based on the JSON body
        /// Required fields Customer Id, Product id, Order date, quantity, price paid
        /// Customer Id and Product id must be a valid id present in system.
        /// HTTP Status 400 Bad Request is thrown if any of above condition fails        /// 
        /// 
        ///     Message Format
        ///     {
        ///        "productId" : "GUID",
        ///        "customerId" : "GUID",
        ///        "orderDate" : "mm/dd/yyyy",
        ///        "quantity": int,
        ///        "pricePaid": decimal
        ///     }
        /// 
        /// </summary>
        /// <param name="requestDto"></param>
        /// <returns>Order Id guid</returns>
        [HttpPost]
        [Route("api/order")]
        public OrderCreateResponseDto CreateOrder([FromBody] OrderRequestDto requestDto)
        {
            //Create order model object from dto
            var order = new Order
            {
                ProductId = requestDto.ProductId,
                CustomerId = requestDto.CustomerId,
                OrderDate = requestDto.OrderDate,
                Quantity = requestDto.Quantity,
                PricePaid = requestDto.PricePaid,
                ShippedDate = requestDto.ShippedDate
            };

            // apply all validation to make sure data is valid            
            if (!_customerRepository.isValidCustomer(order.CustomerId))
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Customer Id is required and valid customer Id must be provided"));

            if (!_productRepository.isValidProduct(order.ProductId))
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Product Id is required and valid product Id must be provided"));

            if (order.OrderDate == null)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Order date is required and valid order date must be provided"));

            if (order.Quantity < 1)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Quantity is required, must be integer value and greater than 0"));

            if (order.PricePaid < 1)
                throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Price paid is required, must be a decimal value and greater than 0"));
                       
            // return the Order id created using a response DTO
            return new OrderCreateResponseDto
            {
                OrderId = _orderRepository.Add(order)
            };
        }

        /// <summary>
        /// Gets list of orders that are not shipped (have shipped date as null in order table)
        /// </summary>
        /// <returns>List of orders</returns>
        [HttpGet]
        [Route("api/pendingorders")]
        public List<OrderPendingResponseDto> GetPendingOrders()
        {
            // use a response DTO to return
            return _orderRepository.GetPendingOrders()
                .Select(i => new OrderPendingResponseDto
                {
                    OrderId = i.OrderId,
                    CustomerId = i.CustomerId,
                    CustomerName = i.CustomerName,
                    OrderDate = i.OrderDate,
                    PricePaid = i.PricePaid,
                    Quantity = i.Quantity
                }).ToList();
        }
    }
}
