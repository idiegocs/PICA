<%@ Page Title="Ordenes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="KallSonysB2C.UserOrders.OrderList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div id="UserOrdersTittle" runat="server" class="ContentHead"><h1>Sus Ordenes</h1></div>
    <asp:GridView ID="grvOrdenes" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4"
        CssClass="table table-striped table-bordered">   
        <Columns>
            <asp:BoundField DataField="idOrden" HeaderText="Orden Nro." SortExpression="idOrden" Visible="true" />     
            <asp:BoundField DataField="fechaOrden" HeaderText="Fecha Orden" DataFormatString="{0:D}" />        
            <asp:BoundField DataField="totalOrden" HeaderText="Monto Orden" DataFormatString="{0:c}"/>
            <asp:BoundField DataField="idEstadoOrden" Visible="false" />
            <asp:BoundField DataField="estadoOrden" HeaderText="Estado Orden" />
            <asp:TemplateField HeaderText="Detalle">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkVerDetalle" runat="server" Text="Ver detalle Orden" OnCommand="lnkVerDetalle_Click"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>    
    </asp:GridView>
</asp:Content>
