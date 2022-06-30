using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using sala_de_escape.Models;

namespace sala_de_escape.Controllers
{
    public class EscapeController : Controller
    {
        private readonly ILogger<EscapeController> _logger;

        public EscapeController(ILogger<EscapeController> logger)
        {
            _logger = logger;
        }
      //pene
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Comenzar()
        {
              ViewBag.salaActaul = escape.EstadoJuego;
              if  (escape.EstadoJuego < 5){
                  return View("habitacion" + escape.EstadoJuego);
              }
              else
              {
                  return View("Victoria");
              }
            
        }

        public IActionResult Reiniciar()
        {

            escape.Reiniciar();
            return View("habitacion" + escape.EstadoJuego);
        }

        [HttpPost]
         public ActionResult Habitacion(int sala, string clave) 
        {   
            ViewBag.Error = "";
            if (escape.ResolverSala(sala, clave) && sala != 4)
            {
                ViewBag.salaActaul = escape.EstadoJuego;
                return View("habitacion" + escape.EstadoJuego);
            }
            else if(escape.ResolverSala(sala, clave) && sala == 4){

                return View("Victoria");
            }
            else
            {
                ViewBag.Error = "Incorrecto!";
                ViewBag.salaActaul = escape.EstadoJuego;
                return View("Habitacion" + escape.EstadoJuego);
            }

            
        }


        public IActionResult Habitacion1() 
        {    
            return View();
        }

        public IActionResult Habitacion2()
        {
            return View();
        }

        public IActionResult Habitacion3()
        {
            return View();
        }

        public IActionResult Habitacion4()
        {
            return View();
        }

        public IActionResult Victoria()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
