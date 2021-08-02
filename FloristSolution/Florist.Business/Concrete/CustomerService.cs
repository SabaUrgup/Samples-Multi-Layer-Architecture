using Florist.Business.Abstract;
using Florist.DataAccessLayer.Context;
using Florist.DataAccessLayer.DataTransferObject.CustomerDTO;
using Florist.DataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Florist.Business.Concrete
{
    public class CustomerService : ICustomerService
    {
        // databasecontext veri tabanı işlemleri ve bağlantıları için kullanılan sınıf
        private readonly FloristDatabaseContext _floristDatabaseContext;
        public CustomerService(FloristDatabaseContext floristDatabaseContext)
        {
            _floristDatabaseContext = floristDatabaseContext;
        }

        public async Task<int> AddCustomer(CustomerAddDTO customer)
        {
            var newCustomer = new Customer
            {
                Name = customer.Name,
                Surname = customer.Surname,
                Email = customer.Email,
                TelNo = customer.TelNo,
            };
            await _floristDatabaseContext.Customers.AddAsync(newCustomer);
            return await _floristDatabaseContext.SaveChangesAsync();
        }

        public async Task<int> DeleteCustomer(int Id)
        {
            var currentCustomer = await _floristDatabaseContext.Customers
                .Where(p => !p.IsDeleted && p.Id == Id).FirstOrDefaultAsync();
            if(currentCustomer == null)
            {
                return 0;
            }
            currentCustomer.IsDeleted = true;
            _floristDatabaseContext.Customers.Update(currentCustomer);
            return await _floristDatabaseContext.SaveChangesAsync();
        }
        public async Task<List<CustomerListDTO>> ListCustomer()
        {
            return await _floristDatabaseContext.Customers.Where(p => !p.IsDeleted)
                .Select(p => new CustomerListDTO
                {
                    Id=p.Id,
                    Name = p.Name,
                    Surname = p.Surname,
                    Email = p.Email,
                    TelNo = p.TelNo,
                })
                 .ToListAsync();
        }    
            
        public async Task<int> UpdateCustomer(CustomerUpdateDTO customer)
        {
            var currentCustomer = await _floristDatabaseContext.Customers
                    .Where(p => !p.IsDeleted && p.Id == customer.Id).FirstOrDefaultAsync();
            if(currentCustomer == null)
            {
                return 0;
            }
            currentCustomer.Name = customer.Name;
            currentCustomer.Surname = customer.Surname;
            currentCustomer.TelNo = customer.TelNo;
            currentCustomer.Email = customer.Email;
            return await _floristDatabaseContext.SaveChangesAsync();

        }

    }
}
