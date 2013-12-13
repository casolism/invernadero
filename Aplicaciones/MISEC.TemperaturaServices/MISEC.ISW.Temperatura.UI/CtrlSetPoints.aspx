<%@ Page Title="" Language="C#" MasterPageFile="~/Sensado.master" AutoEventWireup="true" CodeFile="CtrlSetPoints.aspx.cs" Inherits="CtrlSetPoints" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" Runat="Server">
    <table style="width:600px">
        <tr>
            <td colspan="3">
                <div class="title">
				<h1>CONTROL DE SETPOINTS</h1>
				<span class="byline">TEMPORADA-HORARIO   |   HORARIO    |    LIBRE</span></div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:ImageButton ID="ImgTemporada" runat="server" ImageUrl="~/images/weather-clock-2-icon.png" ToolTip="Temporada-Horario" OnClick="ImgTemporada_Click" />
            </td>
            <td>
                <asp:ImageButton ID="ImgHorario" runat="server" ImageUrl="~/images/Apps-clock-icon.png" Height="135px" Width="140px" ToolTip="Horario" OnClick="ImgHorario_Click"/>
            </td>
            <td>
                <asp:ImageButton ID="ImgLibre" runat="server" Height="182px" ImageUrl="~/images/limite.jpg" Width="164px" ToolTip="Establecer limites libres" OnClick="ImgLibre_Click" />
            </td>
        </tr>
    </table>
</asp:Content>

