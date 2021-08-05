using Management.DataAccessLayer.DataTransferObject.EmployeeDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Business.Abstract
{
    public interface IEmployeeService
    {
        /// <summary>
        /// İşçi ekleme metodu
        /// </summary>
        public int AddEmployee(EmployeeAddDTO employee);

        /// <summary>
        /// Mevcut işçi güncelleme metodu
        /// </summary>
        public int UpdateEmployee(EmployeeUpdateDTO employee);

        /// <summary>
        /// Mevcut işçi silme
        /// </summary>
        public int DeleteEmployee(int Id);

        /// <summary>
        /// İşçi listeleme
        /// </summary>
        public List<EmployeeListDTO> ListEmployee();

    }
}

