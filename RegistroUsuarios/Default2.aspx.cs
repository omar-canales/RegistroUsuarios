using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Business.BusRegistro;
using Business.Entity.EntRegistro;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LlenargvPacientes();
            LlenarddlSexo();
            LlenarddlDelegacion();
        }
    }

    public void LlenargvPacientes()
    {
        gvPacientes.DataSource = new BusPaciente().Obtener();
        gvPacientes.DataBind();
    }

    public void LlenarddlColonia()
    {
        DropDownList ddlColonia = (DropDownList)gvPacientes.FooterRow.FindControl("ddlColoniaFT");
        ddlColonia.DataSource = new BusColonia().Obtener();
        ddlColonia.DataTextField = "Nombre";
        ddlColonia.DataValueField = "Id";
        ddlColonia.DataBind();
    }

    public void LlenarddlDelegacion()
    {
        DropDownList ddlDelegacion = (DropDownList)gvPacientes.FooterRow.FindControl("ddlDelegacionFT");
        ddlDelegacion.DataSource = new BusDelegacion().Obtener();
        ddlDelegacion.DataTextField = "Nombre";
        ddlDelegacion.DataValueField = "Id";
        ddlDelegacion.DataBind();
    }

    public void LlenarddlSexo()
    {
        DropDownList ddlSexo = (DropDownList)gvPacientes.FooterRow.FindControl("ddlSexoFT");
        ddlSexo.DataSource = new BusSexo().Obtener();
        ddlSexo.DataTextField = "Nombre";
        ddlSexo.DataValueField = "Id";
        ddlSexo.DataBind();
    }
    protected void gvPacientes_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        gvPacientes.EditIndex = -1;
        LlenargvPacientes();
        LlenarddlSexo();
        LlenarddlDelegacion();
        LlenarddlColonia();
    }
    protected void gvPacientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        int id = Convert.ToInt32(gvPacientes.DataKeys[e.RowIndex].Values["Id"]);
        new BusPaciente().Eliminar(id);
        Response.Redirect(Request.CurrentExecutionFilePath);
    }
    protected void gvPacientes_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            gvPacientes.EditIndex = e.NewEditIndex;
            LlenargvPacientes();

            hfFila.Value = e.NewEditIndex.ToString();

            DropDownList ddlSexo = (DropDownList)gvPacientes.Rows[e.NewEditIndex].FindControl("ddlSexoEIT");
            ddlSexo.DataSource = new BusSexo().Obtener();
            ddlSexo.DataTextField = "Nombre";
            ddlSexo.DataValueField = "Id";
            ddlSexo.DataBind();
            ddlSexo.SelectedValue = gvPacientes.DataKeys[e.NewEditIndex].Values["IdSexo"].ToString();

            DropDownList ddlDelegacion = (DropDownList)gvPacientes.Rows[e.NewEditIndex].FindControl("ddlDelegacionEIT");
            ddlDelegacion.DataSource = new BusDelegacion().Obtener();
            ddlDelegacion.DataTextField = "Nombre";
            ddlDelegacion.DataValueField = "Id";
            ddlDelegacion.DataBind();
            ddlDelegacion.SelectedValue = gvPacientes.DataKeys[e.NewEditIndex].Values["IdDelegacion"].ToString();

            DropDownList ddlColonia = (DropDownList)gvPacientes.Rows[e.NewEditIndex].FindControl("ddlColoniaEIT");
            ddlColonia.DataSource = new BusColonia().Obtener();
            ddlColonia.DataTextField = "Nombre";
            ddlColonia.DataValueField = "Id";
            ddlColonia.DataBind();
            ddlColonia.SelectedValue = gvPacientes.DataKeys[e.NewEditIndex].Values["IdColonia"].ToString();
        }
        catch (Exception ex)
        {

            MostrarMensaje(ex.Message);
        }

    }
    protected void gvPacientes_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            EntPaciente ent = new EntPaciente();
            ent.Id = Convert.ToInt32(gvPacientes.DataKeys[e.RowIndex].Values["Id"]);
            //ent.Estatus = Convert.ToBoolean(((CheckBox)gvPacientes.Rows[e.RowIndex].FindControl("chkEstatusEIT")).Checked);
            ent.Nombre = ((TextBox)gvPacientes.Rows[e.RowIndex].FindControl("txtNombreEIT")).Text;
            ent.Paterno = ((TextBox)gvPacientes.Rows[e.RowIndex].FindControl("txtPaternoEIT")).Text;
            ent.Materno = ((TextBox)gvPacientes.Rows[e.RowIndex].FindControl("txtMaternoEIT")).Text;
            ent.IdSexo = Convert.ToInt32(((DropDownList)gvPacientes.Rows[e.RowIndex].FindControl("ddlSexoEIT")).SelectedValue);
            ent.Calle = ((TextBox)gvPacientes.Rows[e.RowIndex].FindControl("txtCalleEIT")).Text;
            ent.Numero = ((TextBox)gvPacientes.Rows[e.RowIndex].FindControl("txtNumeroEIT")).Text;
            ent.IdDelegacion = Convert.ToInt32(((DropDownList)gvPacientes.Rows[e.RowIndex].FindControl("ddlDelegacionEIT")).SelectedValue);
            ent.IdColonia = Convert.ToInt32(((DropDownList)gvPacientes.Rows[e.RowIndex].FindControl("ddlColoniaEIT")).SelectedValue);
            ent.Horario = ((TextBox)gvPacientes.Rows[e.RowIndex].FindControl("txtHorarioEIT")).Text;
            ent.Edad = Convert.ToInt32(((TextBox)gvPacientes.Rows[e.RowIndex].FindControl("txtEdadEIT")).Text);
            ent.Alergia = ((TextBox)gvPacientes.Rows[e.RowIndex].FindControl("txtAlergiasEIT")).Text;
            //ent.FechaAlta = Convert.ToDateTime(((TextBox)gvPacientes.Rows[e.RowIndex].FindControl("txtFechaEIT")).Text);
            BusPaciente obj = new BusPaciente();
            obj.Actualizar(ent);
            Response.Redirect(Request.CurrentExecutionFilePath);
        }
        catch (Exception ex)
        {

            MostrarMensaje(ex.Message);
        }
    }
    protected void lnkAgregar_Click(object sender, EventArgs e)
    {
        try
        {
            EntPaciente ent = new EntPaciente();
            ent.Estatus = Convert.ToBoolean(((CheckBox)gvPacientes.FooterRow.FindControl("chkEstatusFT")).Checked);
            ent.Nombre = ((TextBox)gvPacientes.FooterRow.FindControl("txtNombreFT")).Text;
            ent.Paterno = ((TextBox)gvPacientes.FooterRow.FindControl("txtPaternoFT")).Text;
            ent.Materno = ((TextBox)gvPacientes.FooterRow.FindControl("txtMaternoFT")).Text;
            ent.IdSexo = Convert.ToInt32(((DropDownList)gvPacientes.FooterRow.FindControl("ddlSexoFT")).SelectedValue);
            ent.Calle = ((TextBox)gvPacientes.FooterRow.FindControl("txtCalleFT")).Text;
            ent.Numero = ((TextBox)gvPacientes.FooterRow.FindControl("txtNumeroFT")).Text;
            ent.IdDelegacion = Convert.ToInt32(((DropDownList)gvPacientes.FooterRow.FindControl("ddlDelegacionFT")).SelectedValue);
            ent.IdColonia = Convert.ToInt32(((DropDownList)gvPacientes.FooterRow.FindControl("ddlColoniaFT")).SelectedValue);
            ent.Horario = ((TextBox)gvPacientes.FooterRow.FindControl("txtHorarioFT")).Text;
            ent.Edad = Convert.ToInt32(((TextBox)gvPacientes.FooterRow.FindControl("txtEdadFT")).Text);
            ent.Alergia = ((TextBox)gvPacientes.FooterRow.FindControl("txtAlergiasFT")).Text;
            //ent.FechaAlta = Convert.ToDateTime(((TextBox)gvPacientes.FooterRow.FindControl("txtFechaFT")).Text);
            BusPaciente obj = new BusPaciente();
            obj.Insertar(ent);
            Response.Redirect(Request.CurrentExecutionFilePath);
        }
        catch (Exception ex)
        {

            MostrarMensaje(ex.Message);
        }
    }

    private void MostrarMensaje(string p)
    {
        string alerta = string.Format("alert ('{0}')", p.Replace("'", "").Replace("\n", "").Replace("\r", ""));
        ScriptManager.RegisterStartupScript(this, GetType(), "", alerta, true);
    }
    //protected void ddlDelegacionEIT_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    DropDownList ddl = (DropDownList)sender;
    //    int valor = Convert.ToInt32(ddl.SelectedValue);
    //    int fila = Convert.ToInt32(hfFila.Value);
    //    LlenarddlMarcaEIT(valor, fila);
    //    LlenarSubmarcaEIT(valor, fila);

    //}


    //protected void ddlDelegacionFT_SelectedIndexChanged(object sender, EventArgs e)
    //{
    //    DropDownList ddl = (DropDownList)sender;
    //    int valor = Convert.ToInt32(ddl.SelectedValue);
    //    LlenarddlMarcaFT(valor);
    //    LlenarSubmarcaFT(valor);
    //}
    protected void ddlDelegacionFT_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        int valor = Convert.ToInt32(ddl.SelectedValue);
        LlenarddlDelegacionFT(valor);
        LlenarddlColoniaFT(valor);
    }
    protected void ddlDelegacionEIT_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDownList ddl = (DropDownList)sender;
        int valor = Convert.ToInt32(ddl.SelectedValue);
        int fila = Convert.ToInt32(hfFila.Value);
        LlenarddlDelegacionEIT(valor, fila);
        LlenarddlColoniaEIT(valor, fila);
    }

    protected void LlenarddlDelegacionFT(int valor)
    {
        BusDelegacion delegacion = new BusDelegacion();
        DropDownList ddl = (DropDownList)gvPacientes.FooterRow.FindControl("ddlDelegacionFT");
        //ddl.Items.Clear();
        //ddl.Items.Add(new ListItem("[Delegación]", ["-1"]));
        ddl.DataTextField = "Nombre";
        ddl.DataValueField = "Id";
        ddl.DataSource = delegacion.Obtener(valor);
        ddl.DataBind();
    }
    protected void LlenarddlDelegacionEIT(int valor, int fila)
    {
        BusDelegacion delegacion = new BusDelegacion();
        DropDownList ddl = (DropDownList)gvPacientes.Rows[fila].FindControl("ddlDelegacionEIT");
        ddl.DataTextField = "Nombre";
        ddl.DataValueField = "Id";
        ddl.DataSource = delegacion.Obtener();
        ddl.DataBind();
        ddl.SelectedValue = valor.ToString();
    }
    private void LlenarddlColoniaFT(int valor)
    {
        BusColonia colonia = new BusColonia();
        DropDownList ddl = (DropDownList)gvPacientes.FooterRow.FindControl("ddlColoniaFT");
        ddl.Items.Clear();
        ddl.Items.Add(new ListItem("[Colonia]", "-1"));
        ddl.DataTextField = "Nombre";
        ddl.DataValueField = "Id";
        ddl.DataSource = colonia.Obtener(valor);
        ddl.DataBind();
    }
    private void LlenarddlColoniaEIT(int valor, int fila)
    {
        BusColonia colonia = new BusColonia();
        DropDownList ddl = (DropDownList)gvPacientes.Rows[fila].FindControl("ddlColoniaEIT");
        ddl.Items.Clear();
        ddl.Items.Add(new ListItem("[Colonia]", "-1"));
        ddl.DataTextField = "Nombre";
        ddl.DataValueField = "Id";
        ddl.DataSource = colonia.Obtener(valor);
        ddl.DataBind();
    }
    protected void gvPacientes_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            string columna;
            string direccion;
            gvPacientes.SelectedIndex = -1;
            gvPacientes.PageIndex = e.NewPageIndex;
            if (hfColumna.Value == "" || hfDireccion.Value == "")
            {
                columna = "[Nombre_Paciente]";
                direccion = "asc";
            }
            else
            {
                columna = hfColumna.Value;
                direccion = hfDireccion.Value;
            }
            gvPacientes.DataSource = new BusPaciente().Ordenado(columna, direccion);
            gvPacientes.DataBind();
        }
        catch (Exception ex)
        {

            MostrarMensaje(ex.Message);
        }
    }
    protected void gvPacientes_Sorting(object sender, GridViewSortEventArgs e)
    {
        string columna = e.SortExpression;
        string direccion = "";
        if (ViewState["orden"] == null)
        {
            direccion = "asc";
            ViewState["orden"] = "desc";
        }
        else
        {
            direccion = ViewState["orden"].ToString();
            if (direccion == "asc")
                ViewState["orden"] = "desc";
            else
                ViewState["orden"] = "asc";
        }
        hfColumna.Value = columna;
        hfDireccion.Value = direccion;
        gvPacientes.DataSource = new BusPaciente().Ordenado(columna, direccion);
        gvPacientes.DataBind();
    }
}