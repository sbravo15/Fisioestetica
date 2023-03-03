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

namespace G7.Controllers
{
    public class ExpedientesController : Controller
    {
        ExpedientesModel instanciaExpedientes = new ExpedientesModel();

        [HttpPost]
        public ActionResult CrearExpediente(ExpedientesObj obj)
        {
                       
                var resultado = instanciaExpedientes.RegistrarExpedientes(obj);

                if (resultado != null && resultado.Codigo == 1)
                    return RedirectToAction("MostrarUsuarios", "Usuario");
                else
                    return View("Error");
            
            return View();
        }

        [HttpGet]
        public ActionResult VerExpediente()
        {
            var respuesta = instanciaExpedientes.Consultar_Expediente_Paciente(1);

            if (respuesta != null && respuesta.Codigo == 1)
                return View(respuesta.lista);
            else
                return View("Error");
        }

        [HttpGet]
        public ActionResult EditarExpediente(int id)
        {
            var respuestaTiposExpedientes = instanciaExpedientes.Consultar_Expediente_Paciente(1);

            if (respuestaTiposExpedientes != null && respuestaTiposExpedientes.Codigo == 1)
            {
                var tiposUsuario = new List<SelectListItem>();

                foreach (var item in respuestaTiposExpedientes.lista)
                    tiposUsuario.Add(new SelectListItem() { Text = item.Padecimiento, Value = item.Tratamiento.ToString() });

                ViewBag.comboTiposUsuario = tiposUsuario;

                var respuestaExpediente = instanciaExpedientes.Consultar_Expediente_Paciente(id);

                if (respuestaExpediente != null && respuestaExpediente.Codigo == 1)
                    return View(respuestaExpediente.objeto);
                else
                    return View("Error");
            }
            else
                return View("Error");
            
        }
    }
}