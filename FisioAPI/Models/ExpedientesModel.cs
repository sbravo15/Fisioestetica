using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using FisioAPI.Database;
using System.IdentityModel.Tokens;
using Microsoft.IdentityModel.Tokens;
using SymmetricSecurityKey = Microsoft.IdentityModel.Tokens.SymmetricSecurityKey;
using SigningCredentials = Microsoft.IdentityModel.Tokens.SigningCredentials;


namespace FisioAPI.Models
{
    public class ExpedienteModel
    {

        //Guardar nuevo expediente 
        public RespuestaExpedientesObj Registrar_Expediente(ExpedientesObj expedientes)
        {
            using (var con = new MOSSAEntities())
            {
                RespuestaExpedientesObj respuesta = new RespuestaExpedientesObj();

               var resultado = con.Registrar_Expediente(expedientes.IdUsuario, expedientes.IdDoctor, expedientes.Padecimiento, expedientes.Tratamiento);


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
        //Editar expediente
        public RespuestaExpedientesObj Editar_Expediente(ExpedientesObj expedientes)
        {
            using (var con = new MOSSAEntities())
            {
                RespuestaExpedientesObj respuesta = new RespuestaExpedientesObj();

                var resultado = con.Registrar_Expediente(expedientes.IdUsuario, expedientes.IdDoctor, expedientes.Padecimiento, expedientes.Tratamiento);

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
        //Mostrar expedientes activos 
        public RespuestaExpedientesObj Consultar_Expediente_Paciente(int indicador)
        {
            using (var con = new MOSSAEntities())
            {
                var resultado = con.Consultar_Expediente_Paciente(indicador).ToList();

                RespuestaExpedientesObj respuesta = new RespuestaExpedientesObj();

                if (resultado.Count > 0)
                {
                    List<ExpedientesObj> datos = new List<ExpedientesObj>();

                    foreach (var item in resultado)
                    {
                        datos.Add(new ExpedientesObj
                        {
                            IdExpediente = item.IdExpediente,
                            IdUsuario = item.IdUsuarioFk,
                            IdDoctor = item.IdDoctorFK,
                            Padecimiento = item.Padecimiento,
                            Tratamiento = item.Tratamiento,                          
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

        //Mostrar el expediente en la pantalla de editar
        public RespuestaExpedientesObj Consultar_Expediente_Id(int id)
        {
            using (var con = new MOSSAEntities())
            {
                var resultado = (from x in con.Expediente
                                 where x.IdExpediente == id
                                 select x).FirstOrDefault();

                RespuestaExpedientesObj respuesta = new RespuestaExpedientesObj();

                if (resultado != null)
                {
                    ExpedientesObj expedienteEncontrado = new ExpedientesObj();

                    expedienteEncontrado.IdExpediente = resultado.IdExpediente;
                    expedienteEncontrado.IdUsuario = resultado.IdUsuarioFk;
                    expedienteEncontrado.IdDoctor = resultado.IdDoctorFK;
                    expedienteEncontrado.Padecimiento = resultado.Padecimiento;
                    expedienteEncontrado.Tratamiento = resultado.Tratamiento;                

                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Ok";
                    respuesta.objeto = expedienteEncontrado;
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "No se encontraron resultados";
                }

                return respuesta;
            }
        }

        //Creacion de token
        private string CrearToken(string Correo)
        {
            List<Claim> claims = new List<Claim> {
                new Claim(ClaimTypes.Name, Correo)
            };

            var llave = "c3e59tjnx02ovqdd51nwjjyzmmylbdfh";
            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(llave));
            var cred = new SigningCredentials(key, Microsoft.IdentityModel.Tokens.SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(15),
                signingCredentials: cred);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
