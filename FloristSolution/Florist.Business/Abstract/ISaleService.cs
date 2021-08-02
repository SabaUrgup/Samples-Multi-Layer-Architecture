using Florist.DataAccessLayer.DataTransferObject.SaleDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Florist.Business.Abstract
{
    public interface ISaleService
    {
        /// <summary>
        /// Satış ekleme metodu
        /// </summary>
        Task<int> AddSale(SaleAddDTO sale);

        /// <summary>
        /// Mevcut satış güncelleme metodu
        /// </summary>
        Task<int> UpdateSale(SaleUpdateDTO sale);

        /// <summary>
        /// Mevcut satış silme
        /// </summary>
        Task<int> DeleteSale(int Id);

        /// <summary>
        /// Satış listeleme
        /// </summary>
        Task<List<SaleListDTO>> ListSale();
    }
}
