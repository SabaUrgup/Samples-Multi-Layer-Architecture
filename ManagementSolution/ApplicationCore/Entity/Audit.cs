using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entity
{
    /// <summary>
    /// Kayıtları tutan ortak sınıf
    /// </summary>
    public abstract class Audit
    {
        /// <summary>
        /// Veri tabanında veri oluşturma işlemi yapan kişinin id'si
        /// </summary>
        public int CreatedUserId { get; set; }

        /// <summary>
        /// Veri tabanında veri oluşturulma tarihi
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Veri tabanında veri güncelleyen kişi id'si
        /// </summary>
        public int? ModifiedUserId { get; set; }

        /// <summary>
        /// Veri tabanında veri güncelleme tarihi
        /// </summary>
        public DateTime? ModifiedDate { get; set; }

        //? işareti değeri null olabilir demek.
    }
}
