<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CheckoutComplete.aspx.cs" Inherits="KallSonysB2C.Checkout.CheckoutComplete" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Orden Completa</h1>
    <p></p>
    <h3>PreOrden ID:</h3> <asp:Label ID="TransactionIDLabel" runat="server"></asp:Label>
    <p></p>
    <h3>Gracias!</h3>
    <p></p>
    <hr />
    <asp:Button ID="Continue" runat="server" Text="Continue Comprando" OnClick="Continue_Click" />
</asp:Content>