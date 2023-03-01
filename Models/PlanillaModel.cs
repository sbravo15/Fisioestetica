using System;
using G7.Models;
using System.Collections.Generic;
using System.IO;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Web;

namespace G7.Models
{
    internal class PlanillaModelImpl
    {
        /*
        public RespuestaPlanillaObj CalcularPlanilla(PlanillaObj planilla)
        {
            // Haga los cálculos necesarios para obtener los valores de la planilla
            planilla.SalarioBruto = planilla.HorasTrabajadas * 10;
            planilla.Seguro = planilla.SalarioBruto * 0.10m;
            planilla.Deducciones = planilla.Seguro * 0.10m;
            planilla.SalarioNeto = planilla.SalarioBruto - planilla.Seguro - planilla.Deducciones;

            // Cree una instancia de RespuestaPlanillaObj y devuélvala
            var respuesta = new RespuestaPlanillaObj
            {
                Codigo = 200,
                Mensaje = "Planilla calculada exitosamente",
                Objeto = planilla
            };
            return respuesta;
        }
        */

        public RespuestaPlanillaObj ConsultarPlanilla(int idPlanilla)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Planilla/ConsultarPlanilla?idPlanilla=" + idPlanilla;
                string token = HttpContext.Current.Session["codigoToken"].ToString();

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<RespuestaPlanillaObj>().Result;
                }
                return null;
            }
        }

        public RespuestaPlanillaObj EditarPlanilla(PlanillaObj planilla)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Planilla/EditarPlanilla";
                string token = HttpContext.Current.Session["codigoToken"].ToString();

                JsonContent contenido = JsonContent.Create(planilla);

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.PutAsync(rutaApi, contenido).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<RespuestaPlanillaObj>().Result;
                }
                return null;
            }
        }

        public RespuestaPlanillaObj EliminarPlanilla(int idPlanilla)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Planilla/EliminarPlanilla?idPlanilla=" + idPlanilla;
                string token = HttpContext.Current.Session["codigoToken"].ToString();

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.DeleteAsync(rutaApi).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<RespuestaPlanillaObj>().Result;
                }
                return null;
            }
        }
    }
}
