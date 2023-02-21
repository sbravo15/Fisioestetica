using System;
using FisioAPI.Database;

namespace FisioAPI.Models
{
    public class BitacoraModel
    {
        public void Registrar_Bitacora(string email, Exception ex, string origen)
        {
            using (var con = new MOSSAEntities())
            {
                con.Registrar_BitacoraE(email, DateTime.Now, ex.HResult, ex.Message, origen);

            }
        }
    }
}