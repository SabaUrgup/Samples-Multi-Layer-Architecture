using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Entity
{
    /// <summary>
    /// Kontrollü silme işlemi yapan interface
    /// </summary>
    public interface ISoftDelete
    {
        /// <summary>
        /// Silindi mi sorgusu yapan metot
        /// </summary>
        public bool IsDeleted { get; set; }
    }
}
