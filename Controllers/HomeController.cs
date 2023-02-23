using G7.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace G7.Controllers
{
    public class HomeController : Controller
    {
        UsuarioModel instanciaUsuario = new UsuarioModel();

        [HttpGet]
        public ActionResult Index()
        {
            //Entrar al login
            Session.Clear();
            Session.Abandon();
            return View();
        }

        [HttpPost]
        public ActionResult ValidarAcceso(UsuarioObj usuario)
        {
            ViewBag.MsjError = string.Empty;

            //Acción para autenticar a un usuario
            var respuesta = instanciaUsuario.Validar_Usuario(usuario);

            if (respuesta != null && respuesta.Codigo == 1)
            {
                Session["consecutivo"] = respuesta.objeto.IdUsuario;
                Session["codigoToken"] = respuesta.objeto.Token;
                Session["nombreUsuario"] = respuesta.objeto.Email;
                Session["tipoUsuario"] = respuesta.objeto.TipoUsuario;

                return RedirectToAction("Principal", "Home");
            }
            else
            {
                ViewBag.MsjError = "Valide sus credenciales nuevamente";
                return View("Index");
            }
        }

        [Filtro]
        [HttpGet]
        public ActionResult Principal()
        {
            //Entrar al sistema
            return View();
        }

        [Filtro]
        [HttpGet]
        public ActionResult CerrarSesion()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}