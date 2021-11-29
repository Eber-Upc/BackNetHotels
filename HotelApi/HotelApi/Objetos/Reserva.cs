﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApi.Objetos
{
    public class Reserva
    {
        public string Number { get; set; }
        public string Expiry_m{ get; set; }
        public string Expiry_y { get; set; }
        public string Ccv { get; set; }
        public string Titular { get; set; }


        public string Fechas { get; set; }
        public string Inicio { get; set; }
        public string Fin { get; set; }
        public int Usuario { get; set; }
        public string Token { get; set; }
        public int Room { get; set; }
        public decimal Monto { get; set; }
        public int Huespedes { get; set; }

        public string Habitacion { get; set; }
        public decimal Servicio { get; set; }
        public int Dias { get; set; }
        public string Hoy { get; set; }
        public decimal Unitario { get; set; }

    }
}
