using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PracticaConBDD.Models;
using Microsoft.EntityFrameworkCore;

namespace PracticaConBDD.Servicios
{
    public class PrendumServicio: IPrendumServicio
    {
        private VestimentasDBContext _dBContext;
        public PrendumServicio(VestimentasDBContext dBContext)
        {
            _dBContext = dBContext;
        }

        public Prendum obtenerPorId(int id)
        {
            return _dBContext.Prenda
                .Include(o => o.LocalPrenda)
                .Include("LocalPrenda.IdLocalNavigation")
                .FirstOrDefault(o => o.IdPrenda == id);
        }

        public List<Prendum> obtenerPorIds(int[] ids)
        {
            return _dBContext.Prenda
                .Include(o => o.LocalPrenda)
                .Include("LocalPrenda.IdLocalNavigation")
                .Where(o =>ids.Contains(o.IdPrenda)).ToList();
        }

        public List<Prendum> obtenerTodos()
        {
            return _dBContext.Prenda.ToList();
        }

        public List<Prendum> obtenerTodosPorTipoPrenda(int idTipoPrenda)
        {
            return _dBContext.Prenda.Where(o=> o.IdTipoPrenda == idTipoPrenda).ToList();
        }

        public void Alta(Prendum prendum)
        {
            _dBContext.Prenda.Add(prendum);
            _dBContext.SaveChanges();
        }

        public void Borrar(Prendum prendum)
        {
            _dBContext.Prenda.Remove(prendum);
            _dBContext.SaveChanges();
        }
    }
}
