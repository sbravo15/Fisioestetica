using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FisioAPI.Models
{
    public class ExpedientesObj
    {

        public int IdExpediente { get; set; }
        public int IdUsuario { get; set; }
        public int IdDoctor { get; set; }
        public string Padecimiento { get; set; }
        public string Tratamiento { get; set; }

    }
    public class RespuestaExpedientesObj
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public ExpedientesObj objeto { get; set; }
        public List<ExpedientesObj> lista { get; set; }
    }
}