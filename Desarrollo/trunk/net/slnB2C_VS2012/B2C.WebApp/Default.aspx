<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="B2C.WebApp._Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<asp:Content runat="server" ID="FeaturedContent" ContentPlaceHolderID="FeaturedContent">
    <section class="featured">
         <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %></h1>
                <h2>Catálogo de Productos</h2>
            </hgroup>
           <%-- <p>
                To learn more about ASP.NET, visit <a href="http://asp.net" title="ASP.NET Website">http://asp.net</a>.
                The page features <mark>videos, tutorials, and samples</mark> to help you get the most from ASP.NET.
                If you have any questions about ASP.NET visit
                <a href="http://forums.asp.net/18.aspx" title="ASP.NET Forum">our forums</a>.
            </p>--%>
        </div>
    </section>
</asp:Content>
<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <div style="width: 100%">
        <table style="width: 100%">
            <tr>
                <td>
                    <asp:DropDownList ID="DdlTipoBusqueda" runat="server">
                        <asp:ListItem Text="Por Código" Value="Codigo"></asp:ListItem>
                        <asp:ListItem Text="Por Nombre" Value="Nombre"></asp:ListItem>
                        <asp:ListItem Text="Por Descripción" Value="Descripcion"></asp:ListItem>
                    </asp:DropDownList></td>
                <td>
                    <asp:TextBox ID="TbTextoBuscar" runat="server"></asp:TextBox></td>
                <td>
                    <asp:Button ID="Bt" runat="server" Text="Buscar" /></td>
            </tr>
        </table>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Repeater ID="Repeater1" runat="server" OnItemDataBound="Repeater1_ItemDataBound" >
                    <HeaderTemplate>
                        <table id="TablaRepeater" style="width: 100%">
                            <tr>
                                <th>Productos</th>
                            </tr>
                    </HeaderTemplate>

                    <ItemTemplate>
                        <tr>
                            <td>
                                <asp:HiddenField ID="HdIdProduct" runat="server" Value='<%# Eval("idProducto") %>' />
                                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# Eval("codigoProducto") %>' />
                                <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("nombreImagenProducto") %>' Height="80px" Width="80px" />
                            </td>
                            <td>
                                <asp:Label runat="server" ID="Label1"
                                    Text='<%# Eval("nombreProducto") %>' />
                                <br />
                                <b>
                                    <asp:Label runat="server" ID="Label2"
                                        Text='<%# Eval("fabricanteProducto") %>' /></b>
                            </td>
                            <td>
                                <b>
                                    <asp:Label runat="server" ID="Label3"
                                        Text='<%# ConvertirPeso(Eval("precioProducto")) %>' /></b>
                            </td>
                            <td>
                                <asp:TextBox ID="TbCantidad" runat="server" TextMode="Number" AutoPostBack="true"
                                    Width="42px" CausesValidation="true" Text="1" OnTextChanged="TbCantidad_TextChanged"></asp:TextBox>
                                <br />
                                <asp:RangeValidator ID="RVCantidad" runat="server" ErrorMessage="El valor debe ser mayor a 1!"
                                    ControlToValidate="TbCantidad"
                                    Display="Dynamic"
                                    MinimumValue="1"
                                    MaximumValue="100"
                                    Type="Integer"
                                    EnableClientScript="true"
                                    Text="El valor debe estar entre 1 y 100!"
                                    ValidationGroup="AddCarrito"></asp:RangeValidator>
                                <%-- 
                        <asp:ValidatorCalloutExtender runat="server" 
                            Enabled="True" TargetControlID="RVCantidad" 
                            ID="RVCantidad_ValidatorCalloutExtender" PopupPosition="TopRight"
                             ValidateRequestMode="Enabled">
                        </asp:ValidatorCalloutExtender>--%>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImBtCarrito" runat="server" ImageUrl="~/Images/Carrito.png" Height="30px" Width="30px" ValidationGroup="AddCarrito" OnClick="ImBtCarrito_Click" />
                            </td>
                        </tr>
                    </ItemTemplate>

                    <FooterTemplate>
                        </table>
                    </FooterTemplate>
                </asp:Repeater>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:CustomValidator ID="ValidatorQnt" runat="server" ErrorMessage="" />
        <asp:ValidatorCalloutExtender runat="server"
            Enabled="True" TargetControlID="ValidatorQnt"
            ID="ValidatorQnt_ValidatorCalloutExtender" />
    </div>
</asp:Content>
