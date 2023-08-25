using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommerceDb.Entities;
using DataAccess.Layer.Interface;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Layer.Concrete
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CommerceDbContext _dbcontext;

        public CustomerRepository(CommerceDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<List<Customer>> GetCustomers()
        {
            return await _dbcontext.Customers.ToListAsync();
        }
        public async Task<Customer> GetCustomerById(int id)
        {
            return await _dbcontext.Customers.FindAsync(id);
        }
        public async Task<Customer> GetCustomerByName(string name)
        {
            return await _dbcontext.Customers.FirstOrDefaultAsync(u=>u.Name == name);
        }
        public async Task<Customer> AddCustomer(Customer customer)
        {
           _dbcontext.Customers.Add(customer);
           await _dbcontext.SaveChangesAsync();
            return customer;
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            _dbcontext.Customers.Update(customer);
            await _dbcontext.SaveChangesAsync();
            return customer;
        }

        public async Task DeleteCustomer(int id)
        {
            var deletedCustomer = await _dbcontext.Customers.FindAsync(id);
            _dbcontext.Customers.Remove(deletedCustomer);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
