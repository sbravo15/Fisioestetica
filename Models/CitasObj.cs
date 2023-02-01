using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace G7.Models
{
    public class CitasObj
    {
        public int IdCita { get; set; }
        public int IdUsuario { get; set; }
        public int IdEmpleado { get; set; }
        public string Condicion { get; set; }
        public DateTime Hora { get; set; }
        public bool Status { get; set; }
    }

    public class RespuestaCitasObj
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public CitasObj objeto { get; set; }
        public List<CitasObj> lista { get; set; }
    }
}