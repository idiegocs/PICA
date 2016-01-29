<%@ Page Title="Productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" 
         CodeBehind="ProductList.aspx.cs" Inherits="KallSonysB2C.ProductList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div>
            <hgroup>
                <h2><%: Page.Title %></h2>
            </hgroup>
            <asp:Label ID="lblTipoFiltro" runat="server" Text="Tipo de Filtro"></asp:Label>
            <asp:DropDownList ID="ddlTipoFiltro" runat="server">
                <asp:ListItem Selected="True" Value="A">Seleccione</asp:ListItem>
                <asp:ListItem Value="C">Codigo</asp:ListItem>
                <asp:ListItem Value="N">Nombre</asp:ListItem>
                <asp:ListItem Value="D">Descripcion</asp:ListItem>
            </asp:DropDownList>
            <asp:TextBox ID="txtValorFiltro" runat="server" MaxLength="64" Width="401px"></asp:TextBox>
            <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick="btnBuscar_Click" />
            <br />
            <asp:ListView ID="productList" runat="server" DataKeyNames="idProducto" GroupItemCount="4">
                <EmptyDataTemplate>
                    <table >
                        <tr>
                            <td>No existen datos</td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <EmptyItemTemplate>
                    <td/>
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
                                    <image src='/Images/Productos/<%#:Eval("nombreImagenProducto")%>'
                                      width="100" height="75" border="1" alt="Sin Imagen <%#: Eval("nombreProducto")%>" onerror="this.src='/Images/Productos/Xproducto.png'" />
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
                                        <b><asp:LinkButton ID="lnkAddToCart" runat="server" Text="Agregar al Carrito" OnCommand="lnkAddToCart_Click" CommandArgument='<%# Eval("idProducto") %>'></asp:LinkButton></b>
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
                    <table style="width:100%;">
                        <tbody>
                            <tr>
                                <td>
                                    <table id="groupPlaceholderContainer" runat="server" style="width:100%">
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
            <asp:DataPager ID="DataPagerProducts" runat="server" PagedControlID="productList"
                PageSize="20" OnPreRender="DataPagerProducts_PreRender">
                <Fields>
                    <asp:NextPreviousPagerField ShowFirstPageButton="True" ShowNextPageButton="False" />
                    <asp:NumericPagerField />
                    <asp:NextPreviousPagerField ShowLastPageButton="True" ShowPreviousPageButton="False" />
                </Fields>
            </asp:DataPager>
        </div>
    </section>
</asp:Content>