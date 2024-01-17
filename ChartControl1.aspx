<%@ Page Title="" Language="C#" MasterPageFile="~/AdminMaster.Master" AutoEventWireup="true" CodeBehind="ChartControl1.aspx.cs" Inherits="WebApp2.ChartControl1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<style>
    
    #chartContainer {
        text-align: center;
    }

    #DropDownList1, #Chart1 {
        margin: 0 auto;
        display: block;
        text-align: center;
    }

    #Chart1 {
        max-width: 600px; /* Adjust as needed */
         text-align: center;
    }


</style>





</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
        <div>
           
            Select Chart Type: 
            <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged">
                <asp:ListItem Text="Column" Value="Column" />
                <asp:ListItem Text="Bar" Value="Bar" />
                <asp:ListItem Text="Pie" Value="Pie" />
            </asp:DropDownList>

            <asp:Chart ID="Chart1" runat="server" Height="357px" Width="385px">
                <series>
                    <asp:Series Name="ProductCategories" ChartType="Column">
                    </asp:Series>
                </series>
                <chartareas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </chartareas>
            </asp:Chart>
        </div>
</asp:Content>