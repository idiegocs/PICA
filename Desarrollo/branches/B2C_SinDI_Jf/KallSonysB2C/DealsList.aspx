<%@ Page Title="Campañas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DealsList.aspx.cs" Inherits="KallSonysB2C.DealsList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <section>
        <div>
            <hgroup>
                <h2><%: Page.Title %></h2>
            </hgroup>
            <br />
            <asp:ListView ID="lstDealsList" runat="server" 
                DataKeyNames="idCampania" GroupItemCount="3">
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
                                  <a href="<%#: GetRouteUrl("DealsByNameRoute", new {dealName = Eval("IdCampania")}) %>">
                                    <image src="/KB2C_Images/Campanias/<%#:Eval("NombreImagenCampania")%>"
                                      width="100" height="75" border="1" alt="Sin Imagen <%#: Eval("Nombre")%>" onerror="this.src='/KB2C_Images/Productos/Xproducto.png'" />
                                  </a>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <a href="<%#: GetRouteUrl("DealsByNameRoute", new {dealName = Eval("IdCampania")}) %>">
                                      <%#:Eval("Nombre")%>
                                    </a>
                                    <br />
                                    <span>
                                        <b>Precio: </b><%#:String.Format("{0:c}", Eval("ValorUnitarioCampania"))%>
                                    </span>
                                    <br />
                                    <span class="ProductListItem">
                                        <b><asp:LinkButton ID="lnkAddToCart" runat="server" Text="Agregar al Carrito" OnCommand="lnkAddToCart_Click" CommandArgument='<%# Eval("IdCampania") %>'></asp:LinkButton></b>
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
        </div>
    </section>
</asp:Content>
