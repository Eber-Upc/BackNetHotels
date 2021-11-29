﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelApi.Objetos
{
    public class Reporte
    {
        public string Habitacion { get; set; }
        public string Descripcion { get; set; }
        public string Entrada { get; set; }
        public string Salida { get; set; }
        public int Huespedes { get; set; }
        public decimal Total { get; set; }

    }
}
