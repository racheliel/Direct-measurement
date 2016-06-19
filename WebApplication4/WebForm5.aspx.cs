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
          error.Text = "";
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
                        Label2.Text = "insert rate of action (%)";
                        finish.Visible = false;
                    }
                    if (str.Count == cycel + 1)
                    {
                        Label2.Text = "insert frequency";
                        Label3.Visible = true;
                        TextBox1.Visible = true;
                        finish.Visible = false;
                    }
                    if (str.Count == cycel + 2)
                    {
                        Label8.Visible = true;
                        finish.Visible = false;
                        Label2.Text = "insert PFD allowance 100 + ";
                        Label8.Text = "%";
                    }
                    if (str.Count == cycel + 3)
                    {
                        Label2.Text = "You finished to insert the required values";
                        val.Visible = false;
                        ok.Visible = false;
                        finish.Visible = false;
                    }
                }
                Label1.Text = "*"+ ((cycel + 3) - str.Count()) + " more values left to insert";
            }
            row = (int)(Session["row"]);
            colarry = (LinkedList<valInRow>)(Session["colarry"]);
        }

        protected void ok_Click(object sender, EventArgs e)
        {
            if (val.Text.Contains('-') || TextBox1.Text.Contains("-")) //Check if the number is negative
                err.Text = "You can not insert a negative value";
            else {
                try
                {
                    if(str.Count == cycel + 2 && val.Text.Equals("0"))
                    {
                        double temp = Convert.ToDouble(val.Text);
                        addToStr(temp);
                    }
                    else if (val.Text.Equals("0") || TextBox1.Text.Equals("0"))
                    {
                        err.Text = "You can not insert zero";
                        val.Text = "";
                        TextBox1.Text = "";
                    }
                    else
                    {
                        double temp = Convert.ToDouble(val.Text);
                        addToStr(temp);
                    }
                }
                catch
                {
                    if (val.Text.Equals(""))
                        err.Text = "You can not insert null value";
                    else
                        err.Text = "You can not insert wrong value";
                    val.Text = "";
                    TextBox1.Text = "";
                }
            }
        }

        public void addToStr(double k)
        {
            double t1 = 0, t2 = 0, count = 0;
            LinkedList<char> s = new LinkedList<char>();
           
            if (str.Count < cycel + 3)
            {
                string sv = ""+k;
                if (str.Count == cycel + 1)
                {
                    try
                    {
                        t1 = Convert.ToDouble(sv);
                        t2 = Convert.ToDouble(TextBox1.Text);
                        count = (t1 / t2);
                        sv = "" + Math.Round(count, 2);//"" + count;
                    }
                    catch
                    {
                        if (!val.Text.All(char.IsDigit))
                            err.Text = "You can not insert a negative value";
                        else
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

        protected void finish_Click(object sender, EventArgs e)
        {
            int size = str.Count;
            if (str.Count == 0)
                err.Text = "You must enter at least one value";
            else {
                for (int i = 1; i <= (cycel - size); i++)
                {
                    str.AddLast("0");
                }
                Session.Add("str", str);
                Response.Redirect("~/WebForm5.aspx");
            }

        }


    }
}