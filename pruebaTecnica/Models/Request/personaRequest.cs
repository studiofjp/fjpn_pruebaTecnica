using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pruebaTecnica.Models.Request
{
    public class personaRequest
    { 
       
        public object Id { get; set;}
        public int Run { get; set;}
        public int RunCuerpo { get; set;}
        public string RunDigito { get; set;}
        public string Nombre { get; set; }
        public string Nombres { get; set;}
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Email { get; set; }
        public short SexoCodigo { get; set; }
        public string FechaNacimiento { get; set; }
        public short RegionCodigo { get; set; }
        public short CiudadCodigo { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public string Observaciones { get; set; }





    }
}
