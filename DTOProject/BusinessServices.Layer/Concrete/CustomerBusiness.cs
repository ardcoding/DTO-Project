using BusinessServices.Layer.Interface;
using DataAccess.Layer.Interface;
using CommerceDb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Channels;

namespace BusinessServices.Layer.Concrete
{
    public class CustomerBusiness : ICustomerBusiness
    {
        private readonly ICustomerRepository _repository;
        public CustomerBusiness(ICustomerRepository repository) { 
        _repository = repository;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            return await _repository.GetCustomers();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await _repository.GetCustomerById(id);
        }

        public async Task<Customer> GetCustomerByName(string name)
        {
            return await _repository.GetCustomerByName(name);
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {

            if (customer.Name.Length > 2)
            {
                return await _repository.AddCustomer(customer);
            }
            else
            {
                throw new Exception();
            }
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            var updateableHasCustomer = await _repository.GetCustomerById(customer.Id);
            if (updateableHasCustomer != null)
            {
                return await _repository.UpdateCustomer(customer);
            }
            else
            {
                throw new Exception();
            }
                
        }

        public async Task DeleteCustomer(int id)
        {
            var deletableHasCustomer = await _repository.GetCustomerById(id);
            if (deletableHasCustomer != null)
            {
                await _repository.DeleteCustomer(id);
            }
            else
            {
                throw new Exception();
            }
        }
    }
}
