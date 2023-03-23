using FisioAPI.Database;
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
                using (var con = new MOSSAEntities())
                {
                    var resultado = con.Consultar_IdDoctor(idDoctor).ToList();

                    RespuestaDoctorObj respuesta = new RespuestaDoctorObj();

                    if (resultado.Count > 0)
                    {
                        List<DoctorObj> datos = new List<DoctorObj>();

                        foreach (var item in resultado)
                        {
                            datos.Add(new DoctorObj 
                            {
                                IdDoctor = item.IdDoctor,
                                IdUsuario = item.IdUsuario,
                                Nombre = item.segundoApellido,
                                Apellido1 = item.primerApellido,
                                Apellido2 = item.segundoApellido,
                                Cedula = item.cedula,
                                Telefono = item.telefono,
                                Email = item.Email,
                                Genero = item.genero,
                                FechaMacimiento = item.FechaNacimiento,
                                State = item.state

                            });
                        }

                        respuesta.Codigo = 1;
                        respuesta.Mensaje = "Ok";
                        respuesta.lista = datos;
                    }
                    else
                    {
                        respuesta.Codigo = 0;
                        respuesta.Mensaje = "No se encontraron resultados";
                    }

                    return respuesta;
                }
            }
            catch (Exception ex)
            {
                RespuestaDoctorObj respuesta = new RespuestaDoctorObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }

        public RespuestaDoctorObj Registrar_Doctor(DoctorObj Doctor)
        {
            using (var con = new MOSSAEntities())
            {
                RespuestaDoctorObj respuesta = new RespuestaDoctorObj();

                var ExisteDoctor = (from x in con.Doctores
                                    where x.IdDoctor == Doctor.IdDoctor
                                    select x).FirstOrDefault();

                if (ExisteDoctor != null)
                {
                    respuesta.Codigo = 2;
                    respuesta.Mensaje = "El Id ya esta en uso";
                    return respuesta;
                }

                var resultado = con.Registrar_Doctor(Doctor.IdDoctor, Doctor.IdUsuario, Doctor.SalarioBruto, Doctor.HoraEntrada, Doctor.HoraSalida);


                if (resultado > 0)
                {
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Ok";
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "No se realizó la transacción";
                }

                return respuesta;
            }
        }
        //Editar Doctor
        public RespuestaDoctorObj Editar_Doctor(DoctorObj Doctor)
        {
            using (var con = new MOSSAEntities())
            {
                RespuestaDoctorObj respuesta = new RespuestaDoctorObj();

                var resultado = con.Editar_Doctor(Doctor.IdDoctor, Doctor.IdUsuario, Doctor.SalarioBruto, Doctor.HoraEntrada, Doctor.HoraSalida);

                if (resultado > 0)
                {
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Ok";
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "No se realizó la transacción";
                }

                return respuesta;
            }
        }
        //Mostrar Doctors activos 
        public RespuestaDoctorObj Consultar_Doctor_Estado(int indicador)
        {
            using (var con = new MOSSAEntities())
            {
                var resultado = con.Consultar_Doctor_Estado(indicador).ToList();

                RespuestaDoctorObj respuesta = new RespuestaDoctorObj();

                if (resultado > 0)
                {
                    List<DoctorObj> datos = new List<DoctorObj>();

                    foreach (var item in resultado)
                    {
                        datos.Add(new DoctorObj
                        {
                            IdDoctor = item.Nombre,
                            IdUsuario = item.primerApellido,
                            SalarioBruto = item.segundoApellido,
                            HoraEntrada = item.cedula,
                            HoraSalida = item.telefono
                        });
                    }

                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Ok";
                    respuesta.lista = datos;
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "No se encontraron resultados";
                }

                return respuesta;
            }
        }

        public RespuestaDoctorObj Consultar_IdDoctor(int idDoctor)
        {
            using (var con = new MOSSAEntities())
            {
                var resultado = con.Consultar_IdDoctor(idDoctor).ToList();

                RespuestaDoctorObj respuesta = new RespuestaDoctorObj();

                if (resultado > 0)
                {
                    List<DoctorObj> datos = new List<DoctorObj>();

                    foreach (var item in resultado)
                    {
                        datos.Add(new DoctorObj
                        {
                            IdDoctor = item.idDoctor,
                            IdUsuario = item.idUsuario,
                            SalarioBruto = item.salarioBruto,
                            HoraEntrada = item.horaEntrada,
                            HoraSalida = item.horaSalida

                        });
                    }

                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Ok";
                    respuesta.lista = datos;
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "No se encontraron resultados";
                }

                return respuesta;
            }
        }
    }
}
    
