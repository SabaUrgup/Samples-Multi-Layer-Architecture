using AplicationCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Device.DataAccessLayer.Entity
{
    /// <summary>
    /// DataAccessLayer.Entity katmanında özelleştirilmiş varlıklar tututlur.
    /// Veri tabanında tablo == C#'da entity
    /// </summary>
    public class Tel : Audit, IEntity, ISoftDelete
    {
        public Tel()
        {
            IsDeleted = false;
            CreatedDate = DateTime.Now;
        }
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public bool IsDeleted { get; set; }
    }
}

