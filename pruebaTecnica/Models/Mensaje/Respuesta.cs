using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pruebaTecnica.Models.Mensaje
{
    public class Respuesta
    {
        public string mensaje { get; set; }
        public int correcto { get; set; }
        public object data { get; set; }
    }
}
