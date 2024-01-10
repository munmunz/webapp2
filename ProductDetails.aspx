<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeFile="ProductDetails.aspx.cs" Inherits="ProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="server">
    <link rel="stylesheet" type="text/css" href="assets/css/ProductDetails.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">

 <asp:Label ID="lblProductName" runat="server" Text="Label"></asp:Label>
<asp:Label ID="lblProductDesc" runat="server" Text="Label"></asp:Label>
<asp:Label ID="lblProductCategory" runat="server" Text="Label"></asp:Label>
<asp:Label ID="lblProductPrice" runat="server" Text="Label"></asp:Label>




</asp:Content>
