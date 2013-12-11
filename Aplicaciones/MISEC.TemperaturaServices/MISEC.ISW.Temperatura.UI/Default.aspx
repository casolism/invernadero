<%@ Page Title="" Language="C#" MasterPageFile="~/NoSesion.master" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" Runat="Server">
    <div>
             <table style="width:40%" align="center">
                 <tr>
                     <td style="width:auto; color: #FFFFFF; font-weight: 700; font-family: Calibri; font-size: large; text-align: center; background-color: #FFCC00;" 
                         colspan="2">
                         ACCESO</td>
                 </tr>
                 <tr>
                     <td style="width:40%">
                     
                         Usuario:</td>
                     <td style="width:60%">
                     
                     <asp:TextBox ID="txtUsuario" runat="server"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td style="width:40%">
                     
                         Password:</td>
                     <td style="width:60%">
                     
                     <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                     </td>
                 </tr>
                 <tr>
                     <td style="width:40%">
                         &nbsp;</td>
                     <td style="width:60%">
                         <asp:Button ID="BtnAcceso" runat="server" Text="Acceso" />
                     </td>
                 </tr>
                 <tr>
                     <td colspan="2">
                         <asp:Label ID="lblMensaje" runat="server" Text="..."></asp:Label>
                     </td>
                 </tr>
             </table>
&nbsp;</div>

</asp:Content>

