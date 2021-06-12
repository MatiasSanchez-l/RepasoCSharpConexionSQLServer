using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
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

        public Local obtenerPorId(int id)
        {
            return _dBContext.Locals.Include(o => o.LocalPrenda).Include("LocalPrenda.IdPrendaNavigation").FirstOrDefault(o => o.IdLocal == id);
        }

        public void Alta(Local local)
        {
            _dBContext.Locals.Add(local);
            _dBContext.SaveChanges();
        }

        public void Modificar(Local local, List<Prendum> prendas)
        {
            Local objActual = obtenerPorId(local.IdLocal);
            objActual.Direccion = local.Direccion;
            objActual.Nombre = local.Nombre;

            objActual.LocalPrenda.Clear();
            _dBContext.SaveChanges();
            
            foreach (var p in prendas)
            {
                objActual.LocalPrenda.Add(new LocalPrendum {IdLocal = local.IdLocal, IdPrenda = p.IdPrenda });
            }

            _dBContext.SaveChanges();
        }

        public void Borrar(Local local)
        {
            _dBContext.Locals.Remove(local);
            _dBContext.SaveChanges();
        }
    }
}
