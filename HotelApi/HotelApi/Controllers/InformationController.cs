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


        [HttpPost]
        [Route("api/GetRegistroUser")]
        public Mensajes GetRegistroUser(Usuario Parametros)
        {
            Usuario Us = new Usuario();
            int error = 0;
            string Org = "";
            try { Us.UserName = Helper.CreateMD5(Parametros.Mail); } catch (Exception) { error = 1; Org = Org+"UserName"; }
            try { Us.UserPass = Helper.CreateMD5(Parametros.UserPass); } catch (Exception) { error = 1; Org = Org + "UserPass"; }
            try { Us.Nombre = Parametros.Nombre; } catch (Exception) { error = 1; Org = Org + "Nombre"; }
            try { Us.Apellido_Pat = Parametros.Apellido_Pat; } catch (Exception) { error = 1; Org = Org + "ApPat"; }
            try { Us.Apellido_Mat = Parametros.Apellido_Mat; } catch (Exception) { error = 1; Org = Org + "ApMat"; }
            try { Us.TipoDocument = Parametros.TipoDocument; } catch (Exception) { error = 1; Org = Org + "TpoDoc"; }
            try { Us.NumDocument = Parametros.NumDocument; } catch (Exception) { error = 1; Org = Org + "NumDoc"; }
            try { Us.Direccion = Parametros.Direccion; } catch (Exception) { error = 1; Org = Org + "Direc"; }
            try { Us.Distrito = Parametros.Distrito; } catch (Exception) { error = 1; Org = Org + "Distrito"; }
            try { Us.Provincia = Parametros.Provincia; } catch (Exception) { error = 1; Org = Org + "Provincia"; }
            try { Us.Telefono = Parametros.Nombre; } catch (Exception) { error = 1; Org = Org + "Telef"; }
            try { Us.Mail = Parametros.Nombre; } catch (Exception) { error = 1; Org = Org + "Mail"; }


            Mensajes msn = new Mensajes();

            if (error != 1)
            {
                string Rsl = Modelo.SetUsuario(Us);
                msn.Description = "Modelo";
                msn.Origen = "Insercion";
                msn.Value = Rsl;
            }
            else
            {
                msn.Description = "Transaccion";
                msn.Origen = "Usuario";
                msn.Value = Org;
            }

            return msn;
        }

        [HttpPost]
        [Route("api/GetLoginUsuario")]
        public Mensajes GetLoginUsuario(Usuario Parametros)
        {
            Usuario Us = new Usuario();
            Mensajes msn = new Mensajes();

            try { Us.UserName = Helper.CreateMD5(Parametros.UserName); } catch (Exception) { Us.UserName = ""; }
            try { Us.UserPass = Helper.CreateMD5(Parametros.UserPass); } catch (Exception) { Us.UserPass = ""; }
            string token = ""; //GetToken

            if (Us.UserName!="" && Us.UserPass != "")
            {
                Usuario rsl = Modelo.GetSesionUser(Us);
                if(rsl != null)
                {
                    token = Helper.GetToken();
                    Modelo.SetTokenUser(rsl.Id,token);
                    msn.Token = token;
                    msn.Description = rsl.Nombre;
                    msn.Value = rsl.Id.ToString();
                }
                else
                {
                    msn.Description = "Not User";
                    msn.Origen = "Sesion";
                    msn.Value = "NA";
                }
            }
            else
            {
                msn.Description = "Error toma de datos";
                msn.Origen = "Sesion";
                msn.Value = "null";
            }
            
            return msn;
        }



    }
}
