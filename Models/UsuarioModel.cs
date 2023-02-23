using System;
using G7.Models;
using System.Collections.Generic;
using System.IO;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Web;


namespace G7.Models
{
    internal class UsuarioModel
    {
        public RespuestaUsuarioObj Validar_Usuario(UsuarioObj usuario)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Usuario/Validar_Usuario";

                JsonContent contenido = JsonContent.Create(usuario);

                HttpResponseMessage respuesta = client.PostAsync(rutaApi, contenido).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<RespuestaUsuarioObj>().Result;
                }
                return null;
            }

        }

        public RespuestaUsuarioObj Consultar_Usuarios_Estado(int indicador)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Usuario/Consultar_Usuarios_Estado?indicador=" + indicador;
                string token = HttpContext.Current.Session["codigoToken"].ToString();

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    //Deserializar --> System.Net.Http.Formatting.Extension
                    return respuesta.Content.ReadAsAsync<RespuestaUsuarioObj>().Result;
                }
                return null;
            }
        }

        public RespuestaUsuarioObj RegistrarUsuarios(UsuarioObj usuario)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Usuario/Registrar_Usuario";

                JsonContent contenido = JsonContent.Create(usuario);

                HttpResponseMessage respuesta = client.PostAsync(rutaApi, contenido).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<RespuestaUsuarioObj>().Result;
                }
                return null;
            }

        }

        public RespuestaUsuarioObj EditarUsuarios(UsuarioObj usuario)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Usuario/Editar_Usuario";
                string token = HttpContext.Current.Session["codigoToken"].ToString();

                JsonContent contenido = JsonContent.Create(usuario);

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.PutAsync(rutaApi, contenido).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    return respuesta.Content.ReadAsAsync<RespuestaUsuarioObj>().Result;
                }
                return null;
            }

        }

        public RespuestaUsuarioObj Consultar_Usuario_Id(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/Usuario/Consultar_Usuario_Id?id=" + id;
                string token = HttpContext.Current.Session["codigoToken"].ToString();

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    //Deserializar --> System.Net.Http.Formatting.Extension
                    return respuesta.Content.ReadAsAsync<RespuestaUsuarioObj>().Result;
                }
                return null;
            }
        }

        public TipoUsuarioObj.RespuestaTiposUsuarioObj Consultar_Tipos_Usuario()
        {
            using (HttpClient client = new HttpClient())
            {
                string rutaApi = ConfigurationManager.AppSettings["rutaApi"] + "api/TiposUsuario/Consultar_Tipos_Usuario";
                string token = HttpContext.Current.Session["codigoToken"].ToString();

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage respuesta = client.GetAsync(rutaApi).Result;

                if (respuesta.IsSuccessStatusCode)
                {
                    //Deserializar --> System.Net.Http.Formatting.Extension
                    return respuesta.Content.ReadAsAsync<TipoUsuarioObj.RespuestaTiposUsuarioObj>().Result;
                }
                return null;
            }
        }
    }
}