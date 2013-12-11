<%@ Page Title="" Language="C#" MasterPageFile="~/Sensado.master" AutoEventWireup="true" CodeFile="ConsBitacora.aspx.cs" Inherits="ConsBitacora" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" Runat="Server">
    <table class="auto-style1">
        <tr>
            <td>
                <asp:CheckBox ID="CheckBox1" runat="server" Text="Proceso" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
            <td>
                <asp:DropDownList ID="DropDownList1" runat="server" style="margin-left: 0px" Width="280px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:CheckBox ID="CheckBox2" runat="server" Text="Variable" />
            </td>
            <td>
                <asp:DropDownList ID="DropDownList2" runat="server" Width="280px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td>
                <asp:CheckBox ID="CheckBox3" runat="server" Text="Usuario" />
            </td>
            <td>
                <asp:TextBox ID="TextBox1" runat="server" Width="266px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:CheckBox ID="CheckBox4" runat="server" Text="Fecha" />
            </td>
            <td>
                <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
&nbsp;&nbsp; al&nbsp;
                <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:CheckBox ID="CheckBox5" runat="server" Text="SetPoint" />
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="822px">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField HeaderText="Proceso" />
                        <asp:BoundField HeaderText="Variable" />
                        <asp:BoundField HeaderText="Usuario" />
                        <asp:BoundField HeaderText="Descripcion" />
                        <asp:BoundField HeaderText="Fecha" />
                        <asp:BoundField HeaderText="Minimo" />
                        <asp:BoundField HeaderText="Maximo" />
                        <asp:BoundField HeaderText="Sensado" />
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
&nbsp;&nbsp;&nbsp; 
</asp:Content>

