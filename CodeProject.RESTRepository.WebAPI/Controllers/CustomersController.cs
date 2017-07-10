using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CodeProject.RESTRepository.Data.Entities;
using CodeProject.RESTRepository.Data.Repository;
using Microsoft.AspNetCore.Cors;
using System;
using System.Diagnostics;
using System.Linq;
using System.Web.Http;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeProject.RESTRepository.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    public class CustomersController : Controller
    {
        #region properties
        ICustomerRepository Customers
        {
            get; set;
        }
        // minimum page size
        protected int minPSize = 10;
        #endregion properties

        #region constructor
        public CustomersController(ICustomerRepository customersRepo)
        {
            this.Customers = customersRepo;
            Debug.WriteLine(string.Format(
                "\n\nCustomersController.cs Debug.WriteLine{0}\n\n",
                DateTime.Now.ToLocalTime())
                );
            //Output.WriteLine("CustomersController.cs Output.WriteLine");
            Console.WriteLine(string.Format(
                "\n\nCustomersController.cs {0}\n\n",
                DateTime.Now.ToLocalTime()));
        }
        #endregion constructor

        // GET: api/values
        [HttpGet]
        //public IEnumerable<Customers> Get()
        public IActionResult Get([FromUri]int? pageSize, [FromUri] int? pageNumber)
        {
            Debug.WriteLine(string.Format(
                "\n\nCustomersGet.cs Debug.WriteLine {0}\n\n",
                DateTime.Now.ToLocalTime()
                ));
            //Output.WriteLine("CustomersGet.cs Output.WriteLine");
            Console.WriteLine(string.Format(
                "\n\nCustomersGet.cs {0}\n\n",
                DateTime.Now.ToLocalTime()
                ));

            int pSize = 0;
            if (null == pageSize || pageSize == 0 || pageSize <= minPSize)
            {
                pSize = minPSize;
            }
            else
            {
                pSize = (int)pageSize;
            }

            int pNum = 0;
            if (null == pageNumber || pageNumber == 0 || pageNumber <= 0)
            {
                pageNumber = 1;
            }
            else
            {
                pNum = (int)pageNumber;
            }

            var custs = this.Customers.GetAll()
                .Skip<Customers>((pSize * (pNum - 1)))
                .Take<Customers>(pSize);

            Console.WriteLine(string.Format(
                "\n\nCustomersGet.cs {0}\nThere are {1} customers in result set\n\n",
                DateTime.Now.ToLocalTime().ToString(),
                custs.Count().ToString()
                ));

            var result = new OkObjectResult(custs);
            return result;
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "Get Customer")]
        public IActionResult Get(int id)
        {
            var cust = this.Customers.GetByID(id);
            IActionResult result = default(IActionResult);
            if (cust == null)
            {
                result = new NotFoundObjectResult(
                    string.Format("Customer {0} not found!", id.ToString())
                    );
            }
            else
            {
                result = new ObjectResult(cust);
            }
            return result;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
