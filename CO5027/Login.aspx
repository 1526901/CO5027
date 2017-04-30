<%@ Page Title="Login" Language="C#" MasterPageFile="~/CO5027.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="CO5027.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Styles/Login.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="grid_12">
        <h2>LOGIN</h2>
        <asp:Literal ID="litStatus1" runat="server"></asp:Literal>
        <table>
            <tr>
                <td class="auto-style12">Username:</td>
                <td class="auto-style9"><asp:TextBox ID="txtUsername1" runat="server" Height="20px" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="Username Required" ControlToValidate="txtUsername1" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style12">Password:</td>
                <td class="auto-style9"><asp:TextBox ID="txtPassword1" runat="server" TextMode="Password" Height="20px" Width="200px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="Password Required" ControlToValidate="txtPassword1" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td colspan="2"><asp:Literal ID="litStatus3" runat="server"></asp:Literal></td>
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
                <td class="auto-style8">Username:</td>
                <td class="auto-style9"><asp:TextBox ID="txtUserName" runat="server" Height="20px" Width="200px"></asp:TextBox></td>
                <td class="auto-style9"><asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="Username Required" ControlToValidate="txtUsername" Text="*" ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="auto-style8">Password:</td>
                <td class="auto-style9"><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" Height="20px" Width="200px"></asp:TextBox></td>
                <td class="auto-style9"><asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="Password Required" ControlToValidate="txtPassword" Text="*" ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="auto-style8">Confirm Password:</td>
                <td class="auto-style9"><asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" Height="20px" Width="200px"></asp:TextBox></td>
                <td class="auto-style9"><asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="Confirm Password Required" ControlToValidate="txtConfirmPassword" Text="*" ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="auto-style10">First Name:</td>
                <td class="auto-style9"><asp:TextBox ID="txtFirstName" runat="server" Height="20px" Width="200px"></asp:TextBox></td>
                <td class="auto-style9"><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="First Name Required" ControlToValidate="txtFirstName" Text="*" ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="auto-style8">Last Name:</td>
                <td class="auto-style9"><asp:TextBox ID="txtLastName" runat="server" Height="20px" Width="200px"></asp:TextBox></td>
                <td class="auto-style9"><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Last Name Required" ControlToValidate="txtLastName" Text="*" ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="auto-style8">E-mail:</td>
                <td class="auto-style9"><asp:TextBox ID="txtEmail" runat="server" Height="20px" Width="200px"></asp:TextBox></td>
                <td class="auto-style9">
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator8" Display="Dynamic"  runat="server" ErrorMessage="E-mail Required"  ControlToValidate="txtEmail" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator 
                        Display="Dynamic" 
                        ForeColor="Red" 
                        ID="RegularExpressionValidator1"
                        runat="server" 
                        ErrorMessage="Invalid Email" 
                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                        ControlToValidate="txtEmail"
                        Text="*"></asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style15">Address:</td>
                <td class="auto-style16"><asp:TextBox ID="txtAddress" runat="server" Height="50px" TextMode="MultiLine" Width="200px"></asp:TextBox></td>
                <td class="auto-style16"><asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Address Required" ControlToValidate="txtAddress" Text="*" ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="auto-style8">Postal Code:</td>
                <td class="auto-style9"><asp:TextBox ID="txtPostalCode" runat="server" Height="20px" Width="200px"></asp:TextBox></td>
                <td class="auto-style9"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Postal Code Required" ControlToValidate="txtPostalCode" Text="*" ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                </td>
            </tr>            
            <tr>
                <td colspan="3" class="auto-style3"><asp:Button ID="btnRegister" runat="server" Text="REGISTER" EnableTheming="True" CssClass="detailsButton" OnClick="btnRegister_Click" /></td>
            </tr>

        </table>
    </div>
        <div class="clearboth"></div>
</asp:Content>
