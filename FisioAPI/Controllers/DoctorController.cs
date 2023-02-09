using FisioAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

namespace FisioAPI.Controllers
{
    public class DoctorController : ApiController
    {
        DoctorModel instanciaDoctor = new DoctorModel();
        BitacoraModel instanciaBitacora = new BitacoraModel();

        //Revisa que el Doctor exista en el sistema 
        [AllowAnonymous]
        [HttpPost]
        [Route("api/Doctor/Registrar_Doctor")]
        public RespuestaDoctorObj Registrar_Doctor(DoctorObj Doctor)
        {
            try
            {
                return instanciaDoctor.Registrar_Doctor(Doctor);
            }
            catch (Exception ex)
            {
                RespuestaDoctorObj respuesta = new RespuestaDoctorObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/Doctor/Editar_Doctor")]
        public RespuestaDoctorObj Editar_Doctor(DoctorObj Doctor)
        {
            try
            {
                return instanciaDoctor.Editar_Doctor(Doctor);
            }
            catch (Exception ex)
            {
                RespuestaDoctorObj respuesta = new RespuestaDoctorObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/Doctor/Consultar_Doctor_Estado")]
        public RespuestaDoctorObj Consultar_Doctor_Estado(int IdDoctor)
        {
            try
            {
                return instanciaDoctor.Consultar_Doctor_Estado(IdDoctor);
            }
            catch (Exception ex)
            {
                RespuestaDoctorObj respuesta = new RespuestaDoctorObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/Doctor/Consultar_IdDoctor")]
        public RespuestaDoctorObj Consultar_IdDoctor(int idDoctor)
        {
            try
            {
                return instanciaDoctor.Consultar_IdDoctor(idDoctor);
            }
            catch (Exception ex)
            {
                RespuestaDoctorObj respuesta = new RespuestaDoctorObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }

    }
}