<%@ Page Title="Bienvenido a KallSonys !!!" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="KallSonysB2C.Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <!--<h2 style="text-align: center"><%: Title %>.</h2>-->
    <div id="TitleContent" style="text-align: center" class="img-responsive2 center-block">
    <asp:Image  ID="imgKStore" CssClass="img-responsive2 center-block" runat="server" ImageUrl="~/Images/KStore.png" BorderStyle="None" />
    </div>
    <!--<h3><%: Title %>. En KallSonys encontrará todo lo que usted necesita.</h3>-->
    <p class="lead"><%: Title %>. En KallSonys encontrará todo lo que usted necesita.  Ofrecemos toda clase de electrodomésticos, con los mejores precios del mercado.</p>
</asp:Content>