<%@ Page Title="" Language="C#" MasterPageFile="~/Sensado.master" AutoEventWireup="true" CodeFile="ModificarTemporada.aspx.cs" Inherits="ModificarTemporada" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" Runat="Server">
    <table class="auto-style1">
        <tr>
            <td colspan="4">
                <div class="title">
				<h1>CONTROL DE SETPOINT</h1>
				<span class="byline">MODIFICAR TEMPORADA</span></div>
            </td>
        </tr>
        <tr>
            <td colspan="4">ID temporada:&nbsp;
                <asp:Label ID="lblTemporada" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Temporada</td>
            <td class="auto-style3">
                <asp:TextBox ID="txtTemporada" runat="server" Width="244px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTemporada" Display="Dynamic" ErrorMessage="Campo requerido" ForeColor="Red" ValidationGroup="valTemporada"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style4">
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" ValidationGroup="valTemporada" OnClick="btnModificar_Click" />
            </td>
            <td>
                <asp:Button ID="btnRegresar" runat="server" OnClick="btnRegresar_Click" Text="Regresar" />
            </td>
        </tr>
        <tr>
            <td class="auto-style5" colspan="4">
                <asp:Label ID="lblMensaje" runat="server" Font-Size="Large" ForeColor="#CC9900" style="font-weight: 700"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2" colspan="4">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

