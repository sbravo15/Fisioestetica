using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace G7.Models
{
    internal class TipoUsuarioObj
    {
        public class TiposUsuarioObj
        {
            public int TipoUsuario { get; set; }

            public string Descripcion { get; set; }
        }

        public class RespuestaTiposUsuarioObj
        {
            public int Codigo { get; set; }
            public string Descripcion { get; set; }
            public List<TiposUsuarioObj> lista { get; set; }
        }
    }
}