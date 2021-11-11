using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApi.Objetos
{
    public class Habitacion
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Descripcion { get; set; }
        public string Descripcion_b { get; set; }
        public string Descripcion_c { get; set; }
        public string Img { get; set; }
        public string Img2 { get; set; }
        public string Img3 { get; set; }
        public string Img4 { get; set; }
        public string Img5 { get; set; }
        public decimal Costo { get; set; }
        public decimal Servicio { get; set; }
        public int Camas { get; set; }
        public int Capacidad { get; set; }

        public string Inicio { get; set; }
        public string Fin { get; set; }
        public int Personas { get; set; }
        public string[] Caracteristicas { get; set; }

        public decimal Total { get; set; }
        public int Dias { get; set; }
        public decimal Limpieza { get; set; }
        public decimal TotalUnit { get; set; }
    }
}
