<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm5.aspx.cs" Inherits="WebApplication4.WebForm5" %>

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
        }
        #MainTitle{
              font-family: AR BONNIE;
            font-size: 100px;
             display: block;
             margin-left: auto;
             margin-right: auto;
        }
        .auto-style1 {
            font-size: x-large;
            font-weight: bold;
        }
        .auto-style2 {
            font-size: x-large;
        }
    </style>
</head>
<body style="font-family: David">
    <form id="form1" runat="server">
    <div >
    
        <asp:Label ID="MainTitle" runat="server" Font-Bold="True" ForeColor="#003366" Text="Direct Measurement" style="text-align: center"></asp:Label>
        <br />
        <br />
        <br />
        <span class="auto-style1">Insert one value at a time.</span>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp;<asp:Label ID="Label1" runat="server" ForeColor="#336699" Font-Bold="True" Font-Size="Large"></asp:Label>
        <br />
        <br />
        &nbsp;<asp:Label ID="Label2" runat="server" Font-Bold="True" Font-Size="Large" style="font-size: x-large"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;
        <br />
&nbsp;<asp:TextBox ID="val" runat="server" Width="52px"></asp:TextBox>
        <asp:Label ID="Label3" runat="server" Text=":" Visible="False" Font-Bold="True" Font-Size="XX-Large"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server" Visible="False" Width="45px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="ok" runat="server" OnClick="ok_Click" Text="OK" BorderColor="#003366" BorderWidth="1px" Font-Bold="True" ForeColor="#003366" style="font-size: medium" />
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="err" runat="server" Font-Bold="True" ForeColor="#A60000" style="font-size: large"></asp:Label>
    
        <br />
    
        <br />
    
        <span class="auto-style2"><strong>The values entered into the table: </strong></span>&nbsp;<asp:Label ID="error" runat="server" Font-Bold="True" ForeColor="#A60000" style="font-size: x-large"></asp:Label>
        <br />
        <br />
    
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="ADD" BorderColor="#003366" BorderWidth="1px" Font-Bold="True" ForeColor="#003366" style="font-size: medium" />
    
    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    
    </div>
    </form>
</body>
</html>
