using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Business.Entity.EntRegistro;

/// <summary>
/// Descripción breve de ResPaciente
/// </summary>
public class ResPaciente
{
	public ResPaciente(){}
    public List<EntPaciente> pacientes { get; set; }
    public bool esError { get; set; }
    public string mensajeError { get; set; }
    public List<EntSexo> sexos { get; set; }
    public List<EntColonia> colonias { get; set; }
    public List<EntDelegacion> delegaciones { get; set; }

}