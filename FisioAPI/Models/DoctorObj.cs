using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FisioAPI.Models
{
    public class DoctorObj
    {
        public int IdDoctor { get; set; }
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Cedula { get; set; }
        public int Telefono { get; set; }
        public string Email { get; set; }
        public string Genero { get; set; }
        public DateTime FechaMacimiento { get; set; }
        public int TipoUsuario { get; set; }
        public bool State { get; set; }
    }
    public class RespuestaDoctorObj
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public DoctorObj objeto { get; set; }
        public List<DoctorObj> lista { get; set; }

    }
}