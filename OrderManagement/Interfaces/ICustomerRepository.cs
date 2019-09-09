using System;

namespace OrderManagement.Interfaces
{
    /// <summary>
    /// Interface for Customer Repository
    /// </summary>
    public interface ICustomerRepository
    {
        /// <summary>
        /// Checks if customer is valid in database
        /// </summary>
        /// <param name="customerId">Customer  Id (Guid)</param>
        /// <returns>If customer id is valid then true otherwise false</returns>
        bool isValidCustomer(Guid customerId);
    }
}