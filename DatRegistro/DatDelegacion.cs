using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Data.DatRegistro
{
    public class DatDelegacion
    {
        SqlConnection con;
        public DatDelegacion()
        {
            con = new SqlConnection();
            con.ConnectionString = UtiCrypto.DesEncriptar(ConfigurationManager.ConnectionStrings["RegistroPacientes"].ConnectionString);

        }

        public DataTable Obtener()
        {
            SqlCommand com = new SqlCommand("spObtenerDelegacion", con);
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }


        public DataTable Obtener(int delegacion)
        {
            SqlCommand com = new SqlCommand("spObtenerIdDelegacion", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, Value = delegacion, ParameterName = "@Id"});
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
