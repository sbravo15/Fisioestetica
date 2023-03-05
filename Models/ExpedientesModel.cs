using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using G7.Models;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Configuration;

namespace G7.Models
{
    public class ExpedientesModel
    {
        public RespuestaExpedientesObj Consultar_Expediente_Paciente(int indicador)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Expedientes/Consultar_Expediente_Paciente?indicador=" + indicador;
                string token = HttpContext.Current.Session["codigoToken"].ToString();

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    //Deserializar --> System.Net.Http.Formatting.Extension
                    return respuesta.Content.ReadAsAsync<RespuestaExpedientesObj>().Result;
                }
                return null;
            }
        }

        public RespuestaExpedientesObj RegistrarExpedientes(ExpedientesObj usuario)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Expedientes/Registrar_Expediente";

                JsonContent contenido = JsonContent.Create(usuario);

                HttpResponseMessage respuesta = client.PostAsync(rutaApi, contenido).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<RespuestaExpedientesObj>().Result;
                }
                return null;
            }

        }

        public RespuestaExpedientesObj EditarExpedientes(ExpedientesObj usuario)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Expedientes/Editar_Expediente";
                string token = HttpContext.Current.Session["codigoToken"].ToString();

                JsonContent contenido = JsonContent.Create(usuario);

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.PutAsync(rutaApi, contenido).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<RespuestaExpedientesObj>().Result;
                }
                return null;
            }

        }


    }
}
