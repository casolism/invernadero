<%@ Page Title="" Language="C#" MasterPageFile="~/Sensado.master" AutoEventWireup="true" CodeFile="ConsMonitoreoRango.aspx.cs" Inherits="ConsMonitoreoRango" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" Runat="Server">
    <table class="auto-style1">
        <tr>
            <td colspan="5" style="text-align: center">MONITOREO DE SENSADO POR FECHA</td>
            <td style="text-align: center">&nbsp;</td>
        </tr>
        <tr>
            <td>Del</td>
            <td>
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:TextBox ID="txtInicio" runat="server"></asp:TextBox>
            </td>
            <td>
                al
            </td>
            <td>
                <asp:TextBox ID="txtFin" runat="server"></asp:TextBox>
            </td>
            <td>
                <asp:Button ID="btnConsultar" runat="server" OnClick="btnConsultar_Click" Text="Consultar" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="6">
                <asp:GridView ID="GridSensor" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="396px">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="idsensor" HeaderText="ID" />
                        <asp:BoundField DataField="valor" HeaderText="Valor" />
                        <asp:BoundField DataField="fecha" DataFormatString="{0:dd-M-yyyy}" HeaderText="Fecha">
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="setpoint" HeaderText="SetPoint" />
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

