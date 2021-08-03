using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device.DataAccessLayer.DataTransferObject.TelDTO
{
/// <summary>
/// Kullanıcının listeme yaparken ulaşacağı özelliklere sınırlama getirmek için kurulan sınıf
/// </summary>
    public class TelListDTO
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
    }
}
