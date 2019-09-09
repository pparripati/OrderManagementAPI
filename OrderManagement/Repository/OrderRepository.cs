using OrderManagement.DAL;
using OrderManagement.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderManagement.Repository
{
    /// <summary>
    /// Implementation for IOrderRepository
    /// Uses Data Access Layer to create and get the data
    /// </summary>
    public class OrderRepository : IOrderRepository
    {
        /// <summary>
        /// Creates a new order in database
        /// </summary>
        /// <param name="orderRequest">Order Model object with details</param>
        /// <returns>Order id (Guid)</returns>
        public Guid Add(Models.Order orderRequest)
        {
            // generate a new order id
            Guid orderId = Guid.NewGuid();

            // Get data using Entity Framework
            using (SEIEntities context = new SEIEntities())
            {
                context.Orders.Add(new Order
                {
                    OrderId = orderId,
                    ProductId = orderRequest.ProductId,
                    CustomerId = orderRequest.CustomerId,
                    OrderDate = orderRequest.OrderDate,
                    Quantity = orderRequest.Quantity,
                    PricePaid = orderRequest.PricePaid,
                    ShippedDate = orderRequest.ShippedDate,
                    // populate standard audit fields
                    CreationDate = DateTime.Now,
                    CreationUser = "OrderManagementAPI",
                    LastUpdateDate = DateTime.Now,
                    LastUpdateUser = "OrderManagementAPI"
                });

                // save the data to order table
                context.SaveChanges();

                // return the order id created
                return orderId;
            }
        }

        /// <summary>
        /// Gets all orders that are not shipped (have shipped date as null in order table)
        /// </summary>
        /// <returns>Orders List</returns>
        public List<Models.Order> GetPendingOrders()
        {
            // Get data using Entity Framework
            using (SEIEntities context = new SEIEntities())
            {
                // ObjectSet<Order> orders = context.Orders;

                // get the pending orders which are not shipped
                // check based on shipped date. If there is no date then the order is not shipped
                return context.Orders
                                .Where(i => i.ShippedDate == null)
                                .Select(i => new Models.Order
                                {
                                    OrderId = i.OrderId,
                                    ProductId = i.ProductId,
                                    CustomerId = i.CustomerId,
                                    CustomerName = i.Customer.CustomerName, // get the customer name based on the foreign key relationship
                                    OrderDate = i.OrderDate,
                                    Quantity = i.Quantity,
                                    PricePaid = i.PricePaid
                                })
                                .ToList();
            }
        }
    }
}