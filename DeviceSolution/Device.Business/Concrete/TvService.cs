using Device.Business.Abstract;
using Device.DataAccessLayer.Context;
using Device.DataAccessLayer.DataTransferObject.TvDTO;
using Device.DataAccessLayer.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Device.Business.Concrete
{
    public class TvService : ITvService
    {
        public DeviceDatabaseContext _deviceDatabaseContext;

        public TvService (DeviceDatabaseContext deviceDatabaseContext)
        {
            _deviceDatabaseContext = deviceDatabaseContext;
        }

        public int AddTv(TvAddDTO tv)
        {
            var newTv = new Tv
            {
                Brand = tv.Brand,
                Size = tv.Size,
            };
            _deviceDatabaseContext.Tvs.Add(newTv);
            return _deviceDatabaseContext.SaveChanges();
        }

        public int DeleteTv(int Id)
        {
            var currentTv = _deviceDatabaseContext.Tvs
                .Where(p => !p.IsDeleted && p.Id == Id).FirstOrDefault();
            if(currentTv == null)
            {
                return 0;
            }
            currentTv.IsDeleted = true;
            _deviceDatabaseContext.Tvs.Update(currentTv);
            return _deviceDatabaseContext.SaveChanges();
        }

        public List<TvListDTO> ListTv()
        {
            return _deviceDatabaseContext.Tvs.Where(p => !p.IsDeleted)
                .Select(p => new TvListDTO
                {
                    Id = p.Id,
                    Brand = p.Brand,
                    Size = p.Size,
                }).ToList();
        }

        public int UpdateTv(TvUpdateDTO tv)
        {
            var currentTv = _deviceDatabaseContext.Tvs
                .Where(p => !p.IsDeleted && p.Id == tv.Id).FirstOrDefault();
            if(currentTv == null)
            {
                return 0;
            }
            currentTv.Size = tv.Size;
            currentTv.Brand = tv.Brand;
            _deviceDatabaseContext.Tvs.Update(currentTv);
            return _deviceDatabaseContext.SaveChanges();
        }
    }
}
