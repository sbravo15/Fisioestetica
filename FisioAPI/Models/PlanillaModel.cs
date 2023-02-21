using System;
using System.Collections.Generic;
using System.Linq;

using FisioAPI.Database;
using System.IdentityModel.Tokens;
using SymmetricSecurityKey = Microsoft.IdentityModel.Tokens.SymmetricSecurityKey;
using SigningCredentials = Microsoft.IdentityModel.Tokens.SigningCredentials;

namespace FisioAPI.Models
{
    public class PlanillaModel
    {
        public RespuestaPlanillaObj Registrar_Planilla(PlanillaObj planilla)
        {
            using (var con = new MOSSAEntities())
            {
                RespuestaPlanillaObj respuesta = new RespuestaPlanillaObj();

                var resultado = con.Registrar_Planilla(planilla.IdDoctor, planilla.Fecha ,planilla.HorasTrabajadas, planilla.SalarioBruto, planilla.Seguro, planilla.Deducciones, planilla.PagosExtra,
                    planilla.SalarioNeto);


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

        public RespuestaPlanillaObj Editar_Planilla(PlanillaObj planilla)
        {
            using (var con = new MOSSAEntities())
            {
                RespuestaPlanillaObj respuesta = new RespuestaPlanillaObj();

                var resultado = con.Editar_Datos_Planilla(planilla.IdPlanilla, planilla.IdDoctor, planilla.Fecha, planilla.HorasTrabajadas, planilla.SalarioBruto, planilla.Seguro, planilla.Deducciones, planilla.PagosExtra,
                    planilla.SalarioNeto);

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

        public RespuestaPlanillaObj Consultar_Planilla_Doctor(int idDoctor)
        {
            using (var con = new MOSSAEntities())
            {
                var resultado = con.Consultar_Planilla_Doctor(idDoctor).ToList();

                RespuestaPlanillaObj respuesta = new RespuestaPlanillaObj();

                if (resultado.Count > 0)
                {
                    List<PlanillaObj> datos = new List<PlanillaObj>();

                    foreach (var item in resultado)
                    {
                        datos.Add(new PlanillaObj
                        {
                            IdPlanilla = item.idPlanilla,
                            IdDoctor = item.IdDoctorFK,
                            Fecha = item.Fecha,
                            HorasTrabajadas = item.horasTrabajadas,
                            SalarioBruto = item.salarioBruto,
                            Seguro = item.seguro,
                            Deducciones = item.deducciones,
                            PagosExtra = item.pagosExtra,
                            SalarioNeto = item.salarioNeto                                               
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
        public RespuestaPlanillaObj Consultar_IdPlanilla(int idPlanilla)
        {
            using (var con = new MOSSAEntities())
            {
                var resultado = con.Consultar_IdPlanilla(idPlanilla).ToList();

                RespuestaPlanillaObj respuesta = new RespuestaPlanillaObj();

                if (resultado.Count > 0)
                {
                    List<PlanillaObj> datos = new List<PlanillaObj>();

                    foreach (var item in resultado)
                    {
                        datos.Add(new PlanillaObj
                        {
                            IdPlanilla = item.idPlanilla,
                            IdDoctor = item.IdDoctorFK,
                            Fecha = item.Fecha,
                            HorasTrabajadas = item.horasTrabajadas,
                            SalarioBruto = item.salarioBruto,
                            Seguro = item.seguro,
                            Deducciones = item.deducciones,
                            PagosExtra = item.pagosExtra,
                            SalarioNeto = item.salarioNeto
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
        public RespuestaPlanillaObj Consultar_Planilla()
        {
            using (var con = new MOSSAEntities())
            {
                var resultado = new List<Planilla>();

                resultado = (from x in con.Planilla
                             select x).ToList();

                RespuestaPlanillaObj respuesta = new RespuestaPlanillaObj();

                if (resultado.Count > 0)
                {
                    List<PlanillaObj> datos = new List<PlanillaObj>();

                    foreach (var item in resultado)
                    {
                        datos.Add(new PlanillaObj
                        {
                            IdPlanilla = item.idPlanilla,
                            IdDoctor = item.IdDoctorFK,
                            Fecha = item.Fecha,
                            HorasTrabajadas = item.horasTrabajadas,
                            SalarioBruto = item.salarioBruto,
                            Seguro = item.seguro,
                            Deducciones = item.deducciones,
                            PagosExtra = item.pagosExtra,
                            SalarioNeto = item.salarioNeto
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