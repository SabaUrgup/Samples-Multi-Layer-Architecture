using Florist.DataAccessLayer.DataTransferObject.CustomerDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Florist.Business.Abstract
{
    public interface ICustomerService
    {

        /// <summary>
        /// Müşteri ekleme metodu
        /// </summary>
        Task<int> AddCustomer(CustomerAddDTO customer);

        /// <summary>
        /// Mevcut müşteri güncelleme metodu
        /// </summary>
        Task<int> UpdateCustomer(CustomerUpdateDTO customer);

        /// <summary>
        /// Mevcut müşteri silme
        /// </summary>
        Task<int> DeleteCustomer(int Id);

        /// <summary>
        /// Müşteri listeleme
        /// </summary>
        Task<List<CustomerListDTO>> ListCustomer();
    }
}
