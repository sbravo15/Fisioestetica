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
using System.Web.Mvc;

namespace G7.Controllers
{
    public class PlanillaController : Controller
    {
        //Obtiene la información para crear una planilla
        [HttpPost]
        public ActionResult CrearPlanilla(PlanillaObj planilla)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Planilla/CrearPlanilla";
                string token = Session["codigoToken"]?.ToString();

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                JsonContent contenido = JsonContent.Create(planilla);

                HttpResponseMessage respuesta = client.PostAsync(rutaApi, contenido).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return RedirectToAction("VerPlanilla", new { id = planilla.IdPlanilla });
                }
                return View("Error");
            }
        }

        //Obtiene la información para visualizar una planilla existente
        public ActionResult VerPlanilla(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Planilla/VerPlanilla?id=" + id;
                string token = Session["codigoToken"]?.ToString();

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    PlanillaObj planilla = respuesta.Content.ReadAsAsync<PlanillaObj>().Result;
                    return View(planilla);
                }
                return View("Error");
            }
        }

        //Obtiene la información para editar una planilla existente
        [HttpPost]
        public ActionResult EditarPlanilla(PlanillaObj planilla)
        {
            RespuestaPlanillaObj resultado = EditarPlanillaModel(planilla);

            if (resultado != null && resultado.Codigo == 200)
            {
                return RedirectToAction("VerPlanilla", new { id = planilla.IdPlanilla });
            }
            return View("Error");
        }

        //Elimina una planilla existente
        public ActionResult EliminarPlanilla(int id)
        {
            RespuestaPlanillaObj resultado = EliminarPlanillaModel(id);

            if (resultado != null && resultado.Codigo == 200)
            {
                return RedirectToAction("Index", "Home");
            }
            return View("Error");
        }

        private RespuestaPlanillaObj EditarPlanillaModel(PlanillaObj planilla)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Planilla/EditarPlanilla";
                string token = HttpContext.Session["codigoToken"].ToString();

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
        private RespuestaPlanillaObj EliminarPlanillaModel(int idPlanilla)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Planilla/EliminarPlanilla?idPlanilla=" + idPlanilla;
                string token = HttpContext.Session["codigoToken"].ToString();

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
