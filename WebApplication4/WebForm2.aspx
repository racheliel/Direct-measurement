<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="WebApplication4.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Direct Measurement</title>
    <style type="text/css">
        *{
	        box-sizing: border-box; 
         }
        body {
            width: 70%;
            margin: 0 auto;
            background-color: #F8F8F8;
            font-family: David;

        }
        #MainTitle{
             font-family: AR BONNIE;
             font-size: 100px;
             display: block;
             margin-left: auto;
             margin-right: auto;
        }
        .auto-style2 {
            font-size: x-large;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-weight: 700">
    
        <asp:Label ID="MainTitle" runat="server" Font-Bold="True" ForeColor="#003366" Text="Direct Measurement" style="text-align: center"></asp:Label>
        <br />
        <br />
        <br />
    
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="I want to change all the line" BorderColor="#003366" BorderWidth="1px" Font-Bold="True" ForeColor="#003366" style="font-size: medium" />
        <br />
        <br />
        <br />
        <span class="auto-style2">Choose the value</span>&nbsp;
        <asp:DropDownList ID="type" runat="server" Font-Bold="True" style="font-size: medium">
        </asp:DropDownList>
        &nbsp; <span class="auto-style2">and its location in the table</span>&nbsp; <asp:DropDownList ID="cyce" runat="server" Font-Bold="True" style="font-size: medium">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="new value:" Font-Bold="True" Font-Size="Large" style="font-size: x-large"></asp:Label>
        &nbsp;
        <asp:TextBox ID="newVal" runat="server"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="changeButt" runat="server" OnClick="changeButt_Click" Text="Change the value" BorderColor="#003366" BorderWidth="1px" Font-Bold="True" ForeColor="#003366" style="font-size: medium" />
        <br />
        <br />
        <asp:Label ID="error" runat="server" Font-Bold="True" ForeColor="#A60000" style="font-size: x-large"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label3" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label2" runat="server"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label4" runat="server"></asp:Label>
        <br />
    
    </div>
    </form>
</body>
</html>
