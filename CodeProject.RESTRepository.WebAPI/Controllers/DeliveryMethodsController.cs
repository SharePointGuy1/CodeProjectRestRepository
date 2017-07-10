using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CodeProject.RESTRepository.Data.Repository;
using CodeProject.RESTRepository.Data.Entities;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CodeProject.RESTRepository.WebAPI.Controllers
{
    [Route("api/[controller]")]
    public class DeliveryMethodsController : Controller
    {
        #region properties
        IDeliveryMethodRepository DeliveryMethods
        {
            get; set;
        }
        #endregion properties

        #region constructor
        public DeliveryMethodsController(IDeliveryMethodRepository deliveryMethodsRepo)
        {
            this.DeliveryMethods = deliveryMethodsRepo;
        }
        #endregion constructor

        // GET: api/values
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<DeliveryMethods> deliveryMethods = DeliveryMethods.GetAll();
            IActionResult result = default(IActionResult);
            if (!deliveryMethods.Any<DeliveryMethods>())
            {
                result = new NotFoundObjectResult("No delivery method found!");
            }
            else
            {
                result = new OkObjectResult(deliveryMethods);
            }
            return result;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var deliveryMethod = this.DeliveryMethods.GetByID(id);
            IActionResult result = default(IActionResult);
            if (deliveryMethod == null)
            {
                result = new NotFoundObjectResult(
                    string.Format("DeliveryMethods Method {0} not found!!!", id.ToString())
                    );
            }
            else
            {
                result = new ObjectResult(deliveryMethod);
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
