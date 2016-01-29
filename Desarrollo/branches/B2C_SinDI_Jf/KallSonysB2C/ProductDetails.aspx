<%@ Page Title="Productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ProductDetails.aspx.cs" Inherits="KallSonysB2C.ProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:FormView ID="productDetail" runat="server">
        <ItemTemplate>
            <div>
                <h1><%#:Eval("nombreProducto") %></h1>
            </div>
            <br />
            <table>
                <tr>
                    <td>
                        <!-- dics cambio la ruta de la imagen -->
                        <img src="/KB2C_Images/Productos/<%#:Eval("nombreImagenProducto") %>" style="border: solid; height: 300px" alt="<%#:Eval("nombreProducto") %>" onerror="this.src='/KB2C_Images/Productos/Xproducto.png'" />
                    </td>
                    <td>&nbsp;</td>
                    <td style="vertical-align: top; text-align: left;">
                        <b>Descripción:</b><br />
                        <%#:Eval("descripcionProducto") %><br />
                        <span><b>Precio:</b>&nbsp;<%#: String.Format("{0:c}", Eval("precioProducto")) %></span><br />
                        <span><b>Identificador del Producto:</b>&nbsp;<%#:Eval("idProducto")%></span><br />
                        <span><b>Codigo del Producto:</b>&nbsp;<%#:Eval("codigoProducto")%></span><br />
                        <span class="ProductListItem"><b>
                            <asp:LinkButton ID="lnkAddToCart" runat="server" Text="Agregar al Carrito" OnCommand="lnkAddToCart_Click" CommandArgument='<%# Eval("idProducto") %>'></asp:LinkButton></b>
                        </span>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>
    <br />
    <hgroup>
        <h2>Top 5</h2>
    </hgroup>
    <br />
    <asp:ListView ID="listTop5" runat="server" DataKeyNames="idProducto" GroupItemCount="5">
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
                            <a href="<%#: GetRouteUrl("ProductByNameRoute", new {productId = Eval("idProducto"), productName = Eval("nombreProducto")}) %>">
                                <image src='/KB2C_Images/Productos/<%#:Eval("nombreImagenProducto")%>'
                                    width="100" height="75" border="1" alt="Sin Imagen <%#: Eval("nombreProducto")%>" onerror="this.src='/KB2C_Images/Productos/Xproducto.png'" />
                            </a>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <a href="<%#: GetRouteUrl("ProductByNameRoute", new {productId = Eval("idProducto")}) %>">
                                <%#:Eval("nombreProducto")%>
                            </a>
                            <br />
                            <span>
                                <b>Precio: </b><%#:String.Format("{0:c}", Eval("precioProducto"))%>
                            </span>
                            <br />
                            <span class="ProductListItem">
                                <b>
                                    <asp:LinkButton ID="lnkAddToCart5" runat="server" Text="Agregar al Carrito" OnCommand="lnkAddToCart5_Click" CommandArgument='<%# Eval("idProducto") %>'></asp:LinkButton></b>
                            </span>
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
