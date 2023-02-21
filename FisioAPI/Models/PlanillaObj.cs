using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FisioAPI.Models
{
    public class PlanillaObj
    {
        public int IdPlanilla { get; set; }
        public int IdDoctor { get; set; }
        public DateTime Fecha { get; set; }
        public int HorasTrabajadas { get; set; }
        public decimal SalarioBruto { get; set; }
        public decimal Seguro { get; set; }
        public decimal Deducciones { get; set; }
        public decimal PagosExtra { get; set; }
        public decimal SalarioNeto { get; set; }
    }
    public class RespuestaPlanillaObj
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public PlanillaObj objeto { get; set; }
        public List<PlanillaObj> lista { get; set; }

    }
}