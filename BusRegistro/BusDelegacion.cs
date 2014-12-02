using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entity.EntRegistro;
using System.Data;
using Data.DatRegistro;

namespace Business.BusRegistro
{
    public class BusDelegacion
    {
        public BusDelegacion() { }

        public List<EntDelegacion> Obtener()
        {
            DataTable dt = new DatDelegacion().Obtener();
            List<EntDelegacion> lst = new List<EntDelegacion>();
            foreach (DataRow r in dt.Rows)
            {
                EntDelegacion ent = new EntDelegacion();
                ent.Id = Convert.ToInt32(r["Id_Delegacion"]);
                ent.Nombre = r["Nombre_Delegacion"].ToString();
                lst.Add(ent);
            }
            return lst;
        }


        public List<EntDelegacion> Obtener(int delegacion)
        {
            DataTable dt = new DatDelegacion().Obtener(delegacion);
            List<EntDelegacion> lst = new List<EntDelegacion>();
            foreach (DataRow r in dt.Rows)
            {
                EntDelegacion ent = new EntDelegacion();
                ent.Id = Convert.ToInt32(r["Id_Delegacion"]);
                ent.Nombre = r["Nombre_Delegacion"].ToString();
                lst.Add(ent);
            }
            return lst;
        }
    }
}
