<%@ Page Title="Ordenes" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OrderList.aspx.cs" Inherits="KallSonysB2C.UserOrders.OrderList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div id="UserOrdersTittle" runat="server" class="ContentHead">
        <h1>Sus Ordenes</h1>
    </div>
    Puede filtrar sus ordenes por los siguientes criterios:
    <br /><br />
    <table>
        <tr>
            <td><asp:Label id="lblPreOrden" runat="server" Text="Pre-Orden" Font-Bold="true"></asp:Label></td>
            <td>&nbsp;&nbsp;<asp:RadioButton ID="rdbPreOrden" runat="server" Checked="true" GroupName="filtro" TextAlign="Left" /></td>
            <td>&nbsp;&nbsp;<asp:TextBox ID="txtPreOrden" runat="server" onkeypress="return isNumberKey(event)" MaxLength="15"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label id="lblEstado" runat="server" Text="Estado" Font-Bold="true"></asp:Label></td>
            <td>&nbsp;&nbsp;<asp:RadioButton ID="rdbEstado" runat="server" Checked="false" GroupName="filtro" TextAlign="Left" /></td>
            <td>&nbsp;&nbsp;<asp:DropDownList ID="ddlEstadoOrden" runat="server" DataTextField="nombreEstadoOrden" DataValueField="idEstadoOrden" Enabled="false"></asp:DropDownList></td>
        </tr>
        <tr>
            <td colspan="3"><asp:Button ID="btnBuscarOrdenes" runat="server" Text="Buscar" OnClick="btnBuscarOrdenes_Click" /></td>
        </tr>
    </table>
    <br />
    <asp:GridView ID="grvOrdenes" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4"
        CssClass="table table-striped table-bordered">   
        <Columns>
            <asp:BoundField DataField="idPreOrden" HeaderText="Orden Nro." SortExpression="idPreOrden" Visible="true" />     
            <asp:BoundField DataField="fechaOrden" HeaderText="Fecha Orden" DataFormatString="{0:D}" />        
            <asp:BoundField DataField="totalOrden" HeaderText="Monto Orden" DataFormatString="{0:c}" />
            <asp:BoundField DataField="idEstadoOrden" Visible="false" />
            <asp:BoundField DataField="estadoOrden" HeaderText="Estado Orden" />
            <asp:TemplateField HeaderText="Detalle">
                <ItemTemplate>
                    <asp:LinkButton ID="lnkVerDetalle" runat="server" Text="Ver detalle Orden" OnCommand="lnkVerDetalle_Click"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>    
    </asp:GridView>
    <script lang="Javascript">
       <!--
    function isNumberKey(evt) {
        var charCode = (evt.which) ? evt.which : evt.keyCode;
        if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;
        return true;
    }
    //-->
    </script>
    <script lang="javascript" type="text/javascript">
        $().ready(function () {

            $("#<%=rdbPreOrden.ClientID%>").click(function () {

                $("#<%=txtPreOrden.ClientID%>").attr('disabled', false);
                $("#<%=ddlEstadoOrden.ClientID%>").val("-1").attr("selected", "selected");
                $("#<%=ddlEstadoOrden.ClientID%>").attr('disabled', true);
                $("#<%=txtPreOrden.ClientID%>").focus();
            });

            $("#<%=rdbEstado.ClientID%>").click(function () {

                $("#<%=ddlEstadoOrden.ClientID%>").attr('disabled', false);
                $("#<%=txtPreOrden.ClientID%>").attr('disabled', true);
                $("#<%=txtPreOrden.ClientID%>").val('');
            });

            $("#<%=btnBuscarOrdenes.ClientID%>").click(function () {

                if ($("#<%=rdbPreOrden.ClientID%>").is(':checked')) {

                    if ($("#<%=txtPreOrden.ClientID%>").val().length == 0) {
                        alert("Debe digitar el número de Pre-Orden..!");
                        $("#<%=txtPreOrden.ClientID%>").attr('disabled', false);
                        $("#<%=ddlEstadoOrden.ClientID%>").val("-1").attr("selected", "selected");
                        $("#<%=ddlEstadoOrden.ClientID%>").attr('disabled', true);
                        $("#<%=txtPreOrden.ClientID%>").focus();
                        return false;
                    }
                }
                else {
                    if ($("#<%=ddlEstadoOrden.ClientID%>").val() == "-1") {
                        alert("Debe seleccionar el Estado de la Orden..!");
                        $("#<%=ddlEstadoOrden.ClientID%>").attr('disabled', false);
                        $("#<%=txtPreOrden.ClientID%>").attr('disabled', true);
                        $("#<%=txtPreOrden.ClientID%>").val('');
                        return false;
                    }
                }



            });

        });

    </script>
</asp:Content>