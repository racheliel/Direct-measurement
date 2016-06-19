using System;
using System.Collections.Generic;
using System.Data;
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
        int location = 1;
        Boolean flag = false;
        Boolean flag2 = false;
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

            DataTable dt = new DataTable();
            dt.Columns.Add("Element", typeof(Int16));
            int count = 1;
            for (int i = 0; i < cycel; i++)
            {
                dt.Columns.Add(new DataColumn("" + count, typeof(string)));
                count++;
            }
            dt.Columns.Add("Rate (%)", typeof(string));
            dt.Columns.Add("Frequency", typeof(string));
            dt.Columns.Add("PFD allowance (%)", typeof(string));

            foreach (valInRow i in colarry)
            {
                if (i.Row == row)
                {
                    str = i.Val;
                }
            }

            if (colarry.Count != 0)
            {
                foreach (valInRow i in colarry)
                {
                    DataRow row1 = dt.NewRow();
                    row1["Element"] = i.Row + 1;
                    count = 1;
                    if (i.Row == row)
                    {
                        foreach (string j in i.Val)
                        {
                            if (count == cycel + 1)
                            {
                                row1["Rate (%)"] = j;
                            }
                            if (count == cycel + 2)
                            {
                                row1["Frequency"] = j;
                            }
                            if (count == cycel + 3)
                            {
                                row1["PFD allowance (%)"] = j;
                                break;
                            }
                            row1[count] = j;
                            count++;
                        }
                        dt.Rows.Add(row1);
                    }
                }
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }

                for (int i = 0; i < cycel + 3; i++)
                {
                    cyce.Items.Add("" + (i + 1));
                    location++;
             }
            
            col = new valInRow(row, str);
        }

        protected void changeButt_Click(object sender, EventArgs e)
        {
            string locationOfRate = Convert.ToString(cycel-3);
            string locationOfFrequency = Convert.ToString(cycel-2);
            
            if (!newVal.Text.Contains('-')) {
                try
                {
                    if((newVal.Text.Equals("0") && flag2))
                    {
                        double val = Convert.ToDouble(newVal.Text);
                        change(val);
                    }
                    else if ((newVal.Text.Equals("0") && flag) || newVal.Text.Equals("0"))
                    {
                        error.Text = "You can not insert zero";
                        newVal.Text = "";
                    }
                    else
                    {
                        double val = Convert.ToDouble(newVal.Text);
                        change(val);
                    }
                }
                catch
                {
                    if (newVal.Text.Equals(""))
                        error.Text = "You can not insert null value";
                    else
                        error.Text = "You can not insert wrong value";
                }
            }
            else
                error.Text = "You can not insert a negative value";

            cyce.Items.Clear();
            for (int i = 0; i < cycel + 3; i++)
            {
                cyce.Items.Add("" + (i + 1));
                location++;
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

        protected void cyce_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cyce.SelectedIndex == location - 3 || cyce.SelectedIndex == location - 4)
                flag = true;
            if (cyce.SelectedIndex == location - 2)
                flag2 = true;
        }
    }
}