<%@ Page Title="" Language="C#" MasterPageFile="~/NoSesion.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1
        {
            text-align: center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" Runat="Server">
    <div>
             <table style="width:50%" align="center">
                 <tr>
                     <td style="width:auto; color: #FFFFFF; font-weight: 700; font-family: Calibri; font-size: large; text-align: center; background-color: #FFCC00;" 
                         colspan="2">
                         ACCESO</td>
                 </tr>
                 <tr>
                     <td>
                     
                         Usuario:</td>
                     <td style="width:60%">
                     
                     <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtUsuario" ErrorMessage="Campo requerido" ForeColor="Red"></asp:RequiredFieldValidator>
                     </td>
                 </tr>
                 <tr>
                     <td>
                     
                         Password:</td>
                     <td style="width:60%">
                     
                         <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassword" ErrorMessage="Campo requerido" ForeColor="Red"></asp:RequiredFieldValidator>
                     </td>
                 </tr>
                 <tr>
                     <td class="auto-style1" colspan="2">
                         <asp:Button ID="BtnEntrar" runat="server" Text="Entrar" OnClick="BtnEntrar_Click" />
                     </td>
                 </tr>
                 <tr>
                     <td colspan="2">
                         <asp:Label ID="lblMensaje" runat="server" ForeColor="Red"></asp:Label>
                     </td>
                 </tr>
             </table>
&nbsp;</div>

</asp:Content>

