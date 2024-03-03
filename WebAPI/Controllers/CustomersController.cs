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

    }
}
