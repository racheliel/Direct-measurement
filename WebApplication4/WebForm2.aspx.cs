using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication4
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        int cycel = 0;
        int ele = 0;
        int row = -1;
        LinkedList<valInRow> colarry;
        LinkedList<String> str;
        valInRow col;
        string cycText;
        protected void Page_Load(object sender, EventArgs e)
        {
            cycText = (string)(Session["cyc"]);
            cycel = Convert.ToInt32(cycText);
            row = (int)(Session["row"]);
            colarry = (LinkedList<valInRow>)(Session["colarry"]);

            foreach (valInRow i in colarry)
            {
                if (i.Row == row)
                {
                    str = i.Val;
                    foreach(String j in i.Val)
                    {
                        Label2.Text += j + " ";
                    }

                }
            }

 
            for (int i = 0; i < cycel + 3; i++)
            {
                cyce.Items.Add("" + (i + 1));
            }
            

            col = new valInRow(row, str);
        }

        protected void changeButt_Click(object sender, EventArgs e)
        {
            try 
            {
                double val = Convert.ToDouble(newVal.Text);
                change(val);
            }
            catch
            {
                  if (newVal.Text.Equals(""))
                      error.Text = "You can not insert null value";
                  else
                      error.Text = "You can not insert wrong value";
            }
            

        }

        public void change(double val)
        {

            string temp = "" + val;
                LinkedList<String> newStr = editData(row, str, Convert.ToInt32(cyce.Text), temp);

                valInRow newcol = new valInRow(row, newStr);
                if (col.Val.Count == 0)
                    error.Text = "error";
                else
                {
                    LinkedList<valInRow> colArryNew = new LinkedList<valInRow>();
                    foreach (valInRow i in colarry)
                    {
                        if (i.Row == row)
                        {

                            colArryNew.AddLast(newcol);

                        }
                        else
                        {
                            colArryNew.AddLast(i);
                        }

                    }
                    Session.Add("cyc", cycText);
                    Session.Add("colarry", colArryNew);
                    Session.Add("row", row);

                    Response.Redirect("~/WebForm1.aspx");
                }
            

        }
        public LinkedList<string> editData(int row, LinkedList<string> str, int i, string newVal)
        {

            int count = 1;
            LinkedList<string> newStr = new LinkedList<string>();
            foreach (string j in str)
            {
                if ( count == i)
                {
                    newStr.AddLast(newVal);
                    count++;
                }
                else
                {
                    newStr.AddLast(j);
                    count++;
                }

            }

            return newStr;

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            LinkedList<String> str1 = new LinkedList<String>();
            Session.Add("cyc", cycText);
            Session.Add("colarry", colarry);
            Session.Add("row", row);
            Session.Add("str", str1);
            Session.Add("flag", 1);
            Response.Redirect("~/WebForm5.aspx");
        }
    }
}