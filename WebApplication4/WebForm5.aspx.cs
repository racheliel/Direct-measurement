using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        int cycel = 0;
        int ele = 0;
        int row = -1;
        LinkedList<valInRow> colarry;
        LinkedList<String> str;
        valInRow col ;
        string cycTe;
        int flag = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
          flag = (int)(Session["flag"]);

          colarry = new LinkedList<valInRow>();
          cycTe = (string)(Session["cyc"]);
          cycel = Convert.ToInt32(cycTe);

            str = (LinkedList<String>)(Session["str"]);
            if (str == null)
                str = new LinkedList<String>();
            else
            {
                foreach (string i in str)
                {
                    error.Text += " " + i;

                    if (str.Count == cycel)
                    {
                        Label2.Text = "insert %R";
                    }
                    if (str.Count == cycel + 1)
                    {
                        Label2.Text = "insert F";
                        Label3.Visible = true;
                        TextBox1.Visible = true;
                    }
                    if (str.Count == cycel + 2)
                    {
                        Label2.Text = "insert %(a+b)";
                    }
                    if (str.Count == cycel + 3)
                    {
                        
                        Label2.Text = "you finished to insert  the number of elements by the number of cycles";
                        val.Visible = false;
                        ok.Visible = false;
                    }
                }
                Label1.Text = "*Left more  " + ((cycel + 3) - str.Count()) + " values to Insert ";
         
            }
            row = (int)(Session["row"]);
            colarry = (LinkedList<valInRow>)(Session["colarry"]);
        }


        protected void ok_Click(object sender, EventArgs e)
        {
            double t1 = 0, t2 = 0 ,count=0;
            LinkedList<char> s =new LinkedList<char>();
            if(val.Text == "")
                err.Text = "You can not insert null value";
            else if (str.Count < cycel + 3)
            {
                string sv = val.Text;
                if (str.Count == cycel + 1)
                {
                    try
                    {
                        t1 = Convert.ToDouble(sv);
                        t2 = Convert.ToDouble(TextBox1.Text);
                        count = (t1 / t2);
                        sv = ""+Math.Round(count, 2);//"" + count;
                    }
                    catch
                    {
                        err.Text = "You can not insert wrong value";
                    }
                }
                str.AddLast(sv);
                Session.Add("str", str);
                Response.Redirect("~/WebForm5.aspx");
            }
            else
            {
                error.Text = "";
                add();
            }

        }

        private void add()
        {

            if (str.Count < cycel + 3)
            {
                err.Text += "Please add " + (cycel + 3) + " Values";
                error.Text = "";
                Session.Add("cyc", cycTe);
                Session.Add("colarry", colarry);
                Session.Add("row", row);
                Session.Add("str", str);
                Session.Add("flag", 0);
                Response.Redirect("~/WebForm5.aspx");
            }
            else
            {
                col = new valInRow(row, str);
                if (flag == 1)
                {
                    foreach (valInRow i in colarry)
                    {
                        err.Text = "i " + i.Row + " ro " + row;
                        if (i.Row == row)
                        {
                            i.Val = str;
                        }

                    }
                }
                if (flag == 0)
                    colarry.AddLast(col);
                Session.Add("cyc", cycTe);
                Session.Add("colarry", colarry);
                Session.Add("row", row);
                Response.Redirect("~/WebForm1.aspx");
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            add();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

        }

    }
}