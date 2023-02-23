using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace G7.Models
{
    public class UsuarioObj
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Cedula { get; set; }
        public int Telefono { get; set; }
        public string Email { get; set; }
        public string Genero { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public int TipoUsuario { get; set; }
        public bool State { get; set; }

        public string Contrasenna { get; set; }
        public string Token { get; set; }
        
    }
    public class RespuestaUsuarioObj
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public UsuarioObj objeto { get; set; }
        public List<UsuarioObj> lista { get; set; }

    }
}