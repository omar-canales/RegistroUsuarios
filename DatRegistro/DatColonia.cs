using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Data.DatRegistro
{
    public class DatColonia
    {
        SqlConnection con;
        public DatColonia() 
        {
            con = new SqlConnection();
            con.ConnectionString = UtiCrypto.DesEncriptar(ConfigurationManager.ConnectionStrings["RegistroPacientes"].ConnectionString);

        }

        public DataTable Obtener()
        {
            SqlCommand com = new SqlCommand("spObtenerColonia", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public DataTable Obtener(int colonia)
        {
            SqlCommand com = new SqlCommand("spObtenerIdColonia", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, Value = colonia, ParameterName = "@Id"});
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt); 
            return dt;
        }
    }
}
