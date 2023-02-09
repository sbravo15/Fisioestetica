using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using FisioAPI.Database;
using System.IdentityModel.Tokens;
using SymmetricSecurityKey = Microsoft.IdentityModel.Tokens.SymmetricSecurityKey;
using SigningCredentials = Microsoft.IdentityModel.Tokens.SigningCredentials;
using System.CodeDom;

// 1.  Registrar Cita, 2 Editar Citas , 3. Consultar Cita Doctor, 4. Consultar ID Citas, 5 . Consultar Todas las Citas
namespace FisioAPI.Models
{
    public class CitasModel
    {
        public RespuestaCitasObj Registrar_Cita(CitasObj cita)   // 1.  Registrar Cita
        {
            using (var con = new MOSSAEntities())
            {
                RespuestaCitasObj respuesta = new RespuestaCitasObj();

                var resultado = con.Registrar_Cita(cita.IdUsuario,cita.IdEmpleado,cita.Condicion, cita.Hora);

               

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


        public RespuestaCitasObj Editar_Cita(CitasObj cita)  // 2 Editar Citas 
        {
            using (var con = new MOSSAEntities())
            {
                RespuestaCitasObj respuesta = new RespuestaCitasObj();

                var resultado = con.Editar_Citas(cita.IdCita,cita.IdUsuario,cita.IdEmpleado,cita.Condicion,cita.Hora,cita.Status);

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


        public RespuestaCitasObj Consultar_Cita_Doctor(int idDoctor)   // 3. Consultar Cita Doctor 
        {
            using (var con = new MOSSAEntities())
            {
                var resultado = con.Consultar_Citas_Doctor(idDoctor).ToList();

                RespuestaCitasObj respuesta = new RespuestaCitasObj();

                if (resultado.Count > 0)
                {
                    List<CitasObj> datos = new List<CitasObj>();

                    foreach (var item in resultado)
                    {
                        datos.Add(new CitasObj
                        {
                            IdCita = item.IdCitas,
                            IdUsuario = item.IdUsuarioFk,
                            IdEmpleado = item.IdDoctorFK,
                            Condicion = item.condicion,
                            Hora = item.Hora,
                            Status = item.status
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


        public RespuestaCitasObj Consultar_IdCita(int idPaciente)    // 4. Consultar ID Citas
        {
            using (var con = new MOSSAEntities())
            {
                var resultado = con.Consultar_Citas_Paciente(idPaciente).ToList();

                RespuestaCitasObj respuesta = new RespuestaCitasObj();

                if (resultado.Count > 0)
                {
                    List<CitasObj> datos = new List<CitasObj>();

                    foreach (var item in resultado)
                    {
                        datos.Add(new CitasObj
                        {
                            IdCita = item.IdCitas,
                            IdUsuario = item.IdUsuarioFk,
                            IdEmpleado = item.IdDoctorFK,
                            Condicion = item.condicion,
                            Hora = item.Hora,
                            Status = item.status
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


        public RespuestaCitasObj Consultar_Citas()   // 5 . Consultar Todas las Citas
        {
            using (var con = new MOSSAEntities())
            {
                var resultado = new List<Citas>();

                resultado = (from x in con.Citas
                             select x).ToList();

                RespuestaCitasObj respuesta = new RespuestaCitasObj();

                if (resultado.Count > 0)
                {
                    List<CitasObj> datos = new List<CitasObj>();

                    foreach (var item in resultado)
                    {
                        datos.Add(new CitasObj
                        {
                            IdCita = item.IdCitas,
                            IdUsuario = item.IdUsuarioFk,
                            IdEmpleado = item.IdDoctorFK,
                            Condicion = item.condicion,
                            Hora = item.Hora,
                            Status = item.status
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