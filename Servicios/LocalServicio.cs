using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PracticaConBDD.Models;

namespace PracticaConBDD.Servicios
{
    public class LocalServicio : ILocalServicio
    {
        private VestimentasDBContext _dBContext;
        public LocalServicio(VestimentasDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public void Alta(Local local)
        {
            _dBContext.Locals.Add(local);
            _dBContext.SaveChanges();
        }
    }
}
