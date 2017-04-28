<%@ Page Title="Product" Language="C#" MasterPageFile="~/CO5027.Master" AutoEventWireup="true" CodeBehind="Product.aspx.cs" Inherits="CO5027.Product1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Styles/Product.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="grid_10"><asp:Image ID="imgProduct" runat="server" Height="370px" Width="370px" /></div>
    <div class="grid_14">
        <table>
            <tr><td class="auto-style6"><h1><asp:Label ID="lblTitle" runat="server" Text="Label"></asp:Label></h1></td></tr>
            <tr><td class="auto-style5">Product Number: <asp:Label ID="lblItemNo" runat="server" Text="Label"></asp:Label></td></tr>
            <tr><td class="auto-style4"><asp:Label ID="lblDescription" runat="server" Text="Label" CssClass="detailsDescription"></asp:Label></td></tr>
            <tr><td class="auto-style2"><asp:Label ID="lblPrice" runat="server" Text="Label" CssClass="detailsPrice"></asp:Label></td></tr>
            <tr><td class="auto-style1">Quantity: <asp:DropDownList ID="ddlAmount" runat="server"></asp:DropDownList></td></tr>
            <tr><td><asp:Button ID="btnAdd" runat="server" Text="ADD TO CART" CssClass="detailsButton" OnClick="btnAdd_Click" /></td></tr>
            <tr><td class="auto-style3"><asp:Label ID="lblResult" runat="server"></asp:Label></td></tr>
        </table>
    </div>
    <div class="clearboth"></div>
</asp:Content>
