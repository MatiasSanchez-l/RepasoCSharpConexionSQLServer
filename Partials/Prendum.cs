using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaConBDD.Models
{
    public partial class Prendum
    {
        public override string ToString()
        {
            return $"{Modelo}--{Talle}--{Color}---{Marca}";
        }
    }
    
}
