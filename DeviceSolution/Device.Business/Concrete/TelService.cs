using Device.Business.Abstract;
using Device.DataAccessLayer.Context;
using Device.DataAccessLayer.DataTransferObject.TelDTO;
using Device.DataAccessLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device.Business.Concrete
{
    public class TelService : ITelService
    {
        public DeviceDatabaseContext _deviceDatabaseContext;

        public TelService(DeviceDatabaseContext deviceDatabaseContext)
        {
            _deviceDatabaseContext = deviceDatabaseContext;
        }

        public int AddTel(TelAddDTO tel)
        {
            var newTel = new Tel
            {
                Brand = tel.Brand,
                Color = tel.Color,
            };
            _deviceDatabaseContext.Tels.Add(newTel);
            return _deviceDatabaseContext.SaveChanges();
        }

        public int DeleteTel(int Id)
        {
            var currentTel = _deviceDatabaseContext.Tels
                .Where(p => !p.IsDeleted && p.Id == Id).FirstOrDefault();
            if (currentTel == null)
            {
                return 0;
            }
            currentTel.IsDeleted = true;
            _deviceDatabaseContext.Tels.Update(currentTel);
            return _deviceDatabaseContext.SaveChanges();
        }

        public List<TelListDTO> ListTel()
        {
            return _deviceDatabaseContext.Tels.Where(p => !p.IsDeleted)
                .Select(p => new TelListDTO
                {
                    Id = p.Id,
                    Brand = p.Brand,
                    Color = p.Color,

                }).ToList();
        }

        public int UpdateTel(TelUpdateDTO tel)
        {
            var currentTel = _deviceDatabaseContext.Tels
                .Where(p => !p.IsDeleted && p.Id == tel.Id).FirstOrDefault();
            if (currentTel == null)
            {
                return 0;
            }
            currentTel.Brand = tel.Brand;
            currentTel.Color = tel.Color;
            _deviceDatabaseContext.Tels.Update(currentTel);
            return _deviceDatabaseContext.SaveChanges();
        }
    }
}
