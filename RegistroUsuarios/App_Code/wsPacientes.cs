using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using Business.Entity.EntRegistro;
using Business.BusRegistro;

/// <summary>
/// Descripción breve de wsPacientes
/// </summary>
[WebService(Namespace = "http://omar.org/", Description="Web Service de Pacientes")]

public class wsPacientes : System.Web.Services.WebService {

    public wsPacientes () {

        //Eliminar la marca de comentario de la línea siguiente si utiliza los componentes diseñados 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld() {
        return "Hola a todos";
    }

    [WebMethod]
    public ResPaciente Obtener()
    {
        try
        {
            ResPaciente resp = new ResPaciente();
            resp.pacientes = new BusPaciente().Obtener();
            resp.esError = false; 
            return resp;
        }
        catch (Exception ex)
        {
            ResPaciente resp = new ResPaciente();
            resp.esError = true;
            resp.mensajeError = ex.Message;
            return resp;
        } 
    }

    [WebMethod]
    public ResPaciente ObtenerColonia()
    {
        try
        {
            ResPaciente resp = new ResPaciente();
            resp.colonias = new BusColonia().Obtener();
            resp.esError = false;
            return resp;
        }
        catch (Exception ex)
        {
            ResPaciente resp = new ResPaciente();
            resp.esError = false;
            resp.mensajeError = ex.Message;
            return resp;
        }
    }

    [WebMethod]
    public ResPaciente ObtenerDelegacion()
    {
        try
        {
            ResPaciente resp = new ResPaciente();
            resp.delegaciones = new BusDelegacion().Obtener();
            resp.esError = false;
            return resp;
        }
        catch (Exception ex)
        {
            ResPaciente resp = new ResPaciente();
            resp.esError = false;
            resp.mensajeError = ex.Message;
            return resp;
        }
    }

    [WebMethod]
    public ResPaciente ObtenerSexo()
    {
        try
        {
            ResPaciente resp = new ResPaciente();
            resp.sexos = new BusSexo().Obtener();
            resp.esError = false;
            return resp;
        }
        catch (Exception ex)
        {
            ResPaciente resp = new ResPaciente();
            resp.esError = false;
            resp.mensajeError = ex.Message;
            return resp;
        }
    }

    [WebMethod]
    public void Insertar(string nombre, string paterno, string materno, int sexo, string calle, string numero, int delegacion, int colonia, string horario, int edad, string alergias)
    {
        EntPaciente ent = new EntPaciente();
        ent.Nombre = nombre;
        ent.Materno = materno;
        ent.Paterno = paterno;
        ent.IdSexo = sexo;
        ent.Calle = calle;
        ent.Numero = numero;
        ent.IdDelegacion = delegacion;
        ent.IdColonia = colonia;
        ent.Horario = horario;
        ent.Edad = edad;
        ent.Alergia = alergias;
        new BusPaciente().Insertar(ent);
    }

    [WebMethod]
    public void Actualizar(string nombre, string paterno, string materno, int sexo, string calle, string numero, int delegacion, int colonia, string horario, int edad, string alergias, int id)
    {
        EntPaciente ent = new EntPaciente();
        ent.Nombre = nombre;
        ent.Paterno = paterno;
        ent.Materno = materno;
        ent.IdSexo = sexo;
        ent.Calle = calle;
        ent.Numero = numero;
        ent.IdDelegacion = delegacion;
        ent.IdColonia = colonia;
        ent.Horario = horario;
        ent.Edad = edad;
        ent.Alergia = alergias;
        ent.Id = id;
        new BusPaciente().Actualizar(ent);
    }

    [WebMethod]
    public void Eliminar(int id)
    {
        EntPaciente ent = new EntPaciente();
        ent.Id = id;
        new BusPaciente().Eliminar(id); 
    }

   
}
