<%@ Page Title="" Language="C#" MasterPageFile="~/Sensado.master" AutoEventWireup="true" CodeFile="ModificarUsuario.aspx.cs" Inherits="ModificarUsuario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" Runat="Server">
    <div>
    <table style="width:250px">
        <tr>
            <td colspan="2">
               <div class="title">
				<h1>MODIFICAR USUARIO</h1>
			</div>
                </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <div>
                    <table>
                    <tr>
            <td>Usuario</td>
            <td>
                <asp:TextBox ID="txtUsuario" runat="server" Width="254px" ReadOnly="True"></asp:TextBox>
                        </td>
            <td>
                <asp:Button ID="btnModificar" runat="server" Text="Modificar" Width="124px" OnClick="btnModificar_Click"/>
                        </td>
        </tr>
        <tr>
            <td>Password</td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" Width="254px"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnRegresar" runat="server" OnClick="btnRegresar_Click" Text="Regresar" Width="118px" />
            </td>
        </tr>
        <tr>
            <td>Nivel</td>
            <td>
                <asp:TextBox ID="txtNivel" runat="server" Width="254px"></asp:TextBox>
            </td>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;
                </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" ForeColor="#CC9900"></asp:Label>
            </td>
        </tr>
        </table>

                </div>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td style="text-align: center">
                &nbsp;</td>
        </tr>
    </table>
        </div>
</asp:Content>

