using Microsoft.AspNetCore.Mvc;
using PracticaConBDD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PracticaConBDD.Controllers
{
    public class LocalesController : Controller
    {
        public IActionResult Index()
        {
            using (VestimentasDBContext context = new VestimentasDBContext()) {
                return View(context.Locals.ToList());
            }
                return View();
        }
    }
}
