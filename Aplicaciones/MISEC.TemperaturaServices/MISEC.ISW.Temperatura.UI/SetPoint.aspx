<%@ Page Title="" Language="C#" MasterPageFile="~/Sensado.master" AutoEventWireup="true" CodeFile="SetPoint.aspx.cs" Inherits="SetPoint" %>

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
            width: 312px;
        }
        .auto-style4
        {
            width: 112px;
        }
        .auto-style5
        {
            height: 26px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" Runat="Server">
    <table class="auto-style1">
        <tr>
            <td colspan="4">REGISTRO DE SETPOINTS</td>
        </tr>
        <tr>
            <td colspan="4">Temporada:&nbsp;&nbsp;
                <asp:Label ID="lblTemporada" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; horario:
                <asp:Label ID="lblHorario" runat="server"></asp:Label>
            &nbsp;&nbsp;&nbsp; descripción del horario:
                <asp:Label ID="lblDescripcion" runat="server"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Variable</td>
            <td colspan="3">
                <asp:DropDownList ID="cmbVariables" runat="server" Width="200px">
                </asp:DropDownList>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Limite mínimo</td>
            <td class="auto-style3">
                <asp:TextBox ID="txtLimiteMin" runat="server" Width="127px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLimiteMin" Display="Dynamic" ErrorMessage="Campo requerido" ForeColor="Red" ValidationGroup="ValSetpoint"></asp:RequiredFieldValidator>
            </td>
            <td class="auto-style4">Limite máximo</td>
            <td>
                <asp:TextBox ID="txtLimiteMax" runat="server" Width="127px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLimiteMax" Display="Dynamic" ErrorMessage="Campo requerido" ForeColor="Red" ValidationGroup="ValSetpoint"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="auto-style2">Estado</td>
            <td colspan="3">
                <asp:DropDownList ID="cmbEstados" runat="server" Width="200px">
                </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" ValidationGroup="ValSetpoint" OnClick="btnRegistrar_Click"/>
            </td>
        </tr>
        <tr>
            <td class="auto-style5" colspan="4">
                <asp:Label ID="lblIdSetPoint" runat="server" Font-Size="Large" ForeColor="#CC9900" style="font-weight: 700"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="auto-style2" colspan="4">
                <asp:GridView ID="GridSetPoint" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="660px" OnRowCommand="GridSetPoint_RowCommand">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="idsetpoint" HeaderText="ID" />
                        <asp:BoundField DataField="limitemin" HeaderText="Mínimo" >
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="limitemax" HeaderText="Máximo" >
                        <ItemStyle HorizontalAlign="Center" />
                        </asp:BoundField>
                        <asp:BoundField DataField="estado" HeaderText="Estado" />
                        <asp:BoundField DataField="variable" HeaderText="Variable" />
                        <asp:BoundField DataField="activo" HeaderText="Activo" />
                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>
                                <asp:ImageButton ID="ImageButton1" runat="server" CommandName="Modificar" Height="29px" ImageUrl="~/images/edit-doc.png" ToolTip="Modificar" Width="36px" CommandArgument="<%# Container.DataItemIndex %>"/>
                                &nbsp;&nbsp;&nbsp;
                                <asp:ImageButton ID="ImageButton2" runat="server" CommandName="Eliminar" Height="29px" ImageUrl="~/images/delete-file-icon.png" ToolTip="Eliminar" Width="36px" CommandArgument="<%# Container.DataItemIndex %>"/>
                            </ItemTemplate>
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

