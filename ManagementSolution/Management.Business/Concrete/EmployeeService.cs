using Management.Business.Abstract;
using Management.DataAccessLayer.Context;
using Management.DataAccessLayer.DataTransferObject.EmployeeDTO;
using Management.DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Business.Concrete
{
    public class EmployeeService : IEmployeeService
    {
        // databasecontext veri tabanı işlemleri ve bağlantıları için kullanılan sınıf
        public ManagementDatabaseContext _managementDatabaseContext;
        public EmployeeService(ManagementDatabaseContext managementDatabaseContext)
        {
            _managementDatabaseContext = managementDatabaseContext;
        }
        public int AddEmployee(EmployeeAddDTO employee)
        {
            var newEmployee = new Employee
            {
                Name = employee.Name,
                Surname = employee.Surname,
                No = employee.No,
            };
            _managementDatabaseContext.Employees.Add(newEmployee);
            return _managementDatabaseContext.SaveChanges();

        }

        public int DeleteEmployee(int Id)
        {
            var currentEmployee = _managementDatabaseContext.Employees
                .Where(p => !p.IsDeleted && p.Id == Id).FirstOrDefault();
            if (currentEmployee == null)
            {
                return 0;
            }
            currentEmployee.IsDeleted = true;
            _managementDatabaseContext.Employees.Update(currentEmployee);
            return _managementDatabaseContext.SaveChanges();
        }

        public List<EmployeeListDTO> ListEmployee()
        {
            return _managementDatabaseContext.Employees.Where(p => !p.IsDeleted)
                .Select(p => new EmployeeListDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                    Surname = p.Surname,
                    No = p.No,

                }).ToList();
        }

        public int UpdateEmployee(EmployeeUpdateDTO employee)
        {
            var currentEmployee = _managementDatabaseContext.Employees
                .Where(p => !p.IsDeleted && p.Id == employee.Id).FirstOrDefault();
            if (currentEmployee == null)
            {
                return 0;
            }
            currentEmployee.Name = employee.Name;
            currentEmployee.Surname = employee.Surname;
            currentEmployee.No = employee.No;
            _managementDatabaseContext.Employees.Update(currentEmployee);
            return _managementDatabaseContext.SaveChanges();
        }
    }
}
