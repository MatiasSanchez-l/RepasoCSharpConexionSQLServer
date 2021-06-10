using Microsoft.AspNetCore.Mvc;
using PracticaConBDD.Models;
using PracticaConBDD.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaConBDD.Controllers
{
    public class LocalesController : Controller
    {
        private ILocalServicio _localServicio;
        public LocalesController()
        {
            VestimentasDBContext dBContext = new VestimentasDBContext();
            _localServicio = new LocalServicio(dBContext);
        }

        public IActionResult Index()
        {
            using (VestimentasDBContext context = new VestimentasDBContext()) {
                return View(context.Locals.ToList());
            }
                return View();
        }

        public IActionResult Alta()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Alta(Local local)
        {
            _localServicio.Alta(local);
            return Redirect("/Locales");
        }
    }
}
