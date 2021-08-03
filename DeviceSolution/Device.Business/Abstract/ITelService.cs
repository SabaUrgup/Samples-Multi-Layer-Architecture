using Device.DataAccessLayer.DataTransferObject.TelDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device.Business.Abstract
{
    public interface ITelService
    {
        public int AddTel(TelAddDTO tel);

        public int UpdateTel(TelUpdateDTO tel);

        public int DeleteTel(int Id);

        public List<TelListDTO> ListTel();

    }
}
