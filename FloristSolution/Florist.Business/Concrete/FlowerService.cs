using Florist.Business.Abstract;
using Florist.DataAccessLayer.Context;
using Florist.DataAccessLayer.DataTransferObject.FlowerDTO;
using Florist.DataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Florist.Business.Concrete
{
    public class FlowerService : IFlowerService
    {
        private readonly FloristDatabaseContext _floristDatabaseContext;

        public FlowerService(FloristDatabaseContext floristDatabaseContext)
        {
            _floristDatabaseContext = floristDatabaseContext;
        }

        public async Task<int> AddFlower(FlowerAddDTO flower)
        {
            var newFlower = new Flower
            {
                Name = flower.Name,
                Specification = flower.Specification,
                Price = flower.Price,
                FlowerCategoryId = flower.FlowerCategoryId,
            };
            await _floristDatabaseContext.Flowers.AddAsync(newFlower);
            return await _floristDatabaseContext.SaveChangesAsync();
        }

        public async Task<int> DeleteFlower(int Id)
        {
            var currentFlower = await _floristDatabaseContext.Flowers
                .Where(p => !p.IsDeleted && p.Id == Id).FirstOrDefaultAsync();
            if(currentFlower == null)
            {
                return 0;
            }
            currentFlower.IsDeleted = true;

            _floristDatabaseContext.Flowers.Update(currentFlower);
            return await _floristDatabaseContext.SaveChangesAsync();
        }

        public async Task<List<FlowerListDTO>> ListFlower()
        {
           return await _floristDatabaseContext.Flowers
                .Where(p => !p.IsDeleted)
                .Include(p => p.FlowerCategoryFK)
                .Select(p => new FlowerListDTO
                {
                     Id = p.Id,
                     Name = p.Name,
                     Specification = p.Specification,
                     Price = p.Price,
                     FlowerCategoryName = p.FlowerCategoryFK.Name
                }).ToListAsync();
        }

        public async Task<int> UpdateFlower(FlowerUpdateDTO flower)
        {
            var currentFlower = await _floristDatabaseContext.Flowers
                .Where(p => !p.IsDeleted && p.Id == flower.Id).FirstOrDefaultAsync();
            if(currentFlower == null)
            {
                return 0;
            }
            currentFlower.Name = flower.Name;
            currentFlower.Price = flower.Price;
            currentFlower.Specification = flower.Specification;
            currentFlower.FlowerCategoryId = flower.FlowerCategoryId;
            _floristDatabaseContext.Flowers.Update(currentFlower);
            return await _floristDatabaseContext.SaveChangesAsync();
        }

        public async Task<FlowerGetDTO> GetFlowerById(int Id)
        {
            return await _floristDatabaseContext.Flowers
                .Where(p => !p.IsDeleted && p.Id == Id)
                .Include(p => p.FlowerCategoryFK)
                .Select(p => new FlowerGetDTO
                {
                    Name = p.Name,
                    Price = p.Price,
                    Specification = p.Specification,
                    FlowerCategoryName = p.FlowerCategoryFK.Name
                }).FirstOrDefaultAsync(); 
        }
    }
}
        