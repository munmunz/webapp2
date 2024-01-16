<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="WebApp2.ProductDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="server">
    <link rel="stylesheet" type="text/css" href="assets/css/ProductDetails.css" />
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="server">

    <div class="product-featured">

    

        <div class="showcase-wrapper has-scrollbar">

            <div class="showcase-container">

                <div class="showcase">

                    <div class="showcase-banner">
                        <asp:Image ID="imgProductDetails" runat="server"  CssClass="showcase-img" />
                    </div>

                    <div class="showcase-content">

                        <a href="#">
                            <h3 class="showcase-title">
                                <asp:Label ID="lblProductName" runat="server" CssClass="product-name" Text='<%# Eval("ProductName") %>'></asp:Label>
                            </h3>
                        </a>

                        <p class="showcase-desc">
                            <asp:Label ID="lblProductDesc" runat="server" CssClass="product-description" Text='<%# Eval("ProductDescription") %>'></asp:Label>
                        </p>

                        <div class="price-box">
                            <p class="price">
                                <asp:Label ID="lblProductPrice" runat="server" CssClass="product-price" Text='<%# String.Format("${0}", Eval("ProductPrice")) %>'></asp:Label>
                            </p>

                            <!-- Optional if you want to show the original price with a strikethrough -->
                            <!-- <del>$200.00</del> -->

                        </div>

                        <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" CssClass="add-cart-btn" />

                        <!-- Additional details or sections can be added as needed -->

                    </div>

                </div>

            </div>

        </div>

    </div>

</asp:Content>
