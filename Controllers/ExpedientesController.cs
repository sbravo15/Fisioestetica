using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using G7.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Configuration;

namespace G7.Controllers
{
    public class ExpedientesController : Controller
    {
        [HttpPost]
        public ActionResult CrearExpediente(ExpedientesObj obj)
        {
            var resultado = RegistrarExpedientes(obj);

            if (resultado != null && resultado.Codigo == 1)
                return RedirectToAction("MostrarUsuarios", "Usuario");
            else
                return View("Error");

            return View();
        }

        [HttpGet]
        public ActionResult VerExpediente()
        {
            var respuesta = Consultar_Expediente_Paciente(1);

            if (respuesta != null && respuesta.Codigo == 1)
                return View(respuesta.lista);
            else
                return View("Error");
        }

        [HttpGet]
        public ActionResult EditarExpediente(int id)
        {
            var respuestaTiposExpedientes = Consultar_Expediente_Paciente(1);

            if (respuestaTiposExpedientes != null && respuestaTiposExpedientes.Codigo == 1)
            {
                var tiposUsuario = new List<SelectListItem>();

                foreach (var item in respuestaTiposExpedientes.lista)
                    tiposUsuario.Add(new SelectListItem() { Text = item.Padecimiento, Value = item.Tratamiento.ToString() });

                ViewBag.comboTiposUsuario = tiposUsuario;

                var respuestaExpediente = Consultar_Expediente_Paciente(id);

                if (respuestaExpediente != null && respuestaExpediente.Codigo == 1)
                    return View(respuestaExpediente.objeto);
                else
                    return View("Error");
            }
            else
                return View("Error");

        }
        public RespuestaExpedientesObj EditarExpedientes(ExpedientesObj usuario)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Expedientes/Editar_Expediente";
                string token = HttpContext.Session["codigoToken"].ToString();

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

        public RespuestaExpedientesObj RegistrarExpedientes(ExpedientesObj obj)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Expedientes/Registrar_Expediente";
                string token = HttpContext.Session["codigoToken"].ToString();

                JsonContent contenido = JsonContent.Create(obj);

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.PostAsync(rutaApi, contenido).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<RespuestaExpedientesObj>().Result;
                }
                return null;
            }
        }

        public RespuestaExpedientesObj Consultar_Expediente_Paciente(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Expedientes/Consultar_Expediente_Paciente?id=" + id;
                string token = HttpContext.Session["codigoToken"].ToString();

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<RespuestaExpedientesObj>().Result;
                }
                return null;
            }
        }
    }
}
        