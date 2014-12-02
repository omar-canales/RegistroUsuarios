using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace Data.DatRegistro
{
    public class DatPaciente
    {
        SqlConnection con;
        public DatPaciente()
        {
            con = new SqlConnection();
            con.ConnectionString = UtiCrypto.DesEncriptar(ConfigurationManager.ConnectionStrings["RegistroPacientes"].ConnectionString);
        }

        public DataTable Obtener()
        {
            try
            {
                SqlCommand com = new SqlCommand("spObtenerPacientes", con);
                com.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error el Obtener Pacientes , --" + ex.Message);
            }
        }

        public int Insertar( string nombre, string paterno, string materno, int sexo, string calle, string numero, int delegacion, int colonia, string horario, int edad, string alergias)
        {
            try
            {
                SqlCommand com = new SqlCommand("spInsertarPaciente", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Value = nombre, ParameterName = "@Nombre" });
                com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Value = paterno, ParameterName = "@Paterno" });
                com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Value = materno, ParameterName = "@Materno" });
                com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, Value = sexo, ParameterName = "@Sexo" });
                com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Value = calle, ParameterName = "@Calle" });
                com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Value = numero, ParameterName = "@Numero" });
                com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, Value = delegacion, ParameterName = "@Delegacion" });
                com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, Value = colonia, ParameterName = "@Colonia" });
                com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Value = horario, ParameterName = "@Horario" });
                com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, Value = edad, ParameterName = "@Edad" });
                com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Value = alergias, ParameterName = "@Alergias" });
                con.Open();
                int filas = com.ExecuteNonQuery();
                con.Close();
                return filas;
            }
            catch (Exception ex)
            {
                con.Close();
                throw new ApplicationException("Error al Insertar a Paciente, --" + ex.Message);
            }
        }

        public int Actualizar(string nombre, string paterno, string materno, int sexo, string calle, string numero, int delegacion, int colonia, string horario, int edad, string alergias, int id)
        {
            try
            {
                SqlCommand com = new SqlCommand("spActualizarPaciente", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Value = nombre, ParameterName = "@Nombre" });
                com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Value = paterno, ParameterName = "@Paterno" });
                com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Value = materno, ParameterName = "@Materno" });
                com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, Value = sexo, ParameterName = "@Sexo" });
                com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Value = calle, ParameterName = "@Calle" });
                com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Value = numero, ParameterName = "@Numero" });
                com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, Value = delegacion, ParameterName = "@Delegacion" });
                com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, Value = colonia, ParameterName = "@Colonia" });
                com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Value = horario, ParameterName = "@Horario" });
                com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, Value = edad, ParameterName = "@Edad" });
                com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Value = alergias, ParameterName = "@Alergias" });
                com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, Value = id, ParameterName = "@Id" });
                con.Open();
                int filas = com.ExecuteNonQuery();
                con.Close();
                return filas;
            }
            catch (Exception ex)
            {
                con.Close();
                throw new ApplicationException("Error al Actualizar Paciente ,--" + ex.Message);
            }
        }

        public int Eliminar(int id)
        {
            try
            {
                SqlCommand com = new SqlCommand("spEliminarPaciente", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, Value = id, ParameterName = "Id" });
                con.Open();
                int filas = com.ExecuteNonQuery();
                con.Close();
                return filas;
            }
            catch (Exception ex)
            {
                con.Close();
                throw new ApplicationException("Error al Eliminar a Paciente, --" + ex.Message);
            }
        }

        public bool Validar(string nombre, string paterno)
        {
            try
            {
                SqlCommand com = new SqlCommand("spValidarInsertar", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Value = nombre, ParameterName = "@Nombre" });
                com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Value = paterno, ParameterName = "@Paterno" });
                con.Open();
                bool existe = Convert.ToBoolean(com.ExecuteScalar());
                con.Close();
                return existe;
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error al Validar Insertar, --" + ex.Message);
            }
        }

        public bool Validar(string nombre, string paterno, int id)
        {
            try
            {
                SqlCommand com = new SqlCommand("spValidarActualizar", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Value = nombre, ParameterName = "@Nombre" });
                com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Value = paterno, ParameterName = "@Paterno" });
                com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.Int, Value = id, ParameterName = "@Id" });
                con.Open();
                bool existe = Convert.ToBoolean(com.ExecuteScalar());
                con.Close();
                return existe;
            }
            catch (Exception ex)
            {

                throw new ApplicationException("Error al Validar Actualizar, --" + ex.Message);
            }
        }

        public DataTable Obtener(string columna, string direccion)
        {
            SqlCommand com = new SqlCommand("spObtenerOrdenado", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Value = columna, ParameterName = "@Columna" });
            com.Parameters.Add(new SqlParameter() { SqlDbType = SqlDbType.NVarChar, Value = direccion, ParameterName = "@Direccion" });
            SqlDataAdapter da = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
    }
}
//Id_Paciente, Estatus_Paciente, Nombre_Paciente, Paterno_Paciente, Materno_Paciente, 
//    Id_Sexo_Paciente, Calle_Paciente, Numero_Paciente, Id_Delegacion_Paciente, Id_Colonia_Paciente, 
//    Horario_Paciente, Edad_Paciente, Alergias, Fecha_Alta_Paciente,
//    Id_Sexo, Nombre_Sexo,
//    Id_Delegacion, Nombre_Delegacion,
//    Id_Colonia, Nombre_Colonia, Id_Delegacion_Colonia