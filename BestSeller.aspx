<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage1.Master" AutoEventWireup="true" CodeBehind="BestSeller.aspx.cs" Inherits="WebApp2.BestSeller" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style>
        .center-text {
            text-align: center;
        }

         .big-bold-text {
            font-size: 24px; /* Adjust the font size as needed */
            font-weight: bold;
        }


    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="center-text">
     <p class="big-bold-text">BEST WOMEN CLOTHING (TOP PICKS) </p>
        </div>

     
    <div class="product-grid">
    <asp:Repeater ID="Repeater1" runat="server">
        <ItemTemplate>
            <div class="showcase">
                <div class="showcase-banner">
                   
                      <asp:ImageButton 
                    ID="imgButton" 
                    PostBackUrl='<%# ResolveClientUrl("ProductDetails.aspx?ProdID=" + Eval("BS_ID")) %>' 
                    CssClass="bookimage" 
                    ImageUrl='<%# Eval("BS_Image") %>' 
                    runat="server" />

                    <!-- Product Image 
                    <img src='<%# Eval("BS_Image") %>' alt='<%# Eval("BS_Name") %>' width="300" class="product-img default">
                    <img src='<%# Eval("BS_Image") %>' alt='<%# Eval("BS_Name") %>' width="300" class="product-img hover">
                    
                     <asp:ImageButton PostBackUrl='<%# ResolveClientUrl("ProductDetails.aspx?ProdID=" + Eval("BS_ID") ) %>' runat="server" />
                       --> 

    
                    <div class="showcase-actions">
                        <!-- Action Buttons (e.g., Add to Wishlist, View, etc.) --> 
                        <button class="btn-action">
                            <ion-icon name="heart-outline"></ion-icon>
                        </button>
                        <button class="btn-action">
                            <ion-icon name="eye-outline"></ion-icon>
                        </button>
                        <button class="btn-action">
                            <ion-icon name="repeat-outline"></ion-icon>
                        </button>
                        <button class="btn-action">
                            <ion-icon name="bag-add-outline"></ion-icon>
                        </button>
                    </div>
                </div>

                <div class="showcase-content">
                    <!-- Product Category --> 
                    <a href="#" class="showcase-category"><%# Eval("BS_Category") %></a>
                    <!-- Product Name --> 
                    <a href="#">
                        <h3 class="showcase-title"><%# Eval("BS_Name") %></h3>
                    </a>
                   
                        
                   
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>
    <br />
    <br />
    <br />
    <br />

    






</asp:Content>
