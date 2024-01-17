<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Admin-BestSeller.aspx.cs" Inherits="WebApp2.Admin_BestSeller" %>
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

                    <div class="showcase-actions">
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
                    <a href="#" class="showcase-category"><%# Eval("BS_Category") %></a>
                    <a href="#">
                        <h3 class="showcase-title"><%# Eval("BS_Name") %></h3>
                    </a>
                </div>

                <!-- Additional code for edit, update, cancel, delete -->
                <div>
                    <asp:Label ID="lblBookId" runat="server" Text='<%# Eval("BS_ID") %>' Visible="False"></asp:Label>
                    <br />


                    <!-- removed onedit and onupdate and oncancel and ondelete for now -->


                    <asp:LinkButton ID="lnkEdit" Text="Edit |" runat="server"  />
                    <asp:LinkButton ID="lnkUpdate" Text="Update |" runat="server" Visible="false"  />
                    <asp:LinkButton ID="lnkCancel" Text="Cancel |" runat="server" Visible="false" />
                    <asp:LinkButton
                        ID="lnkDelete"
                        Text="Delete"
                        runat="server"
                        
                        OnClientClick="return confirm('Are you sure you want to delete this?');"
                         />
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</div>




</asp:Content>
