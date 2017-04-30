<%@ Page Title="Shopping Cart" Language="C#" MasterPageFile="~/CO5027.Master" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="CO5027.ShoppingCart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Styles/ShoppingCart.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnlShoppingCart" runat="server">
    </asp:Panel>

    <table class="auto-style1">
        <tr>
            <td class="auto-style4"></td>
            <td class="auto-style5"><asp:Button ID="btnContinue" runat="server" PostBackUrl="~/Default.aspx" Text="SHOP MORE" CssClass="detailsButton" OnClick="btnContinue_Click" ></asp:Button>

            </td>
        </tr>
        <tr>
            <td class="auto-style4"><b>Total:</b></td>
            <td class="auto-style9"><asp:Literal ID="litTotal" runat="server" Text=""></asp:Literal></td>
        </tr>
        <tr>
            <td class="auto-style4"><b>Shipping:</b></td>
            <td class="auto-style9">B$5 (Brunei Darussalam)</td>
        </tr>
        <tr>
            <td class="auto-style4"><b>Grand Total:</b></td>
            <td class="auto-style9"><asp:Literal ID="litGrandTotal" runat="server" Text=""></asp:Literal></td>
        </tr>
        
        <tr>
            <td class="auto-style4"></td>
            <td class="auto-style5"><asp:Button ID="btnCheckOut" runat="server" PostBackUrl="~/Success.aspx" Text="CHECKOUT" CssClass="detailsButton" OnClick="btnCheckOut_Click" ></asp:Button></td>
        </tr>
    </table>
</asp:Content>
