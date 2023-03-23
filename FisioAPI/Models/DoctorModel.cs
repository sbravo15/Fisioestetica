using FisioAPI.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FisioAPI.Models
{
    public class DoctorObj
    {
        public int IdDoctor { get; set; }
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido1 { get; set; }
        public string Apellido2 { get; set; }
        public string Cedula { get; set; }
        public int Telefono { get; set; }
        public string Email { get; set; }
        public string Genero { get; set; }
        public DateTime FechaMacimiento { get; set; }
        public int TipoUsuario { get; set; }
        public bool State { get; set; }
    }
    public class RespuestaDoctorObj
    {
        public int Codigo { get; set; }
        public string Mensaje { get; set; }
        public DoctorObj objeto { get; set; }
        public List<DoctorObj> lista { get; set; }

    }
    public RespuestaDoctorObj Registrar_Doctor(Doctorobj Doctor)
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
}