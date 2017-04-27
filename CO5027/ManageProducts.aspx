<%@ Page Title="" Language="C#" MasterPageFile="~/CO5027.Master" AutoEventWireup="true" CodeBehind="ManageProducts.aspx.cs" Inherits="CO5027.Management.ManageProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <p>
    Name:</p>
<p>
    <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
</p>
<p>
    Type:</p>
<p>
    <asp:DropDownList ID="ddlType" runat="server" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="ID">
    </asp:DropDownList>
    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="Data Source=SQL2016.FSE.Network;Persist Security Info=True;User ID=user_db_1526901_co5027;Password=1526901;MultipleActiveResultSets=True;Application Name=EntityFramework" ProviderName="System.Data.SqlClient" SelectCommand="SELECT * FROM [ProductTypes] ORDER BY [Name]"></asp:SqlDataSource>
</p>
<p>
    Price:</p>
<p>
    <asp:TextBox ID="txtPrice" runat="server" TextMode="Number"></asp:TextBox>
</p>
<p>
    Image:</p>
<p>
    <asp:DropDownList ID="ddlImage" runat="server">
    </asp:DropDownList>
</p>
<p>
    Description:</p>
<p>
    <asp:TextBox ID="txtDescription" runat="server" Height="90px" TextMode="MultiLine" Width="318px"></asp:TextBox>
</p>
<p>
    <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" />
</p>
<p>
    <asp:Label ID="lblResult" runat="server"></asp:Label>
</p>
</asp:Content>
