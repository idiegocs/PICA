<%@ Page Title="Confirmar Orden" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="True" 
    EnableEventValidation="false" CodeBehind="CheckoutReview.aspx.cs" Inherits="KallSonysB2C.Checkout.CheckoutReview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 
    
    <h1>Verificaci&oacute;n Orden Pedido</h1>
    <p></p>
    <h3>Productos:</h3>
    <asp:GridView ID="OrderItemList" runat="server" AutoGenerateColumns="False" GridLines="Both" CellPadding="10" 
        Width="95%" BorderColor="#efeeef" BorderWidth="10" CssClass="table table-striped table-bordered">
        <Columns>
            <asp:BoundField DataField="ProductId" HeaderText=" ID Producto" Visible="false" />
            <asp:BoundField DataField="Product.nombreProducto" HeaderText="Nombre Producto" ItemStyle-Width="55%" />
            <asp:BoundField DataField="Product.precioProducto" HeaderText="Precio (Unidad)" DataFormatString="{0:c}" ItemStyle-Width="30%" />
            <asp:BoundField DataField="Quantity" HeaderText="Cantidad" ItemStyle-Width="15%"/>
        </Columns>
    </asp:GridView>

    <asp:DetailsView ID="ShipInfo" runat="server" AutoGenerateRows="false" GridLines="None" CellPadding="0" BorderStyle="None" CommandRowStyle-BorderStyle="None"  Width="790px" Style="margin-right: 385px">
        <Fields>
            <asp:TemplateField>
                <ItemTemplate>
                    <p></p>
                    <h3>Orden Total:</h3>
                    <asp:Label ID="Total" runat="server" Text='<%#: Eval("Total", "{0:C}") %>'></asp:Label>
                    <br />
                </ItemTemplate>
                <ItemStyle HorizontalAlign="Left" />
            </asp:TemplateField>
        </Fields>
    </asp:DetailsView>
    <p></p>
    <div class="form-horizontal">
        <h3>Informaci&oacute;n Envio:</h3>
        <hr />
        <asp:PlaceHolder runat="server" ID="ErrorMessage" Visible="false">
            <p class="text-danger">
                <asp:Literal runat="server" ID="FailureText" />
            </p>
        </asp:PlaceHolder>
        <div>
            <table style="width:70%">
                <tr>
                    <td style="align-content:center">
                        <asp:Label ID="lblPais" runat="server" Font-Bold="true">País</asp:Label>&nbsp;&nbsp;
                        <asp:DropDownList ID="ddlPais" Width="150px" runat="server" OnSelectedIndexChanged="ddlPais_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="lblDepar" runat="server" Font-Bold="true">Departamento</asp:Label>&nbsp;&nbsp;
                        <asp:DropDownList ID="ddlDepartamento" Width="150px" runat="server" OnSelectedIndexChanged="ddlDepartamento_SelectedIndexChanged"></asp:DropDownList>
                    </td>
                    <td>
                        <asp:Label ID="lblCiudad" runat="server" Font-Bold="true">Ciudad</asp:Label>&nbsp;&nbsp;
                        <asp:DropDownList ID="ddlCiudad" Width="150px" runat="server"></asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>
        <br />
        <div class="form-group">
            <asp:Label ID="LabelNombre" runat="server" AssociatedControlID="TextBoxNombre" CssClass="col-md-2 control-label">Nombre</asp:Label>
            <div class="col-md-10">
                <asp:TextBox ID="TextBoxNombre" runat="server" CssClass="form-control" TextMode="SingleLine"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidatorNombre" runat="server" ErrorMessage="El Nombre es Requerido." CssClass="text-danger" ControlToValidate="TextBoxNombre"></asp:RequiredFieldValidator>

            </div>
            <asp:Label ID="LabelApellido" runat="server" AssociatedControlID="TextBoxApellido" CssClass="col-md-2 control-label">Apellido</asp:Label>
            <div class="col-md-10">
                <asp:TextBox ID="TextBoxApellido" runat="server" CssClass="form-control" TextMode="SingleLine"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidatorApell" runat="server" ErrorMessage="El Apellido es Requerido." CssClass="text-danger" ControlToValidate="TextBoxApellido"></asp:RequiredFieldValidator>

            </div>
            <asp:Label ID="LabelTipoDoc" runat="server" AssociatedControlID="DropDownTipoDoc" CssClass="col-md-2 control-label">Tipo de Documento</asp:Label>

            <asp:DropDownList ID="DropDownTipoDoc" runat="server">
                <asp:ListItem Text="Cedula" Value="C"></asp:ListItem>
                <asp:ListItem Text="Trajeta Identidad" Value="T"></asp:ListItem>
            </asp:DropDownList>
            <div>
                <br />
            </div>
            <div>
                <br />
            </div>
            <asp:Label ID="LabelNoDoc" runat="server" AssociatedControlID="TextBoxNoDoc" CssClass="col-md-2 control-label">No Documento</asp:Label>
            <div class="col-md-10">
                <asp:TextBox ID="TextBoxNoDoc" runat="server" CssClass="form-control" TextMode="SingleLine"></asp:TextBox>

                <asp:RequiredFieldValidator ID="RequiredFieldValidatorNoDoc" runat="server" ErrorMessage="El No de Documento es Requerido." CssClass="text-danger" ControlToValidate="TextBoxNoDoc"></asp:RequiredFieldValidator>

            </div>
            <asp:Label ID="LabelCorreo" runat="server" AssociatedControlID="TextBoxCorreo" CssClass="col-md-2 control-label">Correo Electronico</asp:Label>
            <div class="col-md-10">
                <asp:TextBox ID="TextBoxCorreo" runat="server" CssClass="form-control" TextMode="Email"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorCorreo" runat="server" ErrorMessage="El Correo Electronico es Requerido." CssClass="text-danger" ControlToValidate="TextBoxCorreo"></asp:RequiredFieldValidator>

            </div>
            <asp:Label ID="LabelTelefono" runat="server" AssociatedControlID="TextBoxTelefono" CssClass="col-md-2 control-label">Telefono</asp:Label>
            <div class="col-md-10">
                <asp:TextBox ID="TextBoxTelefono" runat="server" CssClass="form-control" TextMode="SingleLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorTelefono" runat="server" ErrorMessage="El Telefono es Requerido." CssClass="text-danger" ControlToValidate="TextBoxTelefono"></asp:RequiredFieldValidator>

            </div>

            <asp:Label ID="LabelDireccion" runat="server" AssociatedControlID="TextBoxDireccion" CssClass="col-md-2 control-label">Direccion</asp:Label>
            <div class="col-md-10">
                <asp:TextBox ID="TextBoxDireccion" runat="server" CssClass="form-control" TextMode="SingleLine"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidatorDirecc" runat="server" ErrorMessage="La Direccion es Requerida." CssClass="text-danger" ControlToValidate="TextBoxDireccion"></asp:RequiredFieldValidator>

            </div>
        </div>

    </div>

    <br />
    <h3>Informaci&oacute;n Pago:</h3>
    <hr />
    <br />
    <asp:Label ID="LabelNombreTitularTJ" runat="server" AssociatedControlID="TextBoxnomTJ" CssClass="col-md-2 control-label">Nombre Titular</asp:Label>
    <div class="col-md-10">
        <asp:TextBox ID="TextBoxnomTJ" runat="server" CssClass="form-control" TextMode="SingleLine"></asp:TextBox>

        <asp:RequiredFieldValidator ID="RequiredFieldValidatorTitular" runat="server" ErrorMessage="El Nombre del Titular es Requerido." CssClass="text-danger" ControlToValidate="TextBoxnomTJ"></asp:RequiredFieldValidator>

    </div>
    <asp:Label ID="LabelNumeroTJ" runat="server" AssociatedControlID="TextBoxNumeroTJ" CssClass="col-md-2 control-label">Numero Tarjeta</asp:Label>
    <div class="col-md-10">
        <asp:TextBox ID="TextBoxNumeroTJ" runat="server" CssClass="form-control" TextMode="SingleLine"></asp:TextBox>

        <asp:RequiredFieldValidator ID="RequiredFieldValidatorNumeroTJ" runat="server" ErrorMessage="El Numero de la Tarjeta es Requerido." CssClass="text-danger" ControlToValidate="TextBoxNumeroTJ"></asp:RequiredFieldValidator>

    </div>
    <b><asp:Label ID="LabelFechaExp" runat="server" CssClass="col-md-2 control-label">Fecha Expiraci&oacute;n</asp:Label></b>
    <div class="col-md-10">
        <asp:dropdownlist ID="ddlMes" runat="server">
            <asp:ListItem Selected="True" Value="-1">[Seleccione]</asp:ListItem>
            <asp:ListItem Value="01">01</asp:ListItem>
            <asp:ListItem Value="02">02</asp:ListItem>
            <asp:ListItem Value="03">03</asp:ListItem>
            <asp:ListItem Value="04">04</asp:ListItem>
            <asp:ListItem Value="05">05</asp:ListItem>
            <asp:ListItem Value="06">06</asp:ListItem>
            <asp:ListItem Value="07">07</asp:ListItem>
            <asp:ListItem Value="08">08</asp:ListItem>
            <asp:ListItem Value="09">09</asp:ListItem>
            <asp:ListItem Value="10">10</asp:ListItem>
            <asp:ListItem Value="11">11</asp:ListItem>
            <asp:ListItem Value="12">12</asp:ListItem>
        </asp:dropdownlist>&nbsp;&nbsp;&nbsp;
        <asp:dropdownlist ID="ddlAnio" runat="server"></asp:dropdownlist>
        <asp:RequiredFieldValidator ID="rfvMesVenceTarjeta" runat="server" ErrorMessage="El Mes de Vencimiento de la Tarjeta es Requerido." CssClass="text-danger" ControlToValidate="ddlMes" InitialValue="-1"></asp:RequiredFieldValidator>
        <asp:RequiredFieldValidator ID="rfvAnioVenceTarjeta" runat="server" ErrorMessage="El Año de Vencimiento de la Tarjeta es Requerido." CssClass="text-danger" ControlToValidate="ddlAnio" InitialValue="-1"></asp:RequiredFieldValidator>
    </div>
    <br /><br />
    <asp:Label ID="LabelCodVeri" runat="server" AssociatedControlID="TextBoxCodigoVeri" CssClass="col-md-2 control-label">Codigo Verificaci&oacute;n</asp:Label>
    <div class="col-md-10">
        <asp:TextBox ID="TextBoxCodigoVeri" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>

        <asp:RequiredFieldValidator ID="RequiredFieldValidatorCodVeri" runat="server" ErrorMessage="El Codigo de verificaci&oacute;n es Requerido." CssClass="text-danger" ControlToValidate="TextBoxCodigoVeri"></asp:RequiredFieldValidator>

    </div>
    <br />
    <asp:Button ID="CheckoutConfirm" runat="server" Text="Confirmar Pago" OnClick="CheckoutConfirm_Click" />
       
</asp:Content>
