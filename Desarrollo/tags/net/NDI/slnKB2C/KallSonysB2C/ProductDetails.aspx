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
                        <img src="/Images/Productos/<%#:Eval("nombreImagenProducto") %>" style="border:solid; height:300px" alt="<%#:Eval("nombreProducto") %>" onerror="this.src='/Images/Productos/Xproducto.png'"/>
                    </td>
                    <td>&nbsp;</td>  
                    <td style="vertical-align: top; text-align:left;">
                        <b>Descripción:</b><br /><%#:Eval("descripcionProducto") %>
                        <br />
                        <span><b>Precio:</b>&nbsp;<%#: String.Format("{0:c}", Eval("precioProducto")) %></span>
                        <br />
                        <span><b>Identificador del Producto:</b>&nbsp;<%#:Eval("idProducto")%></span>
                        <br />
                        <span class="ProductListItem">
                            <b><asp:LinkButton ID="lnkAddToCart" runat="server" Text="Agregar al Carrito" onCommand="lnkAddToCart_Click" CommandArgument='<%# Eval("idProducto") %>'></asp:LinkButton></b>
                        </span>
                    </td>
                </tr>
            </table>
        </ItemTemplate>
    </asp:FormView>
</asp:Content>