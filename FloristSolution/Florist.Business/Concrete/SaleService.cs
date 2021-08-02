using Florist.Business.Abstract;
using Florist.DataAccessLayer.Context;
using Florist.DataAccessLayer.DataTransferObject.SaleDTO;
using Florist.DataAccessLayer.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Florist.Business.Concrete
{
    public class SaleService : ISaleService
    {
        private readonly FloristDatabaseContext _floristDatabaseContext;
        public SaleService(FloristDatabaseContext floristDatabaseContext)
        {
            _floristDatabaseContext = floristDatabaseContext;
        }

        public async Task<int> AddSale(SaleAddDTO sale)
        {
            var newSale = new Sale
            {

            };
            await _floristDatabaseContext.Sales.AddAsync(newSale);
            return await _floristDatabaseContext.SaveChangesAsync();
        }
        public async Task<int> DeleteSale(int Id)
        {
            var currentSale = await _floristDatabaseContext.Sales
                .Where(p => !p.IsDeleted && p.Id == Id).FirstOrDefaultAsync();
            if (currentSale == null)
            {
                return 0;
            }
            currentSale.IsDeleted = true;
            _floristDatabaseContext.Sales.Update(currentSale);
            return await _floristDatabaseContext.SaveChangesAsync();
        }

        public async Task<List<SaleListDTO>> ListSale()
        {
            return await _floristDatabaseContext.Sales.Where(p => !p.IsDeleted)
                .Select(p => new SaleListDTO
                {
                    Id = p.Id,
                })
                 .ToListAsync();
        }

        public async Task<int> UpdateSale(SaleUpdateDTO sale)
        {
            var currentSale = await _floristDatabaseContext.Sales
              .Where(p => !p.IsDeleted && p.Id == sale.Id).FirstOrDefaultAsync();
            if (currentSale == null)
            {
                return 0;
            }
            return await _floristDatabaseContext.SaveChangesAsync();
        }
    }
}
