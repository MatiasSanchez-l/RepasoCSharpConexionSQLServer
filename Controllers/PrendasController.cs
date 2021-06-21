using Microsoft.AspNetCore.Mvc;
using PracticaConBDD.Models;
using PracticaConBDD.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaConBDD.Controllers
{
    public class PrendasController : Controller
    {

        private ILocalServicio _localServicio;
        private IPrendumServicio _prendumServicio;
        private ITipoPrendumServicio _tipoPrendumServicio;
        

        public PrendasController()
        {
            VestimentasDBContext dBContext = new VestimentasDBContext();
            _localServicio = new LocalServicio(dBContext);
            _prendumServicio = new PrendumServicio(dBContext);
            _tipoPrendumServicio = new TipoPrendaServicio(dBContext);
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.TodasTipoPrendas = _tipoPrendumServicio.obtenerTodos();
            List<Prendum> prendas = _prendumServicio.obtenerTodos();
            return View(prendas);
        }

        [HttpPost]
        public IActionResult Index(int idTipoPrenda)
        {
            ViewBag.TodasTipoPrendas = _tipoPrendumServicio.obtenerTodos();
            ViewBag.IdTipoPrendaSeleccionada = idTipoPrenda;
            List<Prendum> prendas = _prendumServicio.obtenerTodosPorTipoPrenda(idTipoPrenda);

            return View(prendas);
        }

        [HttpGet]
        public IActionResult Alta()
        {
            ViewBag.TodasTipoPrendas = _tipoPrendumServicio.obtenerTodos();
            return View();
        }

        [HttpPost]
        public IActionResult Alta(Prendum prenda, string tipoPrendaNueva)
        {
            
            ViewBag.TodasTipoPrendas = _tipoPrendumServicio.obtenerTodos();

            if (!string.IsNullOrEmpty(tipoPrendaNueva))
            {
                TipoPrendum tipoPrenda = new TipoPrendum();
                tipoPrenda.Descripcion = tipoPrendaNueva;
                
                _tipoPrendumServicio.Alta(tipoPrenda);
                prenda.IdTipoPrenda = tipoPrenda.IdTipoPrenda;
            }

            _prendumServicio.Alta(prenda);
            return View(prenda);
        }
    }
}
