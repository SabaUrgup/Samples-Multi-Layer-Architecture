using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device.DataAccessLayer.DataTransferObject.TvDTO
{
/// <summary>
/// Kullanıcının listeme yaparken ulaşacağı özelliklere sınırlama getirmek için kurulan sınıf
/// </summary>
    public class TvListDTO
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public double Size { get; set; }
    }
}
