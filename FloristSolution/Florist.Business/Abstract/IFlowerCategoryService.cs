using Florist.DataAccessLayer.DataTransferObject.FlowerCategoryDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Florist.Business.Abstract
{
    public interface IFlowerCategoryService
    { 
        Task<int> AddFlowerCategory(FlowerCategoryAddDTO flowerCategory);
        Task<int> UpdateFlowerCategory(FlowerCategoryUpdateDTO flowerCategory);
        Task<int> DeleteFlowerCategory(int Id);
        Task<List<FlowerCategoryListDTO>> ListFlowerCategory();
    }
}
