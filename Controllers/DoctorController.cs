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
    public class DoctorController : Controller
    {
        [HttpPost]
        public ActionResult CrearDoctor(DoctorObj doctor)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Doctor/CrearDoctor";
                string token = Session["codigoToken"]?.ToString();

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                JsonContent contenido = JsonContent.Create(doctor);

                HttpResponseMessage respuesta = client.PostAsync(rutaApi, contenido).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return RedirectToAction("VerDoctor", new { id = doctor.IdDoctor });
                }
                return View("Error");
            }
        }
        public ActionResult VerDoctor(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Doctor/VerDoctor?id=" + id;
                string token = Session["codigoToken"]?.ToString();

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    DoctorObj doctor = respuesta.Content.ReadAsAsync<DoctorObj>().Result;
                    return View(doctor);
                }
                return View("Error");
            }
        }
        [HttpPost]
        public ActionResult BuscarDoctor(string nombre)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Doctor/BuscarDoctor?nombre=" + nombre;
                string token = Session["codigoToken"]?.ToString();

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    List<DoctorObj> doctores = respuesta.Content.ReadAsAsync<List<DoctorObj>>().Result;
                    return View(doctores);
                }
                return View("Error");
            }
        }

    }
}
