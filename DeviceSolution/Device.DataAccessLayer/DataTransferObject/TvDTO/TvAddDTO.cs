using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device.DataAccessLayer.DataTransferObject.TvDTO
{
    /// <summary>
    /// Kullanıcının veri tabanında özelliklere ulaşırken ekleme esnasında sınırlama getiren sınıf.
    /// </summary>
    public class TvAddDTO
    {
        public string Brand { get; set; }
        public double Size { get; set; }
    }
}
