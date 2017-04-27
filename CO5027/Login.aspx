<%@ Page Title="Login" Language="C#" MasterPageFile="~/CO5027.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CO5027.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style2 {
            height: 200px;
        }
        .auto-style3 {
            height: 144px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="grid_12">
        <h2>LOGIN</h2>
        <asp:Literal ID="litStatus1" runat="server"></asp:Literal>
        <table>
            <tr>
                <td>Username:</td>
                <td><asp:TextBox ID="txtUsername1" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Password:</td>
                <td><asp:TextBox ID="txtPassword1" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" class="auto-style2"><asp:Button ID="btnLogin" runat="server" Text="LOGIN" EnableTheming="True" CssClass="detailsButton" OnClick="btnLogin_Click" /></td>
            </tr>
        </table>
    </div>
    <div class="grid_12">
        <h2>REGISTER</h2>
        <asp:Literal ID="litStatus" runat="server"></asp:Literal>
        <table>
            <tr>
                <td>Username:</td>
                <td><asp:TextBox ID="txtUserName" runat="server"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Password:</td>
                <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td>Confirm Password:</td>
                <td><asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2" class="auto-style3"><asp:Button ID="btnRegister" runat="server" Text="REGISTER" EnableTheming="True" CssClass="detailsButton" OnClick="btnRegister_Click" /></td>
            </tr>
        </table>
    </div>
        <div class="clearboth"></div>
</asp:Content>
