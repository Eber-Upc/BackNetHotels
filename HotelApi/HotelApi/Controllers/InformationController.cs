using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using HotelApi.Objetos;
using HotelApi.Model;
using HotelApi.Functions;

namespace HotelApi.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class InformationController : ControllerBase
    {
        DataModel Modelo = new DataModel();
        Helper Helper = new Helper();

        [HttpGet]
        [Route("api/Prueba")]
        public IEnumerable<WeatherForecast> PruebaTwo()
        {
            List<WeatherForecast> lista = new List<WeatherForecast>();
            //List<Habitacion> lista = new List<Habitacion>();
            //lista = Modelo.GetHabitaciones();
            lista.Add(new WeatherForecast { Summary = "Lima ", TemperatureC = 100 });
            lista.Add(new WeatherForecast { Summary = "Arequipa ", TemperatureC = 50 });
            lista.Add(new WeatherForecast { Summary = "Cusco ", TemperatureC = -5 });
            return lista;
        }



        [HttpPost]
        [Route("api/GetHabitacionesDisponibles")]
        public IEnumerable<Habitacion> GetHabitacionesDisponibles(Entrada Parametros)
        {
            string[] range = null;
            string inicio = "";
            string fin = "";
            int Huspedes = 0;
            range = Parametros.RangeDate.Split("-");
            try { inicio = Helper.GetDateChangeFormat(range[0]); } catch (Exception) { inicio = ""; }
            try { fin = Helper.GetDateChangeFormat(range[1]); } catch (Exception) { fin = ""; }
            try { Huspedes = Parametros.Personas; } catch (Exception) { Huspedes = 0; }
           

            List<Habitacion> lista = new List<Habitacion>();
            lista = Modelo.GetHabitaciones(inicio,fin,Huspedes);  
           
            return lista;
        }


        [HttpPost]
        [Route("api/GetInfoHabitacion")]
        public Habitacion GetInfoHabitacion(Entrada Parametros)
        {
            Habitacion hb = new Habitacion();
            hb = Modelo.GetHabitacion(Parametros.Id);
            return hb;
        }


        [HttpPost]
        [Route("api/GetSummaryReserva")]
        public Habitacion GetSummaryReserva(Entrada Parametros)
        {
            Habitacion hb = new Habitacion();
            string[] range = null;
            string inicio = "";
            string fin = "";
            int Huspedes = 0;
            range = Parametros.RangeDate.Split("-");
            try { inicio = Helper.GetDateChangeFormat(range[0]); } catch (Exception) { inicio = ""; }
            try { fin = Helper.GetDateChangeFormat(range[1]); } catch (Exception) { fin = ""; }
            try { Huspedes = Parametros.Personas; } catch (Exception) { Huspedes = 0; }

            DateTime fechaUno = Convert.ToDateTime(inicio);
            DateTime fechaDos = Convert.ToDateTime(fin);
            TimeSpan difFechas = fechaDos - fechaUno;
            int dias = difFechas.Days;


            hb = Modelo.GetHabitacion(Parametros.Id);
            
            try { hb.Personas = Huspedes; } catch (Exception) { hb.Personas = 0; }
            try { hb.Dias = dias; } catch (Exception) { hb.Dias = 0; }
            try { hb.Limpieza = hb.Servicio; } catch (Exception) { hb.Limpieza = 0; }
            try { hb.TotalUnit = (hb.Costo * hb.Dias); } catch (Exception) { hb.TotalUnit = 0; }
            try { hb.Total = hb.TotalUnit + hb.Limpieza; } catch (Exception) { hb.Total = 0; }
            return hb;
        }



    }
}
