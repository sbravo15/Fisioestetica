using System;
using System.Collections.Generic;
using System.Linq;
using FisioAPI.Database;

namespace FisioAPI.Models
{
    public class DoctorModel
    {


        //Guardar nuevo Doctor 
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

                var resultado = con.Registrar_Doctor(Doctor.IdUsuario);


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

        public RespuestaDoctorObj Consultar_IdDoctor(int idDoctor)
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
    }
}