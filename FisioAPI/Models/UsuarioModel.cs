using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using FisioAPI.Database;
using System.IdentityModel.Tokens;
using SymmetricSecurityKey = Microsoft.IdentityModel.Tokens.SymmetricSecurityKey;
using SigningCredentials = Microsoft.IdentityModel.Tokens.SigningCredentials;

namespace FisioAPI.Models
{
    public class UsuarioModel
    {
        //Validar usuario por mail y contraseña 
        public RespuestaUsuarioObj Validar_Usuario(UsuarioObj usuario)
        {
            using (var con = new MOSSAEntities())
            {
                var resultado = con.Consultar_Datos_Usuario(usuario.Email, usuario.Contrasenna).FirstOrDefault();
                RespuestaUsuarioObj respuesta = new RespuestaUsuarioObj();

                if (resultado != null)
                {
                    UsuarioObj usuarioEncontrado = new UsuarioObj();

                    /*usuarioEncontrado.IdUsuario = resultado.IdUsuario;*/
                    usuarioEncontrado.Nombre = resultado.Nombre;
                    usuarioEncontrado.Apellido1 = resultado.primerApellido;
                    usuarioEncontrado.Apellido2 = resultado.segundoApellido;
                    usuarioEncontrado.Cedula = resultado.cedula;
                    usuarioEncontrado.Telefono = resultado.telefono;
                    usuarioEncontrado.Email = resultado.Email;
                    usuarioEncontrado.Genero = resultado.genero;
                    usuarioEncontrado.Edad = resultado.edad;
                    usuarioEncontrado.TipoUsuario = resultado.idTipoPersonaFk;
                    usuarioEncontrado.Token = CrearToken(usuario.Email);

                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Ok";
                    respuesta.objeto = usuarioEncontrado;
                }
                else
                {
                    respuesta.Codigo = 0;
                    respuesta.Mensaje = "No se encontraron resultados";
                }

                return respuesta;
            }
        }
        //Guardar nuevo usuario 
        public RespuestaUsuarioObj Registrar_Usuario(UsuarioObj usuario)
        {
            using (var con = new MOSSAEntities())
            {
                RespuestaUsuarioObj respuesta = new RespuestaUsuarioObj();

                var existeCorreo = (from x in con.Usuario
                                    where x.email == usuario.Email
                                    select x).FirstOrDefault();

                if (existeCorreo != null)
                {
                    respuesta.Codigo = 2;
                    respuesta.Mensaje = "El correo ya existe";
                    return respuesta;
                }

                var resultado = con.Registrar_Datos_Usuario(usuario.Nombre, usuario.Apellido1, usuario.Apellido2, usuario.Cedula, usuario.Telefono, usuario.Email,
                    usuario.Genero, usuario.Edad, usuario.Contrasenna, usuario.TipoUsuario);


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
        //Editar usuario
        public RespuestaUsuarioObj Editar_Usuario(UsuarioObj usuario)
        {
            using (var con = new MOSSAEntities())
            {
                RespuestaUsuarioObj respuesta = new RespuestaUsuarioObj();

                var existeCorreo = (from x in con.Usuario
                                    where x.email == usuario.Email && x.IdUsuario != usuario.IdUsuario
                                    select x).FirstOrDefault();

                if (existeCorreo != null)
                {
                    respuesta.Codigo = 2;
                    respuesta.Mensaje = "El correo ya existe";
                    return respuesta;
                }

                var resultado = con.Editar_Datos_Usuario(usuario.Nombre, usuario.Apellido1, usuario.Apellido2, usuario.Cedula, usuario.Telefono, usuario.Email,
                    usuario.Genero, usuario.Edad, usuario.Contrasenna, usuario.TipoUsuario, usuario.State, usuario.IdUsuario);

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
        //Mostrar usuarios activos 
        public RespuestaUsuarioObj Consultar_Usuarios_Estado(int indicador)
        {
            using (var con = new MOSSAEntities())
            {
                var resultado = con.Consultar_Usuarios_Estado(indicador).ToList();

                RespuestaUsuarioObj respuesta = new RespuestaUsuarioObj();

                if (resultado.Count > 0)
                {
                    List<UsuarioObj> datos = new List<UsuarioObj>();

                    foreach (var item in resultado)
                    {
                        datos.Add(new UsuarioObj
                        {
                            Nombre = item.Nombre,
                            Apellido1 = item.primerApellido,
                            Apellido2 = item.segundoApellido,
                            Cedula = item.cedula,
                            Telefono = item.telefono,
                            Email = item.Email,
                            Genero = item.genero,
                            Edad = item.edad,
                            TipoUsuario = item.idTipoPersonaFk,
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

        //Mostrar el usuario en la pantalla de editar
        public RespuestaUsuarioObj Consultar_Usuario_Id(int id)
        {
            using (var con = new MOSSAEntities())
            {
                var resultado = (from x in con.Usuario
                                 where x.IdUsuario == id
                                 select x).FirstOrDefault();

                RespuestaUsuarioObj respuesta = new RespuestaUsuarioObj();

                if (resultado != null)
                {
                    UsuarioObj usuarioEncontrado = new UsuarioObj();

                    usuarioEncontrado.Nombre = resultado.Nombre;
                    usuarioEncontrado.Apellido1 = resultado.primerApellido;
                    usuarioEncontrado.Apellido2 = resultado.segundoApellido;
                    usuarioEncontrado.Cedula = resultado.cedula;
                    usuarioEncontrado.Telefono = resultado.telefono;
                    usuarioEncontrado.Email = resultado.email;
                    usuarioEncontrado.Genero = resultado.genero;
                    usuarioEncontrado.Edad = resultado.edad;
                    usuarioEncontrado.TipoUsuario = resultado.idTipoPersonaFk;
                   
                    respuesta.Codigo = 1;
                    respuesta.Mensaje = "Ok";
                    respuesta.objeto = usuarioEncontrado;
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