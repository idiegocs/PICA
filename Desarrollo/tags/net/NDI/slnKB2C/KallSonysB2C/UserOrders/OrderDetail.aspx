<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderDetail.aspx.cs" Inherits="KallSonysB2C.UserOrders.OrderDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div id="UserOrdersTittle" runat="server" class="ContentHead">
        <h2>
        <asp:Label ID="lblTituloDetalle" runat="server"></asp:Label>
       </h2>
    </div>
    <asp:GridView ID="grvDetalleOrden" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4"
        CssClass="table table-striped table-bordered">   
        <Columns>
            <asp:BoundField DataField="tipo" HeaderText="TipoItem" Visible="false" />
            <asp:BoundField DataField="idCampania" HeaderText="IdCampania" Visible="false" />
            <asp:BoundField DataField="producto.idProducto" HeaderText="IdProducto" Visible="false" />
            <asp:BoundField DataField="producto.nombreProducto" HeaderText="Producto" />
            <asp:BoundField DataField="producto.descripcionProducto" HeaderText="Descripción" />
            <asp:BoundField DataField="cantidadItem" HeaderText="Cantidad" />
            <asp:BoundField DataField="producto.precioProducto" HeaderText="Valor" DataFormatString="{0:c}" />
        </Columns>    
    </asp:GridView>
    <br />
    <h2>
        Datos de Envío
    </h2>
    Nombre Usuario:<asp:Label ID="lblNombreUsuario" runat="server"></asp:Label><br />
    Tipo de Documento: <asp:Label ID="lblTipoDocumento" runat="server"></asp:Label><br />
    Número de Documento: <asp:Label ID="lblNumeroDocumento" runat="server"></asp:Label><br />
    Dirección: <asp:Label ID="lblDireccion" runat="server"></asp:Label><br />
    Ciudad: <asp:Label ID="lblCiudad" runat="server"></asp:Label><br />
    Departamento: <asp:Label ID="lblDepartamento" runat="server"></asp:Label><br />
    Teléfono: <asp:Label ID="lblTelefono" runat="server"></asp:Label>
    <br />
    <br />
    <asp:LinkButton ID="lnkVolverListaOrdenes" runat="server" Text="Regresar a la Lista de Ordenes" OnClick="lnkVolverListaOrdenes_Click"></asp:LinkButton>
</asp:Content>
