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
                        <img src="/Images/Campanias/<%#:Eval("NombreImagenCampania") %>" style="border:solid; height:300px" alt="<%#:Eval("Nombre") %>" onerror="this.src='/Images/Productos/Xproducto.png'"/>
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
</asp:Content>
