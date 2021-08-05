using Management.Business.Abstract;
using Management.DataAccessLayer.Context;
using Management.DataAccessLayer.DataTransferObject.EmployerDTO;
using Management.DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Business.Concrete
{
    public class EmployerService : IEmployerService
    {
        public ManagementDatabaseContext _managementDatabaseContext;
        public EmployerService(ManagementDatabaseContext managementDatabaseContext)
        {
            _managementDatabaseContext = managementDatabaseContext;
        }
        public int AddEmployer(EmployerAddDTO employer)
        {
            var newEmployer = new Employer
            {
                Name = employer.Name,
                Surname = employer.Surname,
                Position = employer.Position
            };
            _managementDatabaseContext.Employers.Add(newEmployer);
            return _managementDatabaseContext.SaveChanges();

        }

        public int DeleteEmployer(int Id)
        {
            var currentEmployer = _managementDatabaseContext.Employers
                .Where(p => !p.IsDeleted && p.Id == Id).FirstOrDefault();
            currentEmployer.IsDeleted = true;
            _managementDatabaseContext.Employers.Update(currentEmployer);
            return _managementDatabaseContext.SaveChanges();
            
        }

        public List<EmployerListDTO> ListEmployer()
        {
            return _managementDatabaseContext.Employers.Where(p => !p.IsDeleted)
                .Select(p => new EmployerListDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Surname = p.Surname,
                    Position = p.Position,

                }).ToList();
            
        }

        public int UpdateEmployer(EmployerUpdateDTO employer)
        {
            var currentEmployer = _managementDatabaseContext.Employers
                .Where(p => !p.IsDeleted && p.Id == employer.Id).FirstOrDefault();
            if (currentEmployer == null)
            {
                return 0;
            }
            currentEmployer.Name = employer.Name;
            currentEmployer.Surname = employer.Surname;
            currentEmployer.Position = employer.Position;
            _managementDatabaseContext.Employers.Update(currentEmployer);
            return _managementDatabaseContext.SaveChanges();
        }
    }
}
