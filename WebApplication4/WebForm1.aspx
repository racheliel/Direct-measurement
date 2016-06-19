<%@ Page Language="C#" MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication4.WebForm1" %>

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
            font-family: David;
            font-size: 100px;
            display: block; 
            margin-left: auto;
            margin-right: auto;
        }
        #SecondaryTitle{
            font-family: David;
            display: block; 
            margin-left: auto;
            margin-right: auto;
            text-align: center;
            font-size: 30px;
        }
        #Label4{
            font-family: David;
            display: block; 
            margin-left: auto;
            margin-right: auto;
            text-align: center;
            font-size: 50px;
        }
        .auto-style1 {
            font-size: x-large;
            color: #000066;
        }
    </style>
    <script>
      (function(i,s,o,g,r,a,m){i['GoogleAnalyticsObject']=r;i[r]=i[r]||function(){
      (i[r].q=i[r].q||[]).push(arguments)},i[r].l=1*new Date();a=s.createElement(o),
      m=s.getElementsByTagName(o)[0];a.async=1;a.src=g;m.parentNode.insertBefore(a,m)
      })(window,document,'script','https://www.google-analytics.com/analytics.js','ga');

      ga('create', 'UA-78695730-1', 'auto');
      ga('send', 'pageview');
    </script>
</head>
<body>
    <form id="form1" runat="server" defaultbutton="Button4">
    <div style="font-family: David" title="Direct Measurement">
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Label ID="MainTitle" runat="server" Font-Bold="True"  ForeColor="#003366" Text="Direct Measurement" style="text-align: center"></asp:Label>
        <asp:Label ID="Label4" runat="server" Text="Welcome! " Font-Bold="True" ForeColor="#003366"></asp:Label>
        <br />
        <asp:Label ID="SecondaryTitle" runat="server" Font-Bold="True" ForeColor="#003366" Text="This site will help you to make direct measurements.&lt;br&gt; What you need to do is to fill the data in the required fields and the system will perform all the calculations"></asp:Label>
        <br />
        <br />
        <br />
        <br />
        <div>

       <br />

       </div>

        <asp:Label ID="Label2" runat="server" Text="Please enter the maximum number of cycles:" Font-Bold="True" Font-Size="Large" Font-Underline="False" style="font-size: x-large" ForeColor="#000099"></asp:Label>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="cycBox" runat="server"></asp:TextBox>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="OK" BackColor="#F0F0F0" MaintainScrollPositionOnPostback="true" BorderWidth="1px" Font-Bold="True" ForeColor="#003366" style="font-size: medium" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button5" runat="server" OnClick="Button5_Click" Text="Clear Data" BorderWidth="1px" Font-Bold="True" ForeColor="#003366" BackColor="#F0F0F0" style="font-size: medium" Visible="False" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        <asp:Label ID="error" runat="server" Font-Bold="True" ForeColor="#A60000" style="font-size: x-large"></asp:Label>
        <br />
        <br />
        <br />
        <br />
        <asp:GridView ID="table" runat="server" OnRowCommand="GridView1_RowCommand" BackColor="White" BorderColor="Black" BorderStyle="Double" Font-Bold="True" Font-Size="Large" ForeColor="Black" HorizontalAlign="Justify" style="position: relative; top: 0px; left: 0px; width: 730px; height: 76px;" display="table">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:ButtonField CommandName="edit" HeaderText="edit" Text="edit" />
                <asp:ButtonField CommandName="delete" HeaderText="delete" Text="delete" />
            </Columns>

            <FooterStyle BackColor="White" BorderColor="Red" />
            <HeaderStyle BackColor="#F0F0F0" />
            <PagerStyle BackColor="White" />
            <RowStyle BackColor="White" HorizontalAlign="Center" />

        </asp:GridView>
        <br />
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="add element" Visible="False" BorderWidth="1px" MaintainScrollPositionOnPostback="true" Font-Bold="True" ForeColor="#003366" BorderColor="#003366" style="font-size: medium" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="end" Visible="False" BorderWidth="1px" Font-Bold="True" MaintainScrollPositionOnPostback="true" ForeColor="#003366" BorderColor="#003366" style="font-size: medium" />
        <br />
        <br />
        <br />
        <br />
        <br />
        <asp:Label ID="Label3" runat="server" Text="To calculate standard time, insert level of reliability, according to the value in the normal distribution :" Visible="False" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="Large" Font-Strikeout="False" style="font-size: x-large" ForeColor="#000099"></asp:Label>
&nbsp;&nbsp;&nbsp;<br />
        <br />
&nbsp;<br />
        <asp:TextBox ID="TextBox1" runat="server" Visible="False" Height="26px" Width="134px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:Button ID="Button4" runat="server" OnClick="Button4_Click" Text="OK" Visible="False" BorderWidth="1px" MaintainScrollPositionOnPostback="true" Font-Bold="True" ForeColor="#003366" BorderColor="#003366" style="font-size: medium" />
        &nbsp;&nbsp;
        <br />
        <br />
        <asp:Label ID="error0" runat="server" Font-Bold="True" ForeColor="#A60000" style="font-size: x-large"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<br />
        <br />
        <asp:GridView ID="table2" runat="server" Visible="False" BorderColor="Black" BorderStyle="Double" Font-Bold="True" Font-Size="Large" HorizontalAlign="Center" style="position: relative; top: 0px; left: 0px; width: 650px" display="table">
            <FooterStyle BackColor="White" BorderColor="Red" />
            <HeaderStyle BackColor="#F0F0F0" />
            <PagerStyle BackColor="White" />
            <RowStyle BackColor="White" HorizontalAlign="Center" />
        </asp:GridView>
        <br />
        <br />
&nbsp;<asp:Label ID="Label5" runat="server" Text="General Standard Time:" Visible="False" Font-Bold="True" Font-Size="X-Large"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label12" runat="server" Visible="False" Font-Bold="True" Font-Overline="False" Font-Size="X-Large" ForeColor="#990033"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Label ID="Label20" runat="server" ForeColor="#000099" style="font-size: x-large; font-weight: 700" Text="To calculate minimum number of observations required and inaccuracy obtained sample reliability level, please fill the fields:" Visible="False"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label10" runat="server" Text=" Insert the % of the cycle-time that needs to meet the level of reliability defined previously: " Visible="False" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="Large" Font-Strikeout="False" style="font-size: x-large" ForeColor="#000099"></asp:Label>
        &nbsp;&nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox3" runat="server" Visible="False" Width="74px" Height="27px"></asp:TextBox>
        &nbsp;&nbsp;
        <asp:Label ID="Label14" runat="server" Text="%" Visible="False" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="Large" Font-Strikeout="False" style="font-size: x-large" ForeColor="#000099"></asp:Label>
        &nbsp; &nbsp;&nbsp;<br />
        <asp:Label ID="Label7" runat="server" Text="Insert inaccuracy permitted:" Visible="False" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="Large" Font-Strikeout="False" style="font-size: x-large" ForeColor="#000099"></asp:Label>
        <asp:TextBox ID="TextBox2" runat="server" Visible="False" AccessKey="&amp;" Height="27px" Width="70px"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;<asp:Label ID="Label21" runat="server" Text="%" Visible="False" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="Large" Font-Strikeout="False" style="font-size: x-large" ForeColor="#000099"></asp:Label>
        &nbsp;&nbsp;
        <asp:Button ID="Button10" runat="server" OnClick="Button8_Click" Text="OK" Visible="False" MaintainScrollPositionOnPostback="true" BorderWidth="1px" Font-Bold="True" Font-Size="Medium" ForeColor="#003366" />
        <br />
        <br />
        <asp:Label ID="error1" runat="server" Font-Bold="True" ForeColor="#A60000" style="font-size: x-large"></asp:Label>
        <br />
        <br />
        <asp:GridView ID="table3" runat="server" Visible="False" BorderColor="Black" BorderStyle="Double" Font-Bold="True" Font-Size="Large" HorizontalAlign="Center" style="position: relative; top: 0px; left: 0px; width: 650px" display="table">
            <FooterStyle BackColor="White" BorderColor="Red" />
            <HeaderStyle BackColor="#F0F0F0" />
            <PagerStyle BackColor="White" />
            <RowStyle BackColor="White" HorizontalAlign="Center" />
        </asp:GridView>
        
        <br />
        <br />
        <asp:Label ID="Label16" runat="server" Text="It is necessary to make at least" Visible="False" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="Large" Font-Strikeout="False" style="font-size: x-large"></asp:Label>
        &nbsp;&nbsp;
        <asp:Label ID="Label15" runat="server" Visible="False" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="Large" Font-Strikeout="False" style="font-size: x-large" ForeColor="#993333"></asp:Label>
        <br />
        <br />
        <br />
        <asp:GridView ID="table4" runat="server" Visible="False" BorderColor="Black" BorderStyle="Double" Font-Bold="True" Font-Size="Large" HorizontalAlign="Center" style="position: relative; top: 0px; left: 1px; width: 650px" display="table">
            <FooterStyle BackColor="White" BorderColor="Red" />
            <HeaderStyle BackColor="#F0F0F0" Font-Overline="False" />
            <PagerStyle BackColor="White" />
            <RowStyle BackColor="White" HorizontalAlign="Center" />
        </asp:GridView>
        <br />
        <br />
        <asp:Label ID="Label8" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Achieved level measurement inaccuracy:" Visible="False"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        &nbsp;<asp:Label ID="Label19" runat="server" Visible="False" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="Large" Font-Strikeout="False" style="font-size: x-large" ForeColor="#993333"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Label ID="Label9" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Quantity per hour:" Visible="False"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label17" runat="server" Visible="False" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="Large" Font-Strikeout="False" style="font-size: x-large" ForeColor="#993333"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Label ID="Label13" runat="server" Text="Calculation of productivity per hour  by a certain efficiency, please enter the required efficiency:" Visible="False" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="Large" Font-Strikeout="False" style="font-size: x-large" ForeColor="#000099"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="TextBox4" runat="server" Visible="False" Height="26px" Width="91px"></asp:TextBox>
        &nbsp;&nbsp;<asp:Label ID="Label23" runat="server" Font-Bold="True" ForeColor="#000099" style="font-size: x-large" Text="%" Visible="False"></asp:Label>
        &nbsp;<span class="auto-style1">&nbsp;</span>
        <asp:Button ID="Button11" runat="server" OnClick="Button11_Click" Text="OK" Visible="False" MaintainScrollPositionOnPostback="true" BorderWidth="1px" Font-Bold="True" Font-Size="Medium" ForeColor="#003366" />
        <br />
        <br />
        <asp:Label ID="error2" runat="server" Font-Bold="True" ForeColor="#A60000" style="font-size: x-large"></asp:Label>
        <br />
        <br />
        <asp:Label ID="Label11" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Quantity per hour efficiency:" Visible="False"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label18" runat="server" Visible="False" Font-Bold="True" Font-Italic="False" Font-Overline="False" Font-Size="Large" Font-Strikeout="False" style="font-size: x-large" ForeColor="#993333"></asp:Label>
        <br />
        <br />
        <br />
        <asp:Label ID="Label22" runat="server" Font-Bold="True" Font-Size="X-Large" Text="The process is complete, you're done!" Visible="False" ForeColor="Red" style="text-align: center"></asp:Label>
        <br />
        <br />
        <br />
    
    </div>
    </form>
</body>
</html>
