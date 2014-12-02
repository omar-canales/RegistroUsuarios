<%@ Page Language="C#" AutoEventWireup="true"
    CodeFile="Default2.aspx.cs" Inherits="Default2" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:HiddenField ID="hfFila" runat="server" />
    <asp:HiddenField ID="hfColumna" runat="server" />
    <asp:HiddenField ID="hfDireccion" runat="server" />
    <asp:GridView ID="gvPacientes" runat="server"
        AutoGenerateColumns="False" BackColor="White"
        BorderColor="#CCCCCC" BorderStyle="None"
        BorderWidth="1px" CellPadding="3" ShowFooter="True"
        OnRowCancelingEdit="gvPacientes_RowCancelingEdit"
        OnRowDeleting="gvPacientes_RowDeleting"
        OnRowEditing="gvPacientes_RowEditing"
        DataKeyNames="Id, IdSexo, IdDelegacion, IdColonia"
        OnRowUpdating="gvPacientes_RowUpdating"
        Style="margin-top: 0px" 
        AllowPaging="True" AllowSorting="True" 
        onpageindexchanging="gvPacientes_PageIndexChanging" 
        onsorting="gvPacientes_Sorting" 
        PageSize="3">
        <Columns>
            <asp:TemplateField HeaderText="Estatus">
                <EditItemTemplate>
                    <asp:CheckBox ID="chkEstatusEIT" runat="server"
                        Checked="true" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:CheckBox ID="Label1" runat="server"
                        Enabled="false" Checked="true" />
                </ItemTemplate>
                <FooterTemplate>
                    Estatus:
                    <br />
                    <asp:CheckBox ID="chkEstatusFT" Checked="true"
                        Enabled="false" runat="server" />
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Nombre">
                <EditItemTemplate>
                    <asp:TextBox ID="txtNombreEIT" Width="80px"
                        runat="server" Text='<%# Bind("Nombre") %>'></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="txtNombreEIT"
                        runat="server" ErrorMessage="RequiredFieldValidator" Text="****" ForeColor="Red" ValidationGroup="Edit"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("Nombre") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    Nombre:
                    <br />
                    <asp:TextBox ID="txtNombreFT" Width="80px"
                        runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1"
                        runat="server" ErrorMessage="Campo Obligatorio"
                        ControlToValidate="txtNombreFT" Text="****"
                        ForeColor="red" ValidationGroup="add"></asp:RequiredFieldValidator>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Paterno" SortExpression="Paterno_Paciente">
                <EditItemTemplate>
                    <asp:TextBox ID="txtPaternoEIT" Width="80px"
                        runat="server" Text='<%# Bind("Paterno") %>'></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ControlToValidate="txtPaternoEIT"
                        runat="server" ErrorMessage="RequiredFieldValidator" Text="****" ForeColor="Red" ValidationGroup="Edit"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("Paterno") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    Paterno:
                    <br />
                    <asp:TextBox ID="txtPaternoFT" Width="80px"
                        runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2"
                        runat="server" ErrorMessage="Campo Obligatorio"
                        ControlToValidate="txtPaternoFT" Text="****"
                        ForeColor="red" ValidationGroup="add"></asp:RequiredFieldValidator>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Materno">
                <EditItemTemplate>
                    <asp:TextBox ID="txtMaternoEIT" Width="80px"
                        runat="server" Text='<%# Bind("Materno") %>'></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator14" ControlToValidate="txtMaternoEIT"
                        runat="server" ErrorMessage="RequiredFieldValidator" Text="****" ForeColor="Red" ValidationGroup="Edit"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("Materno") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    Materno:
                    <br />
                    <asp:TextBox ID="txtMaternoFT" Width="80px"
                        runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3"
                        runat="server" ErrorMessage="Campo Obligatorio"
                        ControlToValidate="txtMaternoFT" Text="****"
                        ForeColor="red" ValidationGroup="add"></asp:RequiredFieldValidator>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Sexo">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlSexoEIT" runat="server" AppendDataBoundItems="true" />
                     <asp:RequiredFieldValidator ID="RequiredFieldValidator15" ControlToValidate="ddlSexoEIT"
                        runat="server" ErrorMessage="RequiredFieldValidator" Text="****" ForeColor="Red" ValidationGroup="Edit"></asp:RequiredFieldValidator>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label13" runat="server" Text='<%# Bind("Sexo.Nombre") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    Sexo:
                    <br />
                    <asp:DropDownList ID="ddlSexoFT" AppendDataBoundItems="true"
                        runat="server">
                        <asp:ListItem Value="-1">[Sexo]</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4"
                        runat="server" ErrorMessage="Campo Obligatorio"
                        ControlToValidate="ddlSexoFT" InitialValue="-1" Text="****"
                        ForeColor="red" ValidationGroup="add"></asp:RequiredFieldValidator>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Calle">
                <EditItemTemplate>
                    <asp:TextBox ID="txtCalleEIT" Width="80px"
                        runat="server" Text='<%# Bind("Calle") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text='<%# Bind("Calle") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    Calle:
                    <br />
                    <asp:TextBox ID="txtCalleFT" Width="80px"
                        runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator5"
                        runat="server" ErrorMessage="Campo Obligatorio"
                        ControlToValidate="txtCalleFT" Text="****"
                        ForeColor="red" ValidationGroup="add"></asp:RequiredFieldValidator>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Numero">
                <EditItemTemplate>
                    <asp:TextBox ID="txtNumeroEIT" Width="50px"
                        runat="server" Text='<%# Bind("Numero") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label6" runat="server" Text='<%# Bind("Numero") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    Numero:<br />
                    <asp:TextBox ID="txtNumeroFT" Width="50px"
                        runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator6"
                        runat="server" ErrorMessage="Campo Obligatorio"
                        ControlToValidate="txtNumeroFT" Text="****"
                        ForeColor="red" ValidationGroup="add"></asp:RequiredFieldValidator>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Delegacion">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlDelegacionEIT" runat="server"
                        Height="16px" OnSelectedIndexChanged="ddlDelegacionEIT_SelectedIndexChanged"
                        AutoPostBack="true" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label7" runat="server" Text='<%# Bind("Delegacion.Nombre") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    Delegación:
                    <br />
                    <asp:DropDownList ID="ddlDelegacionFT" AppendDataBoundItems="true"
                        AutoPostBack="true" runat="server" OnSelectedIndexChanged="ddlDelegacionFT_SelectedIndexChanged">
                        <asp:ListItem Value="-1">[Delegacion]</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator7"
                        runat="server" ErrorMessage="Campo Obligatorio"
                        ControlToValidate="ddlDelegacionFT" InitialValue="-1" Text="****"
                        ForeColor="red" ValidationGroup="add"></asp:RequiredFieldValidator>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Colonia">
                <EditItemTemplate>
                    <asp:DropDownList ID="ddlColoniaEIT" runat="server" AppendDataBoundItems="true" />
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label8" runat="server" Text='<%# Bind("Colonia.Nombre") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    Colonia:
                    <br />
                    <asp:DropDownList ID="ddlColoniaFT" AppendDataBoundItems="true"
                        runat="server">
                        <asp:ListItem Value="-1">[Colonia]</asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8"
                        runat="server" ErrorMessage="Campo Obligatorio"
                        ControlToValidate="ddlColoniaFT" InitialValue="-1" Text="****"
                        ForeColor="red" ValidationGroup="add"></asp:RequiredFieldValidator>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Horario">
                <EditItemTemplate>
                    <asp:TextBox ID="txtHorarioEIT" runat="server"
                        Width="70px" Text='<%# Bind("Horario") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label9" runat="server" Text='<%# Bind("Horario") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    Horario:
                    <br />
                    <asp:TextBox ID="txtHorarioFT" Width="70px"
                        runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9"
                        runat="server" ErrorMessage="Campo Obligatorio"
                        ControlToValidate="txtHorarioFT" Text="****"
                        ForeColor="red" ValidationGroup="add"></asp:RequiredFieldValidator>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Edad">
                <EditItemTemplate>
                    <asp:TextBox ID="txtEdadEIT" Width="50px"
                        runat="server" Text='<%# Bind("Edad") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label10" runat="server" Text='<%# Bind("Edad") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    Edad:
                    <br />
                    <asp:TextBox ID="txtEdadFT" Width="50px"
                        runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10"
                        runat="server" ErrorMessage="Campo Obligatorio"
                        ControlToValidate="txtEdadFT" Text="****"
                        ForeColor="red" ValidationGroup="add"></asp:RequiredFieldValidator>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Alergias">
                <EditItemTemplate>
                    <asp:TextBox ID="txtAlergiasEIT" Width="80px"
                        runat="server" Text='<%# Bind("Alergia") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label11" runat="server" Text='<%# Bind("Alergia") %>'></asp:Label>
                </ItemTemplate>
                <FooterTemplate>
                    Alergias:<br />
                    <asp:TextBox ID="txtAlergiasFT" Width="80px"
                        runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11"
                        runat="server" ErrorMessage="Campo Obligatorio"
                        ControlToValidate="txtAlergiasFT" Text="****"
                        ForeColor="red" ValidationGroup="add"></asp:RequiredFieldValidator>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Fecha Alta">
                <EditItemTemplate>
                    <asp:TextBox ID="txtFechaEIT" runat="server"
                        Width="80px" Text='<%# Bind("FechaAlta", "{0:dd/MM/yyyy}") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label12" runat="server" Text='<%# Bind("FechaAlta", "{0:dd/MM/yyyy}") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Editar" ShowHeader="False">
                <EditItemTemplate>
                    <asp:LinkButton ID="lnkActualizar" runat="server"
                        CausesValidation="True" CommandName="Update"
                        Text="Actualizar"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="lnkCancelar" runat="server"
                        CausesValidation="False" CommandName="Cancel"
                        Text="Cancelar"></asp:LinkButton>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="lnkEditar" runat="server"
                        CausesValidation="False" CommandName="Edit"
                        Text="Editar"></asp:LinkButton>
                </ItemTemplate>
                <FooterTemplate>
                    <br />
                    <asp:LinkButton ID="lnkAgregar" runat="server"
                        ValidationGroup="add" OnClick="lnkAgregar_Click">Agregar</asp:LinkButton>
                </FooterTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Eliminar"
                ShowHeader="False">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkEliminar" runat="server"
                        CausesValidation="False" OnClientClick='<%# string.Format("return confirm(\"Se eliminara a {0} {1}, Esta Seguro?\")", Eval("Nombre"), Eval("Paterno")) %>'
                        CommandName="Delete" Text="Eliminar"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="White" ForeColor="#000066" />
        <HeaderStyle BackColor="#006699" Font-Bold="True"
            ForeColor="White" />
        <PagerStyle BackColor="White" ForeColor="#000066"
            HorizontalAlign="Left" />
        <RowStyle ForeColor="#000066" />
        <SelectedRowStyle BackColor="#669999" Font-Bold="True"
            ForeColor="White" />
        <SortedAscendingCellStyle BackColor="#F1F1F1" />
        <SortedAscendingHeaderStyle BackColor="#007DBB" />
        <SortedDescendingCellStyle BackColor="#CAC9C9" />
        <SortedDescendingHeaderStyle BackColor="#00547E" />
    </asp:GridView>
    </form>
</body>
</html>
