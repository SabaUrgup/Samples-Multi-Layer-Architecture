using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device.DataAccessLayer.DataTransferObject.TelDTO
{
    /// <summary>
    /// Kullanıcın güncelleme yaparken ulaşacağı özelliklere sınırlama getirmek için kurulan sınıf
    /// </summary>
    public class TelUpdateDTO
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
    }
}

