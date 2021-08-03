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
    public class Tv : Audit, IEntity, ISoftDelete
    {
        public Tv()
        {
            IsDeleted = false;
            CreatedDate = DateTime.Now;
        }
        public int Id { get; set; }
        public string Brand { get; set; }
        public double Size { get; set; }
        public bool IsDeleted { get; set; }
    }
}
