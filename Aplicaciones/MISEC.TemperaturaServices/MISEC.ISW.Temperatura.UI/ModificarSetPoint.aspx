<%@ Page Title="" Language="C#" MasterPageFile="~/Sensado.master" AutoEventWireup="true" CodeFile="ModificarSetPoint.aspx.cs" Inherits="ModificarSetPoint" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" Runat="Server">
    <table class="auto-style1">
        <tr>
            <td colspan="4">MODIFICAR SETPOINT</td>
        </tr>
        <tr>
            <td colspan="4">ID del SetPoint:&nbsp;
                <asp:Label ID="lblIdSetPoint" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Variable</td>
            <td colspan="3">
                <asp:DropDownList ID="cmbVariables" runat="server" Width="200px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Limite mínimo</td>
            <td class="auto-style3">
                <asp:TextBox ID="txtLimiteMin" runat="server" Width="127px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLimiteMin" Display="Dynamic" ErrorMessage="Campo requerido" ForeColor="Red" ValidationGroup="ValSetpoint"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style4">Limite máximo</td>
            <td>
                <asp:TextBox ID="txtLimiteMax" runat="server" Width="127px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLimiteMax" Display="Dynamic" ErrorMessage="Campo requerido" ForeColor="Red" ValidationGroup="ValSetpoint"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Estado</td>
            <td colspan="3">
                <asp:DropDownList ID="cmbEstados" runat="server" Width="200px">
                </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" />
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

