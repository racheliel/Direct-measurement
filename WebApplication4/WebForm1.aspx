<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication4.WebForm1" %>

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
        #SecondaryTitle{
            font-family: AR BONNIE;
            display: block; 
            margin-left: auto;
            margin-right: auto;
            text-align: center;
            font-size: 30px;
        }
        #Label4{
            font-family: AR BONNIE;
            display: block; 
            margin-left: auto;
            margin-right: auto;
            text-align: center;
            font-size: 50px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div style="font-family: David" title="Direct Measurement">
    
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="MainTitle" runat="server" Font-Bold="True"  ForeColor="#003366" Text="Direct Measurement" style="text-align: center"></asp:Label>
        <asp:Label ID="Label4" runat="server" Text="Welcome! " Font-Bold="True" ForeColor="#003366"></asp:Label>
        <br />
        <asp:Label ID="SecondaryTitle" runat="server" Font-Bold="True" ForeColor="#003366" Text="This site will make direct measurements. What you need to do is fill in the required data and the system will calculate for you the time standards."></asp:Label>
        <br />
        <br />
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="cycel:" Font-Bold="True" Font-Size="Large" Font-Underline="True" style="font-size: x-large"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="cycBox" runat="server"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="OK" BackColor="#F0F0F0" BorderWidth="1px" Font-Bold="True" ForeColor="#003366" style="font-size: medium" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Clear Data" BorderWidth="1px" Font-Bold="True" ForeColor="#003366" BackColor="#F0F0F0" style="font-size: medium" Visible="False" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button6" runat="server" OnClick="Button6_Click" Text="add data" Visible="False" BackColor="#F0F0F0" BorderWidth="1px" Font-Bold="True" Font-Size="Medium" ForeColor="#003366" />
        <br />
        <br />
        <asp:Label ID="error" runat="server" Font-Bold="True" ForeColor="#A60000" style="font-size: x-large"></asp:Label>
        <br />
        <br />
        <br />
        <br />
        <asp:GridView ID="table" runat="server" OnRowCommand="GridView1_RowCommand" BackColor="White" BorderColor="Black" BorderStyle="Double" Font-Bold="True" Font-Size="Large" ForeColor="Black" Height="35px" HorizontalAlign="Justify" style="position: relative; top: 0px; left: 0px; width: 550px" display="table">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:ButtonField CommandName="edit" HeaderText="edit" Text="edit" />
            </Columns>

            <FooterStyle BackColor="White" BorderColor="Red" />
            <HeaderStyle BackColor="#F0F0F0" />
            <PagerStyle BackColor="White" />
            <RowStyle BackColor="White" HorizontalAlign="Center" />

        </asp:GridView>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="add element" Visible="False" BorderWidth="1px" Font-Bold="True" ForeColor="#003366" BorderColor="#003366" style="font-size: medium" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="end" Visible="False" BorderWidth="1px" Font-Bold="True" ForeColor="#003366" BorderColor="#003366" style="font-size: medium" />
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Insert level of reliability (k):" Visible="False" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="Large" Font-Strikeout="False" style="font-size: x-large"></asp:Label>
&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox1" runat="server" Visible="False"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <asp:Label ID="Label7" runat="server" Text="Insert inaccuracy permitted (r):" Visible="False" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="Large" Font-Strikeout="False" style="font-size: x-large"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox2" runat="server" Visible="False"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="OK" Visible="False" BorderWidth="1px" Font-Bold="True" ForeColor="#003366" BorderColor="#003366" style="font-size: medium" />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <br />
        <asp:Label ID="Label6" runat="server" Font-Bold="True" Font-Size="X-Large"></asp:Label>
        <asp:GridView ID="table2" runat="server" Visible="False" BorderColor="Black" BorderStyle="Double" Font-Bold="True" Font-Size="Large" HorizontalAlign="Center" style="position: relative; top: 0px; left: 0px; width: 650px" display="table">
            <FooterStyle BackColor="White" BorderColor="Red" />
            <HeaderStyle BackColor="#F0F0F0" />
            <PagerStyle BackColor="White" />
            <RowStyle BackColor="White" HorizontalAlign="Center" />
        </asp:GridView>
        <br />
&nbsp;<asp:Label ID="Label5" runat="server" Text="General Standard Time (Z):" Visible="False" Font-Bold="True" Font-Size="X-Large"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label12" runat="server" Visible="False" Font-Bold="True" Font-Overline="False" Font-Size="X-Large" ForeColor="#990033"></asp:Label>
        <br />
        <br />
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button7" runat="server" OnClick="Button7_Click" Text="more table" Visible="False" BorderWidth="1px" Font-Bold="True" Font-Size="Medium" ForeColor="#003366" />
        <br />
        <br />
        <asp:Label ID="Label10" runat="server" Text="The number of cycles required" Visible="False" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="Large" Font-Strikeout="False" style="font-size: x-large"></asp:Label>
        &nbsp;&nbsp;
        <asp:TextBox ID="TextBox3" runat="server" Visible="False" Width="41px"></asp:TextBox>
        &nbsp;&nbsp;
        <asp:Label ID="Label14" runat="server" Text="%" Visible="False" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="Large" Font-Strikeout="False" style="font-size: x-large"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button10" runat="server" OnClick="Button8_Click" Text="OK" Visible="False" BorderWidth="1px" Font-Bold="True" Font-Size="Medium" ForeColor="#003366" />
        <br />
        <br />
        <br />
        <asp:GridView ID="table3" runat="server" Visible="False" BorderColor="Black" BorderStyle="Double" Font-Bold="True" Font-Size="Large" HorizontalAlign="Center" style="position: relative; top: 0px; left: 0px; width: 650px" display="table" AllowSorting="true">           
            <FooterStyle BackColor="White" BorderColor="Red" />
            <HeaderStyle BackColor="#F0F0F0" ForeColor="Black" Font-Underline="False" />
            <PagerStyle BackColor="White" />
            <RowStyle BackColor="White" HorizontalAlign="Center" />
        </asp:GridView>
        <br />
        <asp:Label ID="Label16" runat="server" Text="There is a need in" Visible="False" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="Large" Font-Strikeout="False" style="font-size: x-large"></asp:Label>
        &nbsp;
        <asp:Label ID="Label15" runat="server" Visible="False" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="Large" Font-Strikeout="False" style="font-size: x-large"></asp:Label>
        <br />
        <asp:GridView ID="table4" runat="server" Visible="False" BorderColor="Black" BorderStyle="Double" Font-Bold="True" Font-Size="Large" HorizontalAlign="Center" style="position: relative; top: 0px; left: 1px; width: 650px" display="table">
            <FooterStyle BackColor="White" BorderColor="Red" />
            <HeaderStyle BackColor="#F0F0F0" Font-Overline="False" />
            <PagerStyle BackColor="White" />
            <RowStyle BackColor="White" HorizontalAlign="Center" />
        </asp:GridView>
        <br />
        <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Achieved level measurement inaccuracy:" Visible="False"></asp:Label>
        &nbsp;<br />
        <br />
        <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Output per hour:" Visible="False"></asp:Label>
        <br />
        <asp:Label ID="Label13" runat="server" Text="Insert efficiency (E):" Visible="False" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="Large" Font-Strikeout="False" style="font-size: x-large"></asp:Label>
        <asp:TextBox ID="TextBox4" runat="server" Visible="False"></asp:TextBox>
        <asp:Button ID="Button11" runat="server" OnClick="Button11_Click" Text="OK" Visible="False" BorderWidth="1px" Font-Bold="True" Font-Size="Medium" ForeColor="#003366" />
        <br />
        <br />
        <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Output per hour efficiency " Visible="False"></asp:Label>
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
