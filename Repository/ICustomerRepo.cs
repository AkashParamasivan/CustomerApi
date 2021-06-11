using CustomerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApi.Repository
{
    public interface ICustomerRepo
    {
        IEnumerable<Customer> GetCustomer();

        Customer GetById(int id);

        Task<Customer> PostCustomer(Customer cust);

        Task<Customer> DeleteCustomer(int id);

        Task<Customer> PutCustomer(int id, Customer item);
    }
}
