<%@ Page Title="" Language="C#" MasterPageFile="~/Sensado.master" AutoEventWireup="true" CodeFile="MenuMonitoreo.aspx.cs" Inherits="MenuMonitoreo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" Runat="Server">
    <asp:Button ID="btnConsFecha" runat="server" OnClick="btnConsFecha_Click" Text="Consultar por fecha" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnSensadoTemperatura" runat="server" Text="Sensado Temperatura" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnSensadoLuminosidad" runat="server" Text="Sensado luminosidad" />
    &nbsp;&nbsp;&nbsp;
    <asp:Button ID="Button1" runat="server" Text="Monitoreo en Tiempo real" />
&nbsp;
</asp:Content>

