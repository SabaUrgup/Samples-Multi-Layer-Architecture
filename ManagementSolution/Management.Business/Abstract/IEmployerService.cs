
using Management.DataAccessLayer.DataTransferObject.EmployerDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Business.Abstract
{
    public interface IEmployerService
    {
        /// <summary>
        /// İş veren ekleme metodu
        /// </summary>
        public int AddEmployer(EmployerAddDTO employer);

        /// <summary>
        /// Mevcut iş verenleri güncelleme metodu
        /// </summary>
        public int UpdateEmployer(EmployerUpdateDTO employer);

        /// <summary>
        /// Mevcut iş verenleri silme
        /// </summary>
        public int DeleteEmployer(int Id);

        /// <summary>
        /// İş verenleri listeleme
        /// </summary>
        public List<EmployerListDTO> ListEmployer();

    }
}
