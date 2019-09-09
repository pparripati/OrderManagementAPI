using OrderManagement.Models;
using System;
using System.Collections.Generic;

namespace OrderManagement.Interfaces
{
    /// <summary>
    /// Interface for Order Repository
    /// </summary>
    public interface IOrderRepository
    {
        /// <summary>
        /// Creates a new order in database
        /// </summary>
        /// <param name="orderRequest">Order Model object with details</param>
        /// <returns>Order id (Guid)</returns>
        Guid Add(Order orderRequest);

        /// <summary>
        /// Gets all orders that are not shipped (have shipped date as null in order table)
        /// </summary>
        /// <returns>Orders List</returns>
        List<Order> GetPendingOrders();
    }
}
