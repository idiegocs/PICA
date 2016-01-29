<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerCarroCompras.aspx.cs" Inherits="B2C.WebApp.VerCarroCompras" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="FeaturedContent" runat="server">
    <section class="featured">
         <div class="content-wrapper">
            <hgroup class="title">
                <h1><%: Title %></h1>
                <h2>Carro de Compras</h2>
            </hgroup>           
        </div>
    </section>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div>
        <asp:GridView runat="server" ID="gvCaritoCompras"
            AutoGenerateColumns="false" EmptyDataText="No hay nada en su carrito de compras."
            GridLines="None" Width="100%" CellPadding="5" ShowFooter="true"
            DataKeyNames="IdProducto" OnRowCommand="gvCaritoCompras_RowCommand"
            OnRowDataBound="gvCaritoCompras_RowDataBound">
            <HeaderStyle HorizontalAlign="Left" BackColor="BlueViolet" ForeColor="AliceBlue" />
            <FooterStyle HorizontalAlign="Right" BackColor="Chocolate" ForeColor="Aqua" />
            <AlternatingRowStyle BackColor="Azure" />
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                <asp:TemplateField HeaderText="Cantidad">
                    <ItemTemplate>
                        <asp:TextBox runat="server" ID="txtCantidad" Columns="2" Text='<%# Eval("Cantidad") %>'></asp:TextBox><br />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="PrecioUnitario" HeaderText="Precio" ItemStyle-HorizontalAlign="Right"
                    HeaderStyle-HorizontalAlign="Right" DataFormatString="{0:C}" />
                <asp:BoundField DataField="Total" HeaderText="Total" ItemStyle-HorizontalAlign="Right"
                    HeaderStyle-HorizontalAlign="Right" DataFormatString="{0:C}" />
            </Columns>
        </asp:GridView>
        <br />
        <asp:Button runat="server" ID="btActulizar" Text="Actualizar el Carrito"
            OnClick="btActulizar_Click" />
    </div>
</asp:Content>
