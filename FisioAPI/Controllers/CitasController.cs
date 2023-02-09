using FisioAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Reflection;
using System.Web.Http;

// 1.  Registrar Cita, 2 Editar Citas , 3. Consultar Cita Doctor, 4. Consultar ID Citas, 5 . Consultar Todas las Citas

namespace FisioAPI.Controllers
{
    public class CitasController : ApiController
    {
        CitasModel instanciaCitas = new CitasModel();
        BitacoraModel instanciaBitacora = new BitacoraModel();

        //Registrar Cita
 
        [HttpPost]
        [Route("api/Citas/Registrar_Cita")]
        public RespuestaCitasObj Registrar_Cita(CitasObj cita)
        {
            try
            {
                return instanciaCitas.Registrar_Cita(cita);
            }
            catch (Exception ex)
            {
                RespuestaCitasObj respuesta = new RespuestaCitasObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }

        // Editar Cita
 
        [HttpPost]
        [Route("api/Citas/Editar_Cita")]
        public RespuestaCitasObj Editar_Cita(CitasObj cita)
        {
            try
            {
                return instanciaCitas.Editar_Cita(cita);
            }
            catch (Exception ex)
            {
                RespuestaCitasObj respuesta = new RespuestaCitasObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }

        //Consultar Cita Doctor

        [HttpGet]
        [Route("api/Citas/Consultar_Citas_Doctor")]
        public RespuestaCitasObj Consultar_Citas_Doctor(int idDoctor)
        {
            try
            {
                return instanciaCitas.Consultar_Cita_Doctor(idDoctor);
            }
            catch (Exception ex)
            {
                RespuestaCitasObj respuesta = new RespuestaCitasObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }

        // Consultar ID Citas Paciente


        [HttpGet]
        [Route("api/Citas/Consultar_Citas_Paciente")]
        public RespuestaCitasObj Consultar_Consultar_IdCita(int idPaciente)
        {
            try
            {
                return instanciaCitas.Consultar_IdCita(idPaciente);
            }
            catch (Exception ex)
            {
                RespuestaCitasObj respuesta = new RespuestaCitasObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }

        }

        // Consultar ID Citas Paciente

        [HttpGet]
        [Route("api/Citas/Consultar_Citas")]
        public RespuestaCitasObj Consultar_Citas()
        {
            try
            {
                return instanciaCitas.Consultar_Citas();
            }
            catch (Exception ex)
            {
                RespuestaCitasObj respuesta = new RespuestaCitasObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }
        


    }
}