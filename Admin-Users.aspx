<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="Admin-Users.aspx.cs" Inherits="WebApp2.Admin_Users" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<style>
    .GVcontainer {
        height: auto;
        width: 80%;
        border: 1px solid #ccc;
        margin: 40px auto;
        padding: 10px;
        box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
    }

    #<%= gvUsers.ClientID %> {
        width: 100%;
        border-collapse: collapse;
        margin-top: 10px;
        table-layout: fixed; /* Set the table layout to fixed */
    }

    #<%= gvUsers.ClientID %> th, #<%= gvUsers.ClientID %> td {
        border: 1px solid #ddd;
        padding: 15px;
        text-align: left;
        width: 20%; /* Equal width for each column */
    }

    #<%= gvUsers.ClientID %> th {
        background-color: #f2f2f2;
    }
</style>

       <script>
        function confirmDelete() {
            return confirm('Are you sure you want to delete this record?');
        }
       </script>
  


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <div class="GVcontainer">
        <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" AllowPaging="True" DataKeyNames="Id" DataSourceID="SqlDataSource1" OnRowDeleting="gvUsers_RowDeleting">
            <Columns>
                <asp:BoundField DataField="Email" HeaderText="Email" SortExpression="Email" />
                <asp:BoundField DataField="Last_Name" HeaderText="Last_Name" SortExpression="Last_Name" />
                <asp:BoundField DataField="First_Name" HeaderText="First_Name" SortExpression="First_Name" />
                <asp:BoundField DataField="Id" HeaderText="Id" ReadOnly="True" SortExpression="Id" />


                   <asp:TemplateField>
            <ItemTemplate>
                <asp:Button runat="server" CommandName="Delete" Text="Delete" OnClientClick='return confirm("Are you sure you want to delete this user?");' CssClass="btn btn-danger" />
            </ItemTemplate>
        </asp:TemplateField>


            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ShoppingDB %>" SelectCommand="SELECT [Email], [Last_Name], [First_Name], [Id] FROM [REGISTRATION]"></asp:SqlDataSource>
    </div>





</asp:Content>
