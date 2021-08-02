
using Florist.DataAccessLayer.DataTransferObject.FlowerDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Florist.Business.Abstract
{
    public interface IFlowerService
    {

        /// <summary>
        /// Çiçek ekleme metodu
        /// </summary>
        Task<int> AddFlower(FlowerAddDTO flower);

        /// <summary>
        /// Mevcut çiçek güncelleme metodu
        /// </summary>
        Task<int> UpdateFlower(FlowerUpdateDTO flower);

        /// <summary>
        /// Mevcut çiçek silme
        /// </summary>
        Task<int> DeleteFlower(int Id);

        /// <summary>
        /// Çiçek listeleme
        /// </summary>
        Task<List<FlowerListDTO>> ListFlower();
        Task<FlowerGetDTO> GetFlowerById(int Id);
    }
}
