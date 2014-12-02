using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Business.Entity.EntRegistro;
using Data.DatRegistro;
using System.Data;

namespace Business.BusRegistro
{
    public class BusPaciente
    {
        public BusPaciente() { }

        public List<EntPaciente> Obtener()
        {
            DataTable dt = new DatPaciente().Obtener();
            List<EntPaciente> lst = new List<EntPaciente>();
            foreach (DataRow r in dt.Rows)
            {
                EntPaciente ent = new EntPaciente();
                ent.Id = Convert.ToInt32(r["Id_Paciente"]);
                ent.Estatus = Convert.ToBoolean(r["Estatus_Paciente"]);
                ent.Nombre = r["Nombre_Paciente"].ToString();
                ent.Paterno = r["Paterno_Paciente"].ToString();
                ent.Materno = r["Materno_Paciente"].ToString();
                ent.IdSexo = Convert.ToInt32(r["Id_Sexo_Paciente"]);
                ent.Sexo.Id = Convert.ToInt32(r["Id_Sexo"]);
                ent.Sexo.Nombre = r["Nombre_Sexo"].ToString();
                ent.Calle = r["Calle_Paciente"].ToString();
                ent.Numero = r["Numero_Paciente"].ToString();
                ent.IdDelegacion = Convert.ToInt32(r["Id_Delegacion_Paciente"]);
                ent.Delegacion.Id = Convert.ToInt32(r["Id_Delegacion"]);
                ent.Delegacion.Nombre = r["Nombre_Delegacion"].ToString();
                ent.IdColonia = Convert.ToInt32(r["Id_Colonia_Paciente"]);
                ent.Colonia.Id = Convert.ToInt32(r["Id_Colonia"]);
                ent.Colonia.Nombre = r["Nombre_Colonia"].ToString();
                ent.Horario = r["Horario_Paciente"].ToString();
                ent.Edad = Convert.ToInt32(r["Edad_Paciente"]);
                ent.Alergia = r["Alergias_Paciente"].ToString();
                ent.FechaAlta = Convert.ToDateTime(r["Fecha_Alta_Paciente"]);
                lst.Add(ent);
            }
            return lst;
        }

        public void Insertar(EntPaciente pac)
        {
             bool existe = new DatPaciente().Validar(pac.Nombre, pac.Paterno);
            if (existe)
                throw new ApplicationException(string.Format("El paciente {0} {1} ya se encuentra Registrado, ", pac.Nombre, pac.Paterno));
            int filas = new DatPaciente().Insertar(pac.Nombre, pac.Paterno, pac.Materno, pac.IdSexo, pac.Calle, pac.Numero, pac.IdDelegacion, pac.IdColonia, pac.Horario, pac.Edad, pac.Alergia);
            if (filas != 1)
                throw new ApplicationException(string.Format("Error al Insertar a {0} {1}", pac.Nombre, pac.Paterno));
        }

        public void Actualizar(EntPaciente pac)
        {
            bool existe = new DatPaciente().Validar(pac.Nombre, pac.Paterno, pac.Id);
            if (existe)
                throw new ApplicationException(string.Format("Error al Actualizar al paciente {0} {1}, ", pac.Nombre, pac.Paterno));
            int filas = new DatPaciente().Actualizar(pac.Nombre, pac.Paterno, pac.Materno, pac.IdSexo, pac.Calle, pac.Numero, pac.IdDelegacion, pac.IdColonia, pac.Horario, pac.Edad, pac.Alergia, pac.Id);
            if (filas != 1)
                 throw new ApplicationException(string.Format("Error al Actualizar a {0} {1}", pac.Nombre, pac.Paterno));
        }

        public void Eliminar(int id)
        {
            int filas = new DatPaciente().Eliminar(id);
            if (filas != 1)
                throw new ApplicationException("Error al Borrar a Paciente");
        }

        public List<EntPaciente> Ordenado(string columna, string direccion)
        {
            DataTable dt = new DatPaciente().Obtener(columna, direccion);
            List<EntPaciente> lst = new List<EntPaciente>();
            foreach (DataRow r in dt.Rows)
            {
                EntPaciente ent = new EntPaciente();
                ent.Id = Convert.ToInt32(r["Id_Paciente"]);
                ent.Estatus = Convert.ToBoolean(r["Estatus_Paciente"]);
                ent.Nombre = r["Nombre_Paciente"].ToString();
                ent.Paterno = r["Paterno_Paciente"].ToString();
                ent.Materno = r["Materno_Paciente"].ToString();
                ent.IdSexo = Convert.ToInt32(r["Id_Sexo_Paciente"]);
                ent.Sexo.Id = Convert.ToInt32(r["Id_Sexo"]);
                ent.Sexo.Nombre = r["Nombre_Sexo"].ToString();
                ent.Calle = r["Calle_Paciente"].ToString();
                ent.Numero = r["Numero_Paciente"].ToString();
                ent.IdDelegacion = Convert.ToInt32(r["Id_Delegacion_Paciente"]);
                ent.Delegacion.Id = Convert.ToInt32(r["Id_Delegacion"]);
                ent.Delegacion.Nombre = r["Nombre_Delegacion"].ToString();
                ent.IdColonia = Convert.ToInt32(r["Id_Colonia_Paciente"]);
                ent.Colonia.Id = Convert.ToInt32(r["Id_Colonia"]);
                ent.Colonia.Nombre = r["Nombre_Colonia"].ToString();
                ent.Horario = r["Horario_Paciente"].ToString();
                ent.Edad = Convert.ToInt32(r["Edad_Paciente"]);
                ent.Alergia = r["Alergias_Paciente"].ToString();
                ent.FechaAlta = Convert.ToDateTime(r["Fecha_Alta_Paciente"]);
                lst.Add(ent);
            }
            return lst;
        }
    }
}
