<%@ Page Title="" Language="C#" MasterPageFile="~/Sensado.master" AutoEventWireup="true" CodeFile="TemporadaHorario.aspx.cs" Inherits="TemporadaHorario" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .auto-style1
        {
            width: 100%;
        }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" Runat="Server">
    <script>
        $(function () {
            $("#dialog-message").dialog({ autoOpen: false, modal: false, buttons: { Aceptar: function () { $(this).dialog("close"); } } });
        });

        function mensaje() { $('#dialog-message').dialog('open'); };
    </script>

    <div id="dialog-message" title="Control Invernadero">  <p> Temporada registrada </p></div>    
    
    <table class="auto-style1">
        <tr>
            <td colspan="2" style="text-align: left">
                <div class="title">
				<h1>CONTROL DE SETPOINT</h1>
				<span class="byline">Temporada - horario</span></div>
            </td>
        </tr>
        <tr>
            <td>Temporada</td>
            <td>
                <asp:TextBox ID="txtTemporada" runat="server" Width="211px"></asp:TextBox>
&nbsp;&nbsp;<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTemporada" Display="Dynamic" ErrorMessage="Campo requerido" Font-Size="Medium" ForeColor="Red" ValidationGroup="ValTemporada"></asp:RequiredFieldValidator>
                &nbsp;&nbsp;
                <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" OnClick="btnRegistrar_Click" ValidationGroup="ValTemporada"/>
                <br />
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:Label ID="lblMensaje" runat="server" Font-Bold="True" ForeColor="#CC9900"></asp:Label>
            </td>
        </tr>
        <tr>
            <td colspan="2">
                <asp:GridView ID="GridTemporadas" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical" OnRowCommand="GridTemporadas_RowCommand">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField DataField="idtemporada" HeaderText="ID" />
                        <asp:BoundField DataField="descripcion" HeaderText="Descripción" />
                        <asp:TemplateField HeaderText="Acciones">
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkModificar" runat="server" CommandName="Modificar" CommandArgument="<%# Container.DataItemIndex %>">Modificar</asp:LinkButton>
                                &nbsp;&nbsp;&nbsp;
                                <asp:LinkButton ID="lnkEliminar" runat="server" CommandName="Eliminar">Eliminar</asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkHorarios" runat="server" CommandName="Horario" CommandArgument="<%# Container.DataItemIndex %>">Horario temporada</asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" />
                        </asp:TemplateField>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="lnkActivar" runat="server" CommandArgument="<%# Container.DataItemIndex %>" CommandName="Activar">Activar</asp:LinkButton>
                                &nbsp;&nbsp;&nbsp;<asp:LinkButton ID="lnkDesactivar" runat="server" CommandArgument="<%# Container.DataItemIndex %>" CommandName="Desactivar">Desactivar</asp:LinkButton>
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
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

