﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="KallSonysB2C.ShoppingCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <script lang="Javascript">
       <!--
    function isNumberKey(evt) {
        var charCode = (evt.which) ? evt.which : evt.keyCode;
        if (charCode > 31 && (charCode < 48 || charCode > 57)) {
            return false;
        }
        return true;
    }
    //-->
    </script>
    <div id="ShoppingCartTitle" runat="server" class="ContentHead"><h1>Carrito de Compras</h1></div>
    <asp:GridView ID="CartList" runat="server" AutoGenerateColumns="False" ShowFooter="True" GridLines="Vertical" CellPadding="4"
         CssClass="table table-striped table-bordered" DataKeyNames="ProductID,TipoItem" >   
        <Columns>
        <asp:BoundField DataField="NombreItem" HeaderText="Producto" />        
        <asp:BoundField DataField="valorUnitarioItem" HeaderText="Precio (unidad)" DataFormatString="{0:c}"/>   
        <asp:TemplateField  HeaderText="Cantidad">            
                <ItemTemplate>
                    <asp:TextBox ID="PurchaseQuantity" MaxLength="2" Width="40" runat="server" onkeypress="return isNumberKey(event)" Text='<%# DataBinder.Eval(Container.DataItem, "Quantity") %>'></asp:TextBox> 
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ControlToValidate="PurchaseQuantity"  MinimumValue="1" MaximumValue="99"  ForeColor="red"  
                            Display="Dynamic" ErrorMessage="*" ValidationGroup="Validation"></asp:RangeValidator>
                </ItemTemplate>        
        </asp:TemplateField>    
        <asp:TemplateField HeaderText="Total Item">            
                <ItemTemplate>
                    <%#: String.Format("{0:C}", ((Convert.ToDouble(Eval("Quantity"))) * Convert.ToDouble(Eval("valorUnitarioItem"))))%>
                </ItemTemplate>        
        </asp:TemplateField> 
        <asp:TemplateField HeaderText="Quitar del Carrito">            
                <ItemTemplate>
                    <asp:CheckBox id="Remove" runat="server"></asp:CheckBox>
                </ItemTemplate>        
        </asp:TemplateField>    
        </Columns>    
    </asp:GridView>
    <div>
        <p></p>
        <strong>
            <asp:Label ID="LabelTotalText" runat="server" Text="Total de la Orden: "></asp:Label>
            <asp:Label ID="lblTotal" runat="server" EnableViewState="false"></asp:Label>
        </strong> 
    </div>
    <br />
    <table> 
    <tr>
      <td>
        <asp:Button ID="UpdateBtn" runat="server" Text="Actualizar" OnClick="UpdateBtn_Click" />
      </td>
      <td>
        <asp:Button ID="PagoBtn" runat="server" Text="Pagar" OnClick="PagoBtn_Click" CausesValidation="true" />
        
      </td>
    </tr>
    </table>
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="True"
        ShowSummary="False" ValidationGroup="Validation" />
</asp:Content>