<%@ Page Title="" Language="C#" MasterPageFile="~/Sensado.master" AutoEventWireup="true" CodeFile="MenuBitacora.aspx.cs" Inherits="MenuBitacora" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" Runat="Server">
    <asp:Button ID="btnBitacoraAccesos" runat="server" OnClick="btnBitacoraAccesos_Click" Text="Bitacora de accesos" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    &nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnControlProcesos" runat="server" Text="Bitacora Control Procesos" OnClick="btnControlProcesos_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" Text="Bitacora Control de SetPoints" OnClick="Button1_Click" />
&nbsp;
</asp:Content>

