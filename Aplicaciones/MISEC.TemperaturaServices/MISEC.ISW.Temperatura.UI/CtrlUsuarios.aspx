<%@ Page Title="" Language="C#" MasterPageFile="~/Sensado.master" AutoEventWireup="true" CodeFile="CtrlUsuarios.aspx.cs" Inherits="CtrlUsuarios" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Contenido" Runat="Server">
    <div>
    <table style="width:250px">
        <tr>
            <td colspan="2">
               <div class="title">
				<h1>ADMINISTRACIÓN DE USUARIOS</h1>
               </div>
                </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>
                <div>
                    <table>
                    <tr>
            <td>Usuario</td>
            <td>
                <asp:TextBox ID="txtUsuario" runat="server" Width="254px"></asp:TextBox>
                        </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>Password</td>
            <td>
                <asp:TextBox ID="txtPassword" runat="server" Width="254px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>Nivel</td>
            <td>
                <asp:DropDownList ID="cmbNiveles" runat="server" Width="264px">
                </asp:DropDownList>
            </td>
            <td>
                &nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnRegistrar" runat="server" Text="Registrar" Width="124px"/>
            </td>
        </tr>
        </table>

                </div>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td style="text-align: center">
                <br />
                <asp:GridView ID="GridUsuarios" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Vertical">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:BoundField HeaderText="Usuario" DataField="usuario" />
                        <asp:BoundField HeaderText="Password" DataField="password" />
                        <asp:BoundField HeaderText="Nivel" DataField="nivel" />
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:ImageButton ID="imgModificar" runat="server" CommandName="Modificar" Height="32px" ImageUrl="~/images/Actions-user-properties-icon.png" ToolTip="Modificar" Width="40px" />
                                &nbsp;&nbsp;&nbsp;&nbsp;
                                <asp:ImageButton ID="imgEliminar" runat="server" CommandName="Eliminar" Height="32px" ImageUrl="~/images/Remove-Male-User-icon.png" ToolTip="Eliminar" Width="40px" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    </EmptyDataTemplate>
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
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            </td>
        </tr>
    </table>
        </div>
    <div>


        <br />


    </div>
</asp:Content>

