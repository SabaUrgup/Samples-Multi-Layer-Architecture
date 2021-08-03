using Device.DataAccessLayer.DataTransferObject.TvDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device.Business.Abstract
{
    public interface ITvService
    {
        public int AddTv(TvAddDTO tv);

        public int UpdateTv(TvUpdateDTO tv);

        public int DeleteTv(int Id);

        public List<TvListDTO> ListTv();

    }
}
