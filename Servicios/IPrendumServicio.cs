using PracticaConBDD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaConBDD.Servicios
{
    interface IPrendumServicio
    {
        void Alta(Prendum prendum);
        void Borrar(Prendum prendum);
        List<Prendum> obtenerPorIds(int[] ids);
        List<Prendum> obtenerTodos();

        Prendum obtenerPorId(int id);
    }
}
