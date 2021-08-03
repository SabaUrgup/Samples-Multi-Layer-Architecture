using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AplicationCore.Entity
{
    /// <summary>
    /// Veri tabanında kontrollü silme işlemi yapılan yer.
    /// </summary>
    public interface ISoftDelete
    {
        public bool IsDeleted { get; set; }
    }
}
