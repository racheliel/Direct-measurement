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
             font-family: David;
             font-size: 100px;
             display: block;
             margin-left: auto;
             margin-right: auto;
        }
        .auto-style3 {
            font-size: x-large;
            color: #000099;
        }
        .auto-style4 {
            color: #666666;
            font-size: large;
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
    
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="To change all the line click here" BorderColor="#003366" BorderWidth="1px" Font-Bold="True" ForeColor="#003366" style="font-size: medium" />
        <br />
        <br />
        <br />
        <span class="auto-style3">Choose the location of the value in the row</span>&nbsp; <asp:DropDownList ID="cyce" runat="server" Font-Bold="True" style="font-size: medium" OnSelectedIndexChanged="cyce_SelectedIndexChanged">
        </asp:DropDownList>
        <br />
        <br />
        <asp:Label ID="Label1" runat="server" Text="new value:" Font-Bold="True" Font-Size="Large" style="font-size: x-large" ForeColor="#000099"></asp:Label>
        &nbsp;
        <asp:TextBox ID="newVal" runat="server"></asp:TextBox>
        <br />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" Height="50px" style="font-size: large; text-align: center" Width="419px">
        </asp:GridView>
        <br class="auto-style4" />
        <br class="auto-style4" />
        <span class="auto-style4">It is not possible to change a value that is modified as zero to a different value and on the contrary to change a numeric value to zero (it will change the number of cycles that had been pre-set).</span><br />
        <br />
        <asp:Button ID="changeButt" runat="server" OnClick="changeButt_Click" Text="Change the value" BorderColor="#003366" BorderWidth="1px" Font-Bold="True" ForeColor="#003366" style="font-size: medium" />
        <br />
        <br />
        <asp:Label ID="error" runat="server" Font-Bold="True" ForeColor="#A60000" style="font-size: x-large"></asp:Label>
        <br />
        <br />
        <br />
        <br />
        
        <br />
    
    </div>
    </form>
</body>
</html>
