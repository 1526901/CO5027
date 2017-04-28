<%@ Page Title="Contact" Language="C#" MasterPageFile="~/CO5027.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="CO5027.Contact" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="Styles/Contact.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="grid_24">
        <h2>CONTACT US</h2>
    </div>
    <div class="grid_13">
        <table>
            <tr>
                <td class="auto-style4">Name:</td>
                <td class="auto-style5"><asp:TextBox ID="txtName" runat="server" Width="350px" Height="20px"></asp:TextBox></td>
                <td class="auto-style5"><asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Name Required" ControlToValidate="txtName" Text="*" ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="auto-style4">E-mail:</td>
                <td class="auto-style5"><asp:TextBox ID="txtEmail" runat="server" Width="350px" Height="20px"></asp:TextBox></td>
                <td class="auto-style5"><asp:RequiredFieldValidator ID="RequiredFieldValidator2" Display="Dynamic"  runat="server" ErrorMessage="E-mail Required"  ControlToValidate="txtEmail" Text="*" ForeColor="Red"></asp:RequiredFieldValidator>
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
                <td class="auto-style4">Subject:</td>
                <td class="auto-style5"><asp:TextBox ID="txtSubject" runat="server" Width="350px" Height="20px"></asp:TextBox></td>
                <td class="auto-style5"><asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Subject Required"  ControlToValidate="txtSubject" Text="*" ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td class="auto-style2">Message:</td>
                <td class="auto-style6"><asp:TextBox ID="txtMessage" runat="server" Height="100px" TextMode="MultiLine" Width="350px"></asp:TextBox>
                </td>
                <td class="auto-style6"><asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Message Required" ControlToValidate="txtMessage" Text="*" ForeColor="Red"></asp:RequiredFieldValidator></td>
            </tr>
            <tr>
                <td colspan="3">
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" />
                </td>
            </tr>  
            <tr>
                <td colspan="3" class="auto-style3">
                    <asp:Button ID="btnSend" runat="server" Text="SEND" OnClick="btnSend_Click" CssClass="detailsButton" />
                </td>
            </tr>            
            <tr>
              
                <td colspan="3">
                    <asp:Literal ID="Literal1" runat="server"></asp:Literal>
                </td>
            </tr>
            
        </table>
    </div>
    <div class="grid_11">

        <h3>TELEPHONE</h3>
        <p>123 456 7890</p>

        <h3>ADDRESS</h3>
        <p>Unit 1.01, First Floor, Kiulap Plaza Hotel, Kampong Kiulap</p>
        <p>BE1518, Bandar Seri Begawan, Brunei Darussalam</p>

        <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3975.221992810871!2d114.92454191418047!3d4.902474696440536!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3222f54814297205%3A0xdbb7dcb091417fa!2sKiulap+Plaza+Hotel!5e0!3m2!1sen!2sbn!4v1491325751447"
            width="430" height="320"></iframe>
    </div>
        <div class="clearboth"></div>
</asp:Content>