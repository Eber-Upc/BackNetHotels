using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Objetos;
using WebApiHoteles.Models;

namespace WebApiHoteles.Controllers
{
    public class GestionController : Controller
    {
        DataModel Modelo = new DataModel();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Panel()
        {
            return View();
        }

        public IActionResult CheckIng()
        {
            List<Reserva> ListaReservas = Modelo.GetReservasToChkng();
            ViewBag.ListaReservas = ListaReservas;
            return View();
        }

    }
}
