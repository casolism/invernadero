<%@ Page Title="" Language="C#" MasterPageFile="~/Sensado.master" AutoEventWireup="true" CodeFile="BitacoraAccesos.aspx.cs" Inherits="BitacoraAccesos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" Runat="Server">
    <table class="auto-style1">
        <tr>
            <td colspan="2">
                <div class="title">
				<h1>BITACORA DE ACCESOS</h1>
				<span class="byline">ACCESO POR USUARIO Y RANGO DE FECHAS</span></div>
            </td>
        </tr>
        <tr>
            <td>
                Usuario</td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Width="279px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                Del</td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
&nbsp;&nbsp; al&nbsp;
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            &nbsp;&nbsp;
                <asp:Button ID="bntConsultar" runat="server" OnClick="bntConsultar_Click" Text="Consultar" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridBitacora" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="822px">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField HeaderText="Usuario" DataField="usuario" />
                        <asp:BoundField HeaderText="Descripcion" DataField="descripcion" />
                        <asp:BoundField HeaderText="Fecha" DataField="fecha" />
                        <asp:BoundField HeaderText="Proceso" DataField="tipo" />
                    </Columns>
                    <FooterStyle BackColor="#CCCC99" />
                    <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
                    <RowStyle BackColor="#F7F7DE" />
                    <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FBFBF2" />
                    <SortedAscendingHeaderStyle BackColor="#848384" />
                    <SortedDescendingCellStyle BackColor="#EAEAD3" />
                    <SortedDescendingHeaderStyle BackColor="#575357" />
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

