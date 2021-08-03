using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device.DataAccessLayer.DataTransferObject.TelDTO
{
    /// <summary>
    /// Kullanıcının veri tabanında özelliklere ulaşırken ekleme esnasında sınırlama getiren sınıf.
    /// </summary>
    public class TelAddDTO
    {
        public string Brand { get; set; }
        public string Color { get; set; }
    }
}
