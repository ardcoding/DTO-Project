using BusinessServices.Layer.Interface;
using Microsoft.AspNetCore.Mvc;
using CommerceDb.Entities;
using CommerceApi.DTO;
using AutoMapper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class CustomersController : ControllerBase
    {
        private readonly ICustomerBusiness _customerBusiness;
        private readonly IMapper _mapper;
        public CustomersController(ICustomerBusiness customerBusiness,IMapper mapper)
        {
            _customerBusiness = customerBusiness;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<List<CustomerDTO>> GetCustomers()
        {
            var customer = await _customerBusiness.GetCustomers();
            return _mapper.Map<List<CustomerDTO>>(customer);
        }
        [HttpGet("{id}")]
        public async Task<CustomerDTO> GetCustomerById(int id)
        {
            var customer = await _customerBusiness.GetCustomerById(id);
            return _mapper.Map<CustomerDTO>(customer);
        }

        [HttpGet("ByName/{name}")]
        public async Task<CustomerDTO> GetCustomerByName(string name)
        {
            var customer = await _customerBusiness.GetCustomerByName(name);
            return _mapper.Map<CustomerDTO>(customer);
        }
        [HttpPost("AddCustomer")]
        public IActionResult AddCustomer([FromBody] CustomerDTO customerdto) 
        {
            Customer customer = _mapper.Map<Customer>(customerdto);
            _customerBusiness.AddCustomer(customer);
            return Ok(customer);
        }
        [HttpPut("UpdateCustomer")]
        public IActionResult UpdateCustomer([FromBody] Customer customer) {
            _customerBusiness.UpdateCustomer(customer);
            return Ok(customer);
        }

        [HttpDelete("DeleteCustomer/{id}")]
        public async Task DeleteCustomer(int id) { 
           await _customerBusiness.DeleteCustomer(id);
        }
    }
}
