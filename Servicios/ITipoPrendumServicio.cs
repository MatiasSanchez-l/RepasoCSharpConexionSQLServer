using PracticaConBDD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaConBDD.Servicios
{
    interface ITipoPrendumServicio
    {
        void Alta(TipoPrendum prendum);
        void Borrar(TipoPrendum prendum);
        List<TipoPrendum> obtenerTodos();

        TipoPrendum obtenerPorId(int id);
    }
}
