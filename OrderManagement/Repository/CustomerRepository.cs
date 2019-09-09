using OrderManagement.DAL;
using OrderManagement.Interfaces;
using System;
using System.Linq;

namespace OrderManagement.Repository
{
    /// <summary>
    /// Implementation for ICustomerRepository
    /// Uses Data Access Layer to create and get the data
    /// </summary>
    public class CustomerRepository : ICustomerRepository
    {
        /// <summary>
        /// Checks if customer is valid in database
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns>If customer id is valid then true otherwise false</returns>
        public bool isValidCustomer(Guid customerId)
        {
            // Get data using Entity Framework
            using (SEIEntities context = new SEIEntities())
            {
                // check if any record exist with customer id
                return context.Customers.Any(i => i.CustomerId == customerId);                
            }
        }
    }
}