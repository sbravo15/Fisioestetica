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
    public class PlanillaController : ApiController
    {
        PlanillaModel instanciaPlanilla = new PlanillaModel();
        BitacoraModel instanciaBitacora = new BitacoraModel();

        //Revisa que el usuario exista en el sistema 
        [AllowAnonymous]
        [HttpPost]
        [Route("api/Planilla/Registrar_Planilla")]
        public RespuestaPlanillaObj Registrar_Planilla(PlanillaObj planilla)
        {
            try
            {
                return instanciaPlanilla.Registrar_Planilla(planilla);
            }
            catch (Exception ex)
            {
                RespuestaPlanillaObj respuesta = new RespuestaPlanillaObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/Planilla/Editar_Planilla")]
        public RespuestaPlanillaObj Editar_Planilla(PlanillaObj planilla)
        {
            try
            {
                return instanciaPlanilla.Editar_Planilla(planilla);
            }
            catch (Exception ex)
            {
                RespuestaPlanillaObj respuesta = new RespuestaPlanillaObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/Planilla/Editar_Planilla")]
        public RespuestaPlanillaObj Consultar_Planilla_Doctor(int IdDoctor)
        {
            try
            {
                return instanciaPlanilla.Consultar_Planilla_Doctor(IdDoctor);
            }
            catch (Exception ex)
            {
                RespuestaPlanillaObj respuesta = new RespuestaPlanillaObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/Planilla/Consultar_IdPlanilla")]
        public RespuestaPlanillaObj Consultar_IdPlanilla(int idPlanilla)
        {
            try
            {
                return instanciaPlanilla.Consultar_IdPlanilla(idPlanilla);
            }
            catch (Exception ex)
            {
                RespuestaPlanillaObj respuesta = new RespuestaPlanillaObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/Planilla/Consultar_Planilla")]
        public RespuestaPlanillaObj Consultar_Planilla()
        {
            try
            {
                return instanciaPlanilla.Consultar_Planilla();
            }
            catch (Exception ex)
            {
                RespuestaPlanillaObj respuesta = new RespuestaPlanillaObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }

    }
}
