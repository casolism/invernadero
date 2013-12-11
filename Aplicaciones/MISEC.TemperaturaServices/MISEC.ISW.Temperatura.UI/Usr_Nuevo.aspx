<%@ Page Title="" Language="C#" MasterPageFile="~/Sensado.master" AutoEventWireup="true" CodeFile="Usr_Nuevo.aspx.cs" Inherits="Usr_Nuevo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" Runat="Server">
    <div><p>&nbsp;<h2>USUARIOS</h2></p></div> 
    <div>

    <table align="center">
        <tr>
            <td colspan="2">
                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/images/Add-Male-User-icon.png" Width="63px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/images/Remove-Male-User-icon.png" OnClick="ImageButton2_Click" Width="63px" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/images/Actions-user-properties-icon.png" Width="63px" OnClick="ImageButton3_Click" />
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>Usuario</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Width="254px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Password</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server" Width="254px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>Nivel</td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" Visible="False" Width="264px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td style="text-align: center">
                <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" Width="124px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
    </table>
        </div>
    <div>


        <br />


    </div>
</asp:Content>

