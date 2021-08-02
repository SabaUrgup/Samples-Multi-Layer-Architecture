using Florist.Business.Abstract;
using Florist.DAL.Entity;
using Florist.DataAccessLayer.Context;
using Florist.DataAccessLayer.DataTransferObject.FlowerCategoryDTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Florist.Business.Concrete
{
    public class FlowerCategoryService : IFlowerCategoryService
    {
        private readonly FloristDatabaseContext _floristDatabaseContext;
        public FlowerCategoryService(FloristDatabaseContext floristDatabaseContext)
        {
            _floristDatabaseContext = floristDatabaseContext;
        }
        public async Task<int> AddFlowerCategory(FlowerCategoryAddDTO flowerCategory)
        {
            var newFlowerCategory = new FlowerCategory
            {
                Name = flowerCategory.Name
            };
            await _floristDatabaseContext.FlowerCategories.AddAsync(newFlowerCategory);
            return await _floristDatabaseContext.SaveChangesAsync();
        }

        public async Task<int> DeleteFlowerCategory(int Id)
        {
            var currentCategory = await _floristDatabaseContext.FlowerCategories
                .Where(p => !p.IsDeleted && p.Id == Id).FirstOrDefaultAsync();
            if (currentCategory == null)
            {
                return 0;
            }
            currentCategory.IsDeleted = true;
            _floristDatabaseContext.FlowerCategories.Update(currentCategory);
            return await _floristDatabaseContext.SaveChangesAsync();
        }

        public async Task<List<FlowerCategoryListDTO>> ListFlowerCategory()
        {
            return await _floristDatabaseContext.FlowerCategories.Where(p => !p.IsDeleted)
                .Select(p => new FlowerCategoryListDTO
                {
                    Id = p.Id,
                    Name = p.Name,
                })
                 .ToListAsync();
        }

        public async Task<int> UpdateFlowerCategory(FlowerCategoryUpdateDTO flowerCategory)
        {
            var currentCategory = await _floristDatabaseContext.FlowerCategories
                    .Where(p => !p.IsDeleted && p.Id == flowerCategory.Id).FirstOrDefaultAsync();
            if (currentCategory == null)
            {
                return 0;
            }
            currentCategory.Name = flowerCategory.Name;
            return await _floristDatabaseContext.SaveChangesAsync();
        } 
    }
}
