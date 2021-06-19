using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PracticaConBDD.Models;
using Microsoft.EntityFrameworkCore;

namespace PracticaConBDD.Servicios
{
    public class TipoPrendaServicio: ITipoPrendumServicio
    {
        private VestimentasDBContext _dBContext;
        public TipoPrendaServicio(VestimentasDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public TipoPrendum obtenerPorId(int id)
        {
            return _dBContext.TipoPrenda
                .FirstOrDefault(o => o.IdTipoPrenda == id);
        }

        public List<TipoPrendum> obtenerTodos()
        {
            return _dBContext.TipoPrenda.ToList();
        }

        public void Alta(TipoPrendum tipoPrendum)
        {
            _dBContext.TipoPrenda.Add(tipoPrendum);
            _dBContext.SaveChanges();
        }

        public void Borrar(TipoPrendum tipoPrendum)
        {
            _dBContext.TipoPrenda.Remove(tipoPrendum);
            _dBContext.SaveChanges();
        }
    }
}
