using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApi.Objetos
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido_Pat { get; set; }
        public string Apellido_Mat { get; set; }
        public string TipoDocument { get; set; }
        public string NumDocument { get; set; }
        public string Direccion { get; set; }
        public string Distrito { get; set; }
        public string Provincia { get; set; }
        public string Mail { get; set; }
        public string Telefono { get; set; }

        public string UserName { get; set; }
        public string UserPass { get; set; }
        public string Token { get; set; }
    }
}
