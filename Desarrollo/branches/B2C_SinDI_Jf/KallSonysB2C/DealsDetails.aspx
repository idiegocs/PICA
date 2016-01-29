<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DealsDetails.aspx.cs" Inherits="KallSonysB2C.DealsDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="dealsDetail" runat="server" SelectMethod ="GetDeal" RenderOuterTable="false">
        <ItemTemplate>
            <div>
                <h1><%#:Eval("Nombre") %></h1>
            </div>
            <br />
            <table>
                <tr>
                    <td>
                        <!-- dics cambio la ruta de la imagen -->
                        <img src="/KB2C_Images/Campanias/<%#:Eval("NombreImagenCampania") %>" style="border:solid; height:300px" alt="<%#:Eval("Nombre") %>" onerror="this.src='/KB2C_Images/Productos/Xproducto.png'"/>
                    </td>
                    <td>&nbsp;</td>  
                    <td style="vertical-align: top; text-align:left;">
                        <b>Descripción:</b><br /><%#:Eval("Nombre") %>
                        <br />
                        <span><b>Precio:</b>&nbsp;<%#: String.Format("{0:c}", Eval("ValorUnitarioCampania")) %></span>
                        <br />
                        <span><b>Identificador del Producto:</b>&nbsp;<%#:Eval("IdCampania")%></span>
                        <br />
                        <span class="ProductListItem">
                            <b><asp:LinkButton ID="lnkAddToCart" runat="server" Text="Agregar al Carrito" OnCommand="lnkAddToCart_Click" CommandArgument='<%# Eval("IdCampania") %>'></asp:LinkButton></b>
                        </span>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>
    <br />
    <hgroup>
        <h2>Productos de la campaña:</h2>
    </hgroup>
    <br />
    <asp:ListView ID="listProdxCampania" runat="server" DataKeyNames="idProducto" GroupItemCount="5">
        <EmptyDataTemplate>
            <table>
                <tr>
                    <td>No existen datos</td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <EmptyItemTemplate>
            <td />
        </EmptyItemTemplate>
        <GroupTemplate>
            <tr id="itemPlaceholderContainer" runat="server">
                <td id="itemPlaceholder" runat="server"></td>
            </tr>
        </GroupTemplate>
        <ItemTemplate>
            <td id="Td1" runat="server">
                <table>
                    <tr>
                        <td>
                            <image src='/KB2C_Images/Productos/<%#:Eval("nombreImagenProducto")%>'
                                width="100" height="75" border="1" alt="Sin Imagen <%#: Eval("NombreProducto")%>" onerror="this.src='/KB2C_Images/Productos/Xproducto.png'" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <span>
                                <b><%#:Eval("NombreProducto")%></b>
                            </span>
                            <br />
                            <span>
                                <b>Precio: </b><%#:String.Format("{0:c}", Eval("ValorUnitario"))%>
                            </span>
                            <br />
                            <span>
                                <b>Descuento: </b><%#:Eval("PorcentajeDescuento")%> %
                            </span>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                </table>
                </p>
            </td>
        </ItemTemplate>
        <LayoutTemplate>
            <table style="width: 70%;">
                <tbody>
                    <tr>
                        <td>
                            <table id="groupPlaceholderContainer" runat="server" style="width: 70%">
                                <tr id="groupPlaceholder"></tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                    <tr></tr>
                </tbody>
            </table>
        </LayoutTemplate>
    </asp:ListView>
</asp:Content>
