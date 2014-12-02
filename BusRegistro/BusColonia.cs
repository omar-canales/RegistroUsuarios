using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entity.EntRegistro;
using Data.DatRegistro;
using System.Data;

namespace Business.BusRegistro
{
    public class BusColonia
    {
        public BusColonia() { }

        public List<EntColonia> Obtener()
        {
            DataTable dt = new DatColonia().Obtener();
            List<EntColonia> lst = new List<EntColonia>();
            foreach (DataRow r in dt.Rows)
            {
                EntColonia ent = new EntColonia();
                ent.Id = Convert.ToInt32(r["Id_Colonia"]);
                ent.Nombre = r["Nombre_Colonia"].ToString();
                ent.IdDelegacion = Convert.ToInt32(r["Id_Delegacion_Colonia"]);
                lst.Add(ent);
            }
            return lst;
        }

        public List<EntColonia> Obtener(int colonia)
        {
            DataTable dt = new DatColonia().Obtener(colonia);
            List<EntColonia> lst = new List<EntColonia>();
            foreach (DataRow r in dt.Rows)
            {
                EntColonia ent = new EntColonia();
                ent.Id = Convert.ToInt32(r["Id_Colonia"]);
                ent.Nombre = r["Nombre_Colonia"].ToString();
                ent.IdDelegacion = Convert.ToInt32(r["Id_Delegacion_Colonia"]);
                lst.Add(ent);
            }
            return lst;
        }
    }
}
