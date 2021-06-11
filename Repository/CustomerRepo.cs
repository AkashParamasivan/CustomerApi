using CustomerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApi.Repository
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly shopContext _context;


        public CustomerRepo()
        {

        }
        public CustomerRepo(shopContext context)
        {
            _context = context;
        }
        public IEnumerable<Customer> GetCustomer()
        {
            return _context.Customers.ToList();
        }
        public Customer GetById(int id)
        {
            Customer bk = _context.Customers.FirstOrDefault(P => P.Custid == id);
            return bk;
        }

        

        public async Task<Customer> PostCustomer(Customer cust)
        {
            await _context.Customers.AddAsync(cust);
            _context.SaveChanges();
            return cust;

        }

        public async Task<Customer> DeleteCustomer(int id)
        {
            Customer sp = await _context.Customers.FindAsync(id);
            if (sp == null)
            {
                throw new NullReferenceException();
            }
            else
            {
                _context.Remove(sp);
                _context.SaveChanges();
            }
            return sp;

        }


        public async Task<Customer> PutCustomer(int id, Customer item)
        {
            Customer Sp = await _context.Customers.FindAsync(id);
            //Sp.Pid = item.Pid;
            Sp.CustomerName = item.CustomerName;
            Sp.Phoneno = item.Phoneno;
            Sp.Mailid = item.Mailid;
            
            _context.SaveChanges();
            return Sp;
        }
    }
}
