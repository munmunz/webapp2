<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChartControl.aspx.cs" Inherits="WebApp2.ChartControl" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

     <style>
        body {
            font-family: Arial, sans-serif;
            text-align: center; /* Center align the content */
        }

        #chartContainer {
            max-width: 600px;
            margin: 20px auto;
            text-align: left; /* Align the container content to the left */
        }

        #DropDownList1 {
            margin-bottom: 10px;
        }
    </style>


</head>
<body>
     <form id="form1" runat="server">
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
    </form>
</body>
</html>
