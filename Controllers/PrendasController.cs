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

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Alta()
        {
            ViewBag.TodasTipoPrendas = _tipoPrendumServicio.obtenerTodos();
            return View();
        }

        [HttpPost]
        public IActionResult Alta(Prendum prenda)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.TodasTipoPrendas = _prendumServicio.obtenerTodos();
                return View(prenda);
            }

            _prendumServicio.Alta(prenda);
            return View(prenda);
        }
    }
}
