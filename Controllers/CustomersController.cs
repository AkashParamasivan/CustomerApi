using CustomerApi.Models;
using CustomerApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepo _context;

        static readonly log4net.ILog log = log4net.LogManager.GetLogger(typeof(CustomersController));

        public CustomersController(ICustomerRepo context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
            log.Info("Get Customers Detail method is invoked");
            return _context.GetCustomer();
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var temppro = _context.GetById(id);


            if (temppro == null)
            {
                log.Info("id not found");
                return NotFound();
            }
            log.Info("Get Customer with id " + id + " is invoked");
            return Ok(temppro);
        }

        [HttpPost("PostCustomer")]

        public async Task<IActionResult> PostCustomers(Customer cust)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var value = await _context.PostCustomer(cust);
            log.Info("Post Customers Detail method is invoked");
            return Ok(value);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProducts(int id, Customer customer)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var editedCustomer = await _context.PutCustomer(id, customer);

            log.Info(" Customer with id " + id + "got updated");
            return Ok(editedCustomer);
        }

        [HttpDelete("DeleteCustomer")]
        public async Task<IActionResult> DeleteCustomers(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var deletedCustomer = await _context.DeleteCustomer(id);
            log.Info(" Customer with id " + id + "got deleted");
            return Ok(deletedCustomer);
        }
    }
}
