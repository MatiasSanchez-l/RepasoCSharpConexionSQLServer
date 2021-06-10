using System;
using System.Collections.Generic;

#nullable disable

namespace PracticaConBDD.Models
{
    public partial class Prendum
    {
        public Prendum()
        {
            LocalPrenda = new HashSet<LocalPrendum>();
        }

        public int IdPrenda { get; set; }
        public string Talle { get; set; }
        public string Color { get; set; }
        public string Modelo { get; set; }
        public string Marca { get; set; }
        public int? IdTipoPrenda { get; set; }

        public virtual TipoPrendum IdTipoPrendaNavigation { get; set; }
        public virtual ICollection<LocalPrendum> LocalPrenda { get; set; }
    }
}
