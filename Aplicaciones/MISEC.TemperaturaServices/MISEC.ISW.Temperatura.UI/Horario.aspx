<%@ Page Title="" Language="C#" MasterPageFile="~/Sensado.master" AutoEventWireup="true" CodeFile="Horario.aspx.cs" Inherits="Horario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1
        {
            width: 100%;
        }
        .auto-style2
        {
        }
        .auto-style3
        {
        }
        .auto-style4
        {
            width: 151px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" Runat="Server">
    <table class="auto-style1">
        <tr>
            <td colspan="2">
                <div class="title">
				<h1>CONTROL DE SETPOINT</h1>
				<span class="byline">horario</span></div>
            </td>
        </tr>
        <tr>
            <td class="auto-style2" colspan="2">Temporada:&nbsp;
                <asp:Label ID="lblTemporada" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Hora de inicio</td>
            <td>
                <asp:TextBox ID="txtHrInicio" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtHrInicio" Display="Dynamic" ErrorMessage="Campo requerido" ForeColor="#FF3300" ValidationGroup="ValHr"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Hora final</td>
            <td>
                <asp:TextBox ID="txtHrFin" runat="server"></asp:TextBox>
&nbsp;&nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtHrFin" Display="Dynamic" ErrorMessage="Campo requerido" ForeColor="#FF3300" ValidationGroup="ValHr"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style4">Descripción del horario</td>
            <td>
                <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
&nbsp;&nbsp;
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDescripcion" Display="Dynamic" ErrorMessage="Campo requerido" ForeColor="#FF3300" ValidationGroup="ValHr"></asp:RequiredFieldValidator>
&nbsp;
                <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" ValidationGroup="ValHr"/>
            </td>
        </tr>
        <tr>
            
            <td class="auto-style3" colspan="2">
                <asp:GridView ID="GridHorarios" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="634px" OnRowCommand="GridHorarios_RowCommand">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="temporada" HeaderText="Temporada" />
                        <asp:BoundField DataField="inicio" HeaderText="Hr Inicio" >
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="fin" HeaderText="Hr final" >
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="descripcion" HeaderText="Descripcion" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkSetPoint" runat="server" CommandArgument="<%# Container.DataItemIndex %>" CommandName="SetPoint">SetPoint</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
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

