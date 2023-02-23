using G7.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Net.Http.Json;
using System.Web.Mvc;

namespace G7.Controllers
{
    public class UsuarioController : Controller
    {

        UsuarioModel instanciaUsuario = new UsuarioModel();

        [HttpGet]
        public ActionResult MostrarUsuarios()
        {
            var respuesta = instanciaUsuario.Consultar_Usuarios_Estado(1);

            if (respuesta != null && respuesta.Codigo == 1)
                return View(respuesta.lista);
            else
                return View("Error");
        }

        [HttpGet]
        public ActionResult RegistrarUsuarios()
        {
            var respuestaTiposUsuario = instanciaUsuario.Consultar_Tipos_Usuario();


            if (respuestaTiposUsuario != null && respuestaTiposUsuario.Codigo == 1)
            {
                var tiposUsuario = new List<SelectListItem>();

                foreach (var item in respuestaTiposUsuario.lista)
                    tiposUsuario.Add(new SelectListItem() { Text = item.Descripcion, Value = item.TipoUsuario.ToString() });


                ViewBag.comboTiposUsuario = tiposUsuario;
                return View();
            }
            else
                return View("Error");
        }


        [HttpPost]
        public ActionResult RegistrarUsuarios(UsuarioObj obj)
        {
            var resultado = instanciaUsuario.RegistrarUsuarios(obj);

            if (resultado != null && resultado.Codigo == 3)
                return RedirectToAction("MostrarUsuarios", "Usuario");
            else
                return View("Error");
        }

        [HttpGet]
        public ActionResult EditarUsuarios(int id)
        {
            var respuestaTiposUsuario = instanciaUsuario.Consultar_Tipos_Usuario();

            if (respuestaTiposUsuario != null && respuestaTiposUsuario.Codigo == 1)
            {
                var tiposUsuario = new List<SelectListItem>();

                foreach (var item in respuestaTiposUsuario.lista)
                    tiposUsuario.Add(new SelectListItem() { Text = item.Descripcion, Value = item.TipoUsuario.ToString() });

                ViewBag.comboTiposUsuario = tiposUsuario;

                var respuestaUsuario = instanciaUsuario.Consultar_Usuario_Id(id);

                if (respuestaUsuario != null && respuestaUsuario.Codigo == 1)
                    return View(respuestaUsuario.objeto);
                else
                    return View("Error");
            }
            else
                return View("Error");
        }

        [HttpPost]
        public ActionResult EditarUsuarios(UsuarioObj obj)
        {
            var resultado = instanciaUsuario.EditarUsuarios(obj);

            if (resultado != null && resultado.Codigo == 3)
                return RedirectToAction("MostrarUsuarios", "Usuario");
            else
                return View("Error");
        }
    }
}