<%@ Page Title="Registro" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="KallSonysB2C.Account.Register" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <script type="text/javascript">
        function InvalidMsg(textbox) {
            if (textbox.validity.typeMismatch) {
                {
                    textbox.setCustomValidity('Correo Electrónico inválido, favor verifique');
                }
            }
            else {
                textbox.setCustomValidity('');
            }
            return true;
        }
    </script>
    <h2><%: Title %>.</h2>
    <p class="text-danger">
        <asp:Literal runat="server" ID="ErrorMessage" />
    </p>

    <div class="form-horizontal">
        <h4>Crear una nueva cuenta</h4>
        <hr />
        <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="text-danger" Visible="false" />
        <div class="form-group">
            <asp:Label ID="Label1" runat="server" AssociatedControlID="Email" CssClass="col-md-2 control-label">Correo Electrónico</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Email" CssClass="form-control" TextMode="Email" Type="email" oninvalid="InvalidMsg(this);" oninput="InvalidMsg(this);" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Email"
                    CssClass="text-danger" ErrorMessage="El campo Correo Electrónico es Requerido" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="Label2" runat="server" AssociatedControlID="Password" CssClass="col-md-2 control-label">Password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="Password" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="Password"
                    CssClass="text-danger" ErrorMessage="El campo Password es Requerido" />
            </div>
        </div>
        <div class="form-group">
            <asp:Label ID="Label3" runat="server" AssociatedControlID="ConfirmPassword" CssClass="col-md-2 control-label">Confirme el password</asp:Label>
            <div class="col-md-10">
                <asp:TextBox runat="server" ID="ConfirmPassword" TextMode="Password" CssClass="form-control" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="El campo Confirme el password es Requerido " />
                <asp:CompareValidator ID="CompareValidator1" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword"
                    CssClass="text-danger" Display="Dynamic" ErrorMessage="Los password no concuerdan" />
            </div>
        </div>
        <div class="form-group">
            <div class="col-md-offset-2 col-md-10">
                <asp:Button ID="Button1" runat="server" OnClick="CreateUser_Click" Text="Registrate" CssClass="btn btn-default" />
            </div>
        </div>
    </div>
</asp:Content>