using Business.Abstracts;
using Business.Dtos.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {

        private readonly ICustomerService _customerService;

        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_customerService.GetAll());
        }

        [HttpPost]
        public IActionResult Add(CreateCustomerRequest createCustomerRequest)
        {
            return Ok(_customerService.Add(createCustomerRequest));
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult GetById([FromRoute] int id)
        {
            if (_customerService.GetById(id) == null)
            {
                return NotFound("There is no customer with given ID");
            }
            return Ok(_customerService.GetById(id));
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            string result = _customerService.Delete(id);
            if (result == null)
            {
                return NotFound("There is no customer with given Id");
            }
            return Ok(result);
        }

    }
}
