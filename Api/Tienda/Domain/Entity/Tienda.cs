using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnterprisePatterns.Api.Tienda.Domain.Entity
{
    public class Tienda
    {
        public virtual int id_tienda { get; set; }
        public virtual string det_tienda { get; set; }
        public virtual int estado { get; set; }
      
    }
}
