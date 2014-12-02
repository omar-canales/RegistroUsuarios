using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entity.EntRegistro;
using Data.DatRegistro;
using System.Data;

namespace Business.BusRegistro
{
    public class BusSexo
    {
        public BusSexo() { }

        public List<EntSexo> Obtener()
        {
            DataTable dt = new DatSexo().Obtener();
            List<EntSexo> lst = new List<EntSexo>();
            foreach (DataRow r in dt.Rows)
            {
                EntSexo ent = new EntSexo();
                ent.Id = Convert.ToInt32(r["Id_Sexo"]);
                ent.Nombre = r["Nombre_Sexo"].ToString();
                lst.Add(ent);
            }
            return lst;
        }
    }
}
