using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Data.DatRegistro
{
    public class DatSexo
    {
        SqlConnection con;
        public DatSexo() 
        {
            con = new SqlConnection();
            con.ConnectionString = UtiCrypto.DesEncriptar(ConfigurationManager.ConnectionStrings["RegistroPacientes"].ConnectionString);

        }

        public DataTable Obtener()
        {
            SqlCommand com = new SqlCommand("spObtenerSexo", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
