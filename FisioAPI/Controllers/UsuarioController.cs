using System;
using FisioAPI.Models;
using System.Reflection;
using System.Threading;
using System.Web.Http;

namespace FisioAPI.Controllers
{
    public class UsuarioController : ApiController
    {
        UsuarioModel instanciaUsuario = new UsuarioModel();
        BitacoraModel instanciaBitacora = new BitacoraModel();


        //Revisa que el usuario exista en el sistema 
        [AllowAnonymous]
        [HttpPost]
        [Route("api/Usuario/Validar_Usuario")]
        public RespuestaUsuarioObj Validar_Usuario(UsuarioObj usuario)
        {
            try
            {
                return instanciaUsuario.Validar_Usuario(usuario);
            }
            catch (Exception ex)
            {
                instanciaBitacora.Registrar_Bitacora(usuario.Email, ex, MethodBase.GetCurrentMethod().Name);

                RespuestaUsuarioObj respuesta = new RespuestaUsuarioObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }

        //Registra usuarios nuevos
        [AllowAnonymous]
        [HttpPost]
        [Route("api/Usuario/Registrar_Usuario")]
        public RespuestaUsuarioObj Registrar_Usuario(UsuarioObj usuario)
        {
            try
            {
                return instanciaUsuario.Registrar_Usuario(usuario);
            }
            catch (Exception ex)
            {
                instanciaBitacora.Registrar_Bitacora(usuario.Email, ex, MethodBase.GetCurrentMethod().Name);

                RespuestaUsuarioObj respuesta = new RespuestaUsuarioObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }

        //Edita usuarios
        [Authorize]
        [HttpPut]
        [Route("api/Usuario/Editar_Usuario")]
        public RespuestaUsuarioObj Editar_Usuario(UsuarioObj usuario)
        {
            try
            {
                return instanciaUsuario.Editar_Usuario(usuario);
            }
            catch (Exception ex)
            {
                instanciaBitacora.Registrar_Bitacora(usuario.Email, ex, MethodBase.GetCurrentMethod().Name);

                RespuestaUsuarioObj respuesta = new RespuestaUsuarioObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }


        //consulta los usuarios en determinado estado
        [Authorize]
        [HttpGet]
        [Route("api/Usuario/Consultar_Usuarios_Estado")]
        public RespuestaUsuarioObj Consultar_Usuarios_Estado(int indicador)
        {
            var correoToken = Thread.CurrentPrincipal.Identity.Name;
            try
            {
                return instanciaUsuario.Consultar_Usuarios_Estado(indicador);
            }
            catch (Exception ex)
            {
                instanciaBitacora.Registrar_Bitacora(correoToken, ex, MethodBase.GetCurrentMethod().Name);

                RespuestaUsuarioObj respuesta = new RespuestaUsuarioObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }

        //Consulta usario por numero de ID
        [Authorize]
        [HttpGet]
        [Route("api/Usuario/Consultar_Usuario_Id")]
        public RespuestaUsuarioObj Consultar_Usuario_Id(int id)
        {
            var correoToken = Thread.CurrentPrincipal.Identity.Name;
            try
            {
                return instanciaUsuario.Consultar_Usuario_Id(id);
            }
            catch (Exception ex)
            {
                instanciaBitacora.Registrar_Bitacora(correoToken, ex, MethodBase.GetCurrentMethod().Name);

                RespuestaUsuarioObj respuesta = new RespuestaUsuarioObj();
                respuesta.Codigo = -1;
                respuesta.Mensaje = "Se presentó un error inesperado";
                return respuesta;
            }
        }
    }

}
