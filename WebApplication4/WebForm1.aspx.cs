using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace WebApplication4
{
    public partial class WebForm1 : System.Web.UI.Page
    {

        int cycel = 0 ;
        int rowClick = -1,row=0;
        double number_of_cycles_required = 0;
        double sumZ = 0, K=0,sumRW=0;

        LinkedList<valInRow> colarry;
        LinkedList<valInRow> colarry3;
        LinkedList<valInRow> colarry4;
        double[] tempstr;
        int[] tempStr2;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (sumZ == 0 && Label12.Text!="")
            {
                try
                {
                    sumZ = Convert.ToDouble(Label12.Text);
                }
                catch { error.Text = "Errror!"; }
            }
            colarry3 = new LinkedList<valInRow>();
            colarry4 = new LinkedList<valInRow>();



            if ((LinkedList<valInRow>)(Session["colarry"]) == null)
            {
                colarry = new LinkedList<valInRow>();

            }
            else
            {
                colarry = (LinkedList<valInRow>)(Session["colarry"]);
                string s = (string)(Session["cyc"]);
                cycel = Convert.ToInt32(s);

                rowClick = (int)(Session["row"]);
                Button2.Visible = true;
                Button5.Visible = true;
                if (cycel != 0 )
                {
                    cycBox.Text = "" + cycel;
                    Button1.Visible = false;
                    if (rowClick != -1)
                        drowTable(cycel);
                }
                else
                {
                    error.Text = "Insert number of cycles";
                }
            }

        }

        public void drowTable(int cyc)
        {
                try
                {
                   DataTable dt = new DataTable();
                   int count = 1;
                   dt.Columns.Add("Element", typeof(Int16));

                    for (int i = 0 ; i < cyc ; i++)
                    {
                        dt.Columns.Add(new DataColumn("" + count, typeof(string)));
                        count++;
                    }

                    dt.Columns.Add("Rate (%)", typeof(string));
                    dt.Columns.Add("Frequency", typeof(string));
                    dt.Columns.Add("Extras rest (%)", typeof(string));
                    
                    
                    if (colarry.Count != 0)
                    {
                        Button3.Visible = true;
                        foreach (valInRow i in colarry)
                        {
                            DataRow row1 = dt.NewRow();
                            row1["Element"] = i.Row+1;
                            count = 1;
                           
                            foreach (string j in i.Val)
                            { 
                                if(count == cyc + 1)
                                {
                                    row1["Rate (%)"] = j;
                                }
                                if(count == cyc + 2)
                                {
                                    row1["Frequency"] = j ;
                                }
                                if(count == cyc + 3)
                                {
                                    row1["Extras rest (%)"] = j ;
                                    break;
                                }

                                row1[count] = j;
                                count++;
                                
                            }
                            dt.Rows.Add(row1);
                        }

                    }
                    else {
                        error.Text = "Please add elements";
                    }

                    table.DataSource = dt;                  
                    table.DataBind();
                }
                catch { error.Text = "Error in table"; }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName.CompareTo("edit") == 0)
            {
                LinkedList<String> str = new LinkedList<String>();
                int row = int.Parse(e.CommandArgument.ToString());
                rowClick = row;
                Session.Add("cyc", cycBox.Text);
                Session.Add("row", row);            
                Session.Add("str", str);
                Session.Add("colarry", colarry);
                Response.Redirect("~/WebForm2.aspx");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                int  cyc = Convert.ToInt32(cycBox.Text);
                if (cycel==0)
                     cycel = cyc;
                Button2.Visible = true;
                Button5.Visible = true;
                LinkedList<String> str = new LinkedList<String>();
                rowClick++;
                Session.Add("cyc", cycBox.Text);
                Session.Add("row", rowClick);
                Session.Add("colarry", colarry);
                Session.Add("str", str);
                Session.Add("flag", 0);
                Response.Redirect("~/WebForm5.aspx");
               // drowTable(cyc);
            }
            catch
            {
                if ( cycBox.Text.Equals(""))
                {
                    error.Text = "Please fill the field";
                }
                else
                {
                    error.Text = "Please check if the field value are correct";
                }
             }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            LinkedList<String> str = new LinkedList<String>();
            rowClick ++;
            Session.Add("cyc", cycBox.Text);
            Session.Add("row", rowClick);
            Session.Add("colarry", colarry);
            Session.Add("str", str);
            Session.Add("flag", 0);
            Response.Redirect("~/WebForm5.aspx");
        }



        private void drowTable2( LinkedList<valInRow> colarry2) //Display a second table
        {
            int cyc = cycel;
            DataTable dt = new DataTable();
            int count = 1;
            sumZ = 0;
            dt.Columns.Add("Element", typeof(Int16));
            dt.Columns.Add("Rate (%)", typeof(string));
            dt.Columns.Add("Frequency", typeof(string));
            dt.Columns.Add("Extras rest (%)", typeof(string));
            dt.Columns.Add("Average", typeof(string));
            dt.Columns.Add("Standard deviation", typeof(string)); //σ
            dt.Columns.Add("Upper control limit", typeof(string));
            dt.Columns.Add("Lower control limit", typeof(string));
            dt.Columns.Add("Several measurements", typeof(string));
            dt.Columns.Add("Time corrected", typeof(string));
            dt.Columns.Add("Basic time", typeof(string)); //τ
            dt.Columns.Add("Standard time", typeof(string));

            double si = 0;
            double aveg = 0;
            double ni = 0;
            //The "temp" used for intermediate calculations
            double temp1 = 0, temp2 = 0, temp3 = 0, temp4 = 0, temp5 = 0, temp6 = 0, temp7 = 0, temp8 = 0;
            double zi = 0;
            double ti = 0;
            int temp = 0;

            foreach (valInRow i in colarry2)
            {
                DataRow row1 = dt.NewRow();
                row1["Element"] = i.Row + 1;
                count = 1;
                temp = i.getValSize(i.Val) - 3;
                temp8 = avg(i.Val);               
                ni = temp;
                aveg = (temp8 / ni);
                si = 0;
               
                foreach (string j in i.Val)
                {
                    if (count == temp + 1)
                    {
                         row1["Rate (%)"] = j;
                         row1["Average"] = "" + Math.Round(aveg, 2);
                         temp4 = Convert.ToDouble(j)/100;
                         temp2 = ni;

                         temp3 = si / temp2;
                         temp1 = (double)Math.Sqrt(temp3);

                         row1["Standard deviation"] = "" + Math.Round(temp1, 2);
                         row1["Several measurements"] = "" + Math.Round(ni, 2) ;
                         ti = aveg * temp4;
                       
                         row1["Time corrected"] = "" + Math.Round(ti, 2) ;
                         row1["Upper control limit"] = "" +  Math.Round(getUCLi(temp1,aveg), 2);
                         row1["Lower control limit"] = "" + Math.Round(getLCLi(temp1, aveg), 2) ;
                    }

                    if (count == temp + 2)
                    {
                        row1["Frequency"] = j;
                        temp6 = Convert.ToDouble(j);
                        temp5 = ti * temp6;
                        row1["Basic time"] = "" +  Math.Round(temp5, 2);
                    }

                    if (count == temp + 3)
                    {
                        row1["Extras rest (%)"] = j;
                        temp7 = (Convert.ToDouble(j)/100) + 1;
                        zi = temp7 * temp5;
                        sumZ += Math.Round(zi, 2);
                        row1["Standard time"] = "" +  Math.Round(zi, 2);
                    }
                    else
                    {
                        si += (double)Math.Pow(sii(aveg, j), 2);      
                    }
                    count++;
                }
                dt.Rows.Add(row1);
            }
 
            table2.Visible = true;
            table2.DataSource = dt;
            table2.DataBind();   
        }

        private void calTable3(LinkedList<valInRow> colarry2) //Display a 3 table
        {
            int cyc = cycel;
            int count = 1,k=0;

            double sumWi = 0, X = 0, Ci = 0;
            double ni = 0, Ni = 0, NiF = 0;
            //The "temp" used for intermediate calculations
            double temp1 = 0, temp2 = 0, temp3 = 0, temp4 = 0, temp5 = 0, temp6 = 0, temp7 = 0, temp8 = 0, temp9 = 0;
            double zi = 0,ti=0;
            double  R = 0, aveg = 0, si = 0,ri=0;
            int temp = 0,c2=0;
            LinkedList<String> str;
            valInRow vr; c2 = 1;
            tempstr = new double[colarry2.Count+1];
            tempStr2 = new int[colarry2.Count + 1];
            foreach (valInRow i in colarry2)
            {
                str = new LinkedList<String>();
                count = 1;
                temp = i.getValSize(i.Val) - 3;
                temp8 = avg(i.Val);
                ni = temp;
                aveg = (temp8 / ni);
                si = 0;
                
                foreach (string j in i.Val)
                {
                    if (count == temp + 1)
                    {
                        X = aveg;
                        R = Convert.ToDouble(TextBox2.Text);// / 100;
                        ri = Convert.ToDouble(j) / 100;
                        temp2 = ni;
                        temp3 = si / temp2;
                        temp1 = (double)Math.Sqrt(temp3);
                        Ci = (temp1);
                        Ni = (double)Math.Pow((K * Ci) / (R * X), 2);
                    }

                    if (count == temp + 2)
                    {
                        temp6 = Convert.ToDouble(j);
                        NiF = (int)Math.Ceiling(Ni*(1/temp6)); //Rounds a number up
                    }

                    if (count == temp + 3)
                    {
                        ti = aveg * ri;
                        temp4 = zi;                        
                        temp5 = ti * temp6;
                        temp7 = (Convert.ToDouble(j) / 100) + 1;
                        temp9 = (temp7 * temp5);
                        zi =  (temp9 / sumZ);
                        sumWi += zi ;
                       
                        str.AddLast("" + Math.Round(temp9, 2)) ;
                        str.AddLast("" +Convert.ToInt32(Ni)) ;
                        str.AddLast("" + Convert.ToInt32(NiF));
                        str.AddLast("" + Math.Round(zi, 2));
                        tempStr2[k] = Convert.ToInt32(NiF);
                        tempstr[k] = Math.Round(sumWi, 2);

                        str.AddLast("-");
                        vr = new valInRow(c2,str);
                        colarry3.AddLast(vr);
                        c2++;
                        k++;
                    }
                    else
                    {
                        si += (double)Math.Pow(sii(aveg, j), 2);
                    }
                    count++;
                }
             
            }

        }

        private void drowTable3() //Display a 3 table
        {
            int cyc = cycel;
            DataTable dt = new DataTable();
            int count = 1;

            dt.Columns.Add("Element", typeof(Int16));
            dt.Columns.Add("Standard time", typeof(string));
            dt.Columns.Add("Required measurements", typeof(string));
            dt.Columns.Add("Required cycles", typeof(double)); //n^*(1/f)
            dt.Columns.Add("Weight", typeof(string));
            dt.Columns.Add("Cumulative weight", typeof(string)); //
            Array.Sort(tempstr);
            int k = 1;
            foreach (valInRow i in colarry3)
            {
                DataRow row1 = dt.NewRow();
                row1["Element"] = i.Row;
 
                count = 1;
                foreach(string s in i.Val)
                {
                    if (count == 1)
                    {
                        row1["Standard time"] = s;
                    }
                    if (count == 2)
                    {
                        row1["Required measurements"] = s;
                    }
                    if (count == 3)
                    {
                        row1["Required cycles"] = Convert.ToDouble(s);
                    }
                    if (count == 4)
                    {
                        row1["Weight"] = s;
                    }
                    if (count == 5)
                    {
                        row1["Cumulative weight"] = s;
                    }
                  count++;
                }
                dt.Rows.Add(row1);
            }

            dt.DefaultView.Sort = "Required cycles ASC";
            Array.Sort(tempstr);
            Array.Sort(tempStr2);
            k = 0;
            dt = dt.DefaultView.ToTable();
            Boolean flag = false;
            foreach(double i in tempstr)
            {
                dt.Rows[k][5] = "" + i;
                if (i!=0)
                  k++;
                if (i == number_of_cycles_required)
                {
                    flag = true;
                    row = Convert.ToInt32(tempStr2[k]);
                }
                if (flag == false)
                {
                    if (i > number_of_cycles_required)
                    {
                        flag = true;
                        row = Convert.ToInt32(tempStr2[k]);
                    }
                }
            }
            dt = dt.DefaultView.ToTable();
            table3.Visible = true;
            table3.DataSource = dt;
           
            table3.DataBind();
            
        }

        private void calTable4(LinkedList<valInRow> colarry2) //Display a 3 table
        {
            int cyc = cycel;
            int count = 1;
            sumRW = 0;
            double sumWi = 0, X = 0, Ci = 0;
            double ni = 0, Ni = 0, NiF = 0;
            //The "temp" used for intermediate calculations
            double temp1 = 0, temp2 = 0, temp3 = 0, temp4 = 0, temp5 = 0, temp6 = 0, temp7 = 0, temp8 = 0, temp9 = 0;
            double zi = 0, ti = 0;
            double R = 0, aveg = 0, si = 0, ri = 0,Ri=0;
            int temp = 0, c2 = 0;
            LinkedList<String> str;
            valInRow vr; c2 = 1;

            foreach (valInRow i in colarry2)
            {
                str = new LinkedList<String>();
                count = 1;
                temp = i.getValSize(i.Val) - 3;
                temp8 = avg(i.Val);
                ni = temp;
                aveg = (temp8 / ni);
                si = 0;

                foreach (string j in i.Val)
                {
                    if (count == temp + 1)
                    {
                        X = Math.Round(aveg, 2);
                        R = Convert.ToDouble(TextBox2.Text);// / 100;
                        ri = Convert.ToDouble(j) / 100;
                        temp2 = ni;
                        temp3 = si / temp2;
                        temp1 = (double)Math.Sqrt(temp3);
                        Ci = Math.Round(temp1, 2);
                        Ni = Math.Round((double)Math.Pow((K * Ci) / (R * X), 2), 2);

                    }

                    if (count == temp + 2)
                    {
                        temp6 = Convert.ToDouble(j);
                        NiF = Math.Round(Ni * (1 / temp6), 2);

                    }

                    if (count == temp + 3)
                    {
                        ti = aveg * ri;
                        temp4 = zi;
                        temp5 = ti * temp6;
                        temp7 = (Convert.ToDouble(j) / 100) + 1;
                        temp9 = Math.Round((temp7 * temp5), 2);
                        zi = Math.Round((temp9 / sumZ), 2);

                        Ri = Math.Round(((K * Ci) / ((double)(Math.Sqrt(ni)) * X)), 3);

                        sumWi = Math.Round(Ri*zi,3);
                        sumRW += Math.Round(sumWi, 3);

                        str.AddLast("" + X);
                        str.AddLast("" + Ci);
                        str.AddLast("" + ni);
                        str.AddLast("" + (zi * 100 )+ "%");
                        str.AddLast("" + Ri);
                        str.AddLast("" + sumWi);
                        vr = new valInRow(c2, str);
                        colarry4.AddLast(vr);
                        c2++;
                    }
                    else
                    {
                        si += (double)Math.Pow(sii(aveg, j), 2);
                    }
                    count++;
                }
            }
        }

        private void drowTable4() //Display a 3 table
        {
            int cyc = cycel;
            DataTable dt = new DataTable();
            int count = 1;

            dt.Columns.Add("Element", typeof(Int16));
            dt.Columns.Add("Average", typeof(string));
            dt.Columns.Add("Standard deviation", typeof(string));
            dt.Columns.Add("Several measurements", typeof(string));
            dt.Columns.Add("Weight (w)", typeof(string));
            dt.Columns.Add("Inaccuracy (r)", typeof(string));
            dt.Columns.Add("r*w", typeof(string));
            foreach (valInRow i in colarry4)
            {
                DataRow row1 = dt.NewRow();
                row1["Element"] = i.Row;
                count = 1;

                            
                foreach (string s in i.Val)
                {
                    if (count == 1)
                    {
                        row1["Average"] = s;
                    }
                    if (count == 2)
                    {
                        row1["Standard deviation"] = s;
                    }
                    if (count == 3)
                    {
                        row1["Several measurements"] = s;
                    }
                    if (count == 4)
                    {
                        row1["Weight (w)"] = s;
                    }
                    if (count == 5)
                    {
                        row1["Inaccuracy (r)"] = s;
                    }
                    if (count == 6)
                    {
                        row1["r*w"] = s;
                    }
                    count++;
                }



                dt.Rows.Add(row1);
            }

            table4.Visible = true;
            table4.DataSource = dt;
            table4.DataBind();
        }


        private double sii(double avg, string j) //Calculating the standard deviation interim
        {
            double temp = 0;
            temp = Convert.ToDouble(j);
            double k = 0;
            k = temp - avg;
            return k;
        }

        private double avg(LinkedList<String> str) //Calculate the average intermediate
        {
            double avgi = 0;
            int c = 0;

            foreach (string j in str)
            {
                if (c == str.Count-3)
                    break;
                avgi += Convert.ToDouble(j);
                c++;
           }
           return avgi;
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            Button2.Visible = true;         
            TextBox1.Visible = true;
            Button4.Visible = true;
            Label3.Visible = true;
            Session.Add("cyc", cycBox.Text);
            Session.Add("colarry", colarry);
        }

        protected void Button4_Click(object sender, EventArgs e)
        {
            try 
            { 
                Convert.ToDouble(TextBox1.Text); 
     
                error.Text = "";
                Label5.Visible = true;
                Label2.Visible = true;
                Label12.Visible = true;
               
                Button10.Visible = true;
                TextBox3.Visible = true;
                Label10.Visible = true;
                Label7.Visible = true;
                TextBox2.Visible = true;
                LinkedList<valInRow> colarry2 = new LinkedList<valInRow>();               
                RemovalExceptions(colarry2);
                drowTable2(colarry2);
               Label12.Text = "" + sumZ;
               Session.Add("cyc", cycBox.Text);
               Session.Add("colarry", colarry);

            }
            catch { error.Text = "Error in the text!"; }

        }

        private double getUCLi(double si,double aveg) //Calculating upper control limit
        {
            
            double UCLi = 0;
            try { 
               K = Convert.ToDouble(TextBox1.Text);
                UCLi = aveg + (K) * si;
               
                return UCLi;
            }
            catch { return 0; }
        }

        private double getLCLi(double si, double aveg) //Calculation of the lower control limit
        {
            double LCLi = 0;
            try{
                K = Convert.ToDouble(TextBox1.Text);
                LCLi = aveg - (K) * si;
                if (LCLi < 0)
                    return 0;
                else
                    return LCLi;
            }
            catch { return 0; }

        }

        private void RemovalExceptions(LinkedList<valInRow> colarry2) //Publishing Exceptions
        {
            double si = 0;
            double aveg = 0,UCLi =0,LCLi=0;
            double ni = 0, temp8 = 0, temp2 = 0, temp4 = 0, temp3 = 0, temp1 = 0;
            int count = 1, c2 = 1 ;
            valInRow newVR;
            int c = -1;
            LinkedList<string> newSTR;

            foreach (valInRow i in colarry)
            {
                UCLi = 0; LCLi = 0;
                count = 1;
                newSTR = new LinkedList<string>();
                temp8 = avg(i.Val);
                ni = i.Val.Count - 3;
                aveg = (temp8 / ni);
                si = 0;
                foreach (string j in i.Val)
                {
                    if (count > cycel )
                    {
                       
                        temp2 = ni;
                        temp3 = si / temp2;
                        temp1 = (double)Math.Sqrt(temp3);
                     
                        si = temp1;
                        
                        UCLi = getUCLi(Math.Round(si, 2), aveg);
                        LCLi = getLCLi(Math.Round(si, 2), aveg);
                        newSTR = new LinkedList<string>();
                        c2 = 1;
                        foreach (string j2 in i.Val)
                            {
                                temp4 = Convert.ToDouble(j2);
                                                                   
                                if(c2 >cycel)
                                {
                                    newSTR.AddLast(j2);
                                }
                                else if(temp4<=UCLi && temp4>=LCLi)
                                {
                                    newSTR.AddLast(j2);
                                }  c2++;
                            }
                        c++;
                        newVR = new valInRow(c,newSTR);
                        colarry2.AddLast(newVR);
                        break;
                    }

                    else
                    {
                        si += (double)Math.Pow(sii(aveg, j), 2); 
                        count++;
                    }
                }
            }
        }

        protected void Button5_Click(object sender, EventArgs e)
        {
            colarry = new LinkedList<valInRow>();
            error.Text = "";
            cycBox.Text = "";
            TextBox1.Visible = false;
            TextBox3.Visible = false;
            TextBox4.Visible = false;
            table.Visible = false;
            table3.Visible = false;
            table4.Visible = false;
            Button2.Visible = false;
            Button3.Visible = false;
            Button4.Visible = false;
            Button11.Visible = false;
            Button10.Visible = false;
            Label3.Visible = false;
            table2.Visible = false;
            Label5.Visible = false;
            Label12.Visible = false;
            Label10.Visible = false;
            Label14.Visible = false;
            Label15.Visible = false;
            Label16.Visible = false;
            Label8.Visible = false;
            Label9.Visible = false;
            Label19.Visible = false;
            Label13.Visible = false;
            Label11.Visible = false;
            Label17.Visible = false;
            Label18.Visible = false;
            Button1.Visible = true;
            Label7.Visible = false;
            TextBox2.Visible = false;

            Session.Add("cyc", "0");
            Session.Add("colarry", colarry);
            Session.Add("row", -1);
        }

        protected void Button6_Click(object sender, EventArgs e)
        {
            colarry = new LinkedList<valInRow>();
            valInRow vr;
            int c = 0;
            LinkedList<String> str;
            for (int i = 0; i < 7; i++)
            {
                str = new LinkedList<String>();
                if (c == 0)
                {
                    str.AddLast("" + 5);
                    str.AddLast("" + 6);
                    str.AddLast("" + 5);
                    str.AddLast("" + 7);
                    str.AddLast("" + 5);
                    str.AddLast("" + 5);
                    str.AddLast("" + 6);
                    str.AddLast("" + 5);
                    str.AddLast("" + 7);
                    str.AddLast("" + 6);
                    str.AddLast("" + 110);
                    str.AddLast("" + 9);
                    str.AddLast("" + 15);
                    vr = new valInRow(c, str);
                    colarry.AddLast(vr);
                    c++;
                }
                else if (c == 1)
                {
                    str.AddLast("" + 3);
                    str.AddLast("" + 5);
                    str.AddLast("" + 3);
                    str.AddLast("" + 4);
                    str.AddLast("" + 3);
                    str.AddLast("" + 4);
                    str.AddLast("" + 3);
                    str.AddLast("" + 4);
                    str.AddLast("" + 3);
                    str.AddLast("" + 4);
                    str.AddLast("" + 100);
                    str.AddLast("" + 9);
                    str.AddLast("" + 12);
                    vr = new valInRow(c, str);
                    colarry.AddLast(vr);
                    c++;
                }
                else if (c == 2)
                {
                    str.AddLast("" + 8);
                    str.AddLast("" + 5);
                    str.AddLast("" + 7);
                    str.AddLast("" + 6);
                    str.AddLast("" + 5);
                    str.AddLast("" + 6);
                    str.AddLast("" + 5);
                    str.AddLast("" + 7);
                    str.AddLast("" + 6);
                    str.AddLast("" + 5);
                    str.AddLast("" + 90);
                    str.AddLast("" + 3);
                    str.AddLast("" + 15);
                    vr = new valInRow(c, str);
                    colarry.AddLast(vr);
                    c++;
                }
                else if (c == 3)
                {
                    str.AddLast("" + 10);
                    str.AddLast("" + 10);
                    str.AddLast("" + 9);
                    str.AddLast("" + 9);
                    str.AddLast("" + 8);
                    str.AddLast("" + 10);
                    str.AddLast("" + 11);
                    str.AddLast("" + 12);
                    str.AddLast("" + 9);
                    str.AddLast("" + 10);
                    str.AddLast("" + 110);
                    str.AddLast("" + 1);
                    str.AddLast("" + 17);
                    vr = new valInRow(c, str);
                    colarry.AddLast(vr);
                    c++;
                }
                else if (c == 4)
                {
                    str.AddLast("" + 8);
                    str.AddLast("" + 8);
                    str.AddLast("" + 9);
                    str.AddLast("" + 9);
                    str.AddLast("" + 7);
                    str.AddLast("" + 8);
                    str.AddLast("" + 9);
                    str.AddLast("" + 9);
                    str.AddLast("" + 7);
                    str.AddLast("" + 8);
                    str.AddLast("" + 90);
                    str.AddLast("" + 1);
                    str.AddLast("" + 20);
                    vr = new valInRow(c, str);
                    colarry.AddLast(vr);
                    c++;
                }
                else if (c == 5)
                {
                    str.AddLast("" + 25);
                    str.AddLast("" + 22);
                    str.AddLast("" + 23);
                    str.AddLast("" + 28);
                    str.AddLast("" + 27);
                    str.AddLast("" + 22);
                    str.AddLast("" + 25);
                    str.AddLast("" + 31);
                    str.AddLast("" + 27);
                    str.AddLast("" + 25);
                    str.AddLast("" + 110);
                    str.AddLast("" + 0.1);
                    str.AddLast("" + 20);
                    vr = new valInRow(c, str);
                    colarry.AddLast(vr);
                    c++;
                }
                else if (c == 6)
                {
                    str.AddLast("" + 20);
                    str.AddLast("" + 21);
                    str.AddLast("" + 20);
                    str.AddLast("" + 17);
                    str.AddLast("" + 18);
                    str.AddLast("" + 20);
                    str.AddLast("" + 21);
                    str.AddLast("" + 19);
                    str.AddLast("" + 18);
                    str.AddLast("" + 17);
                    str.AddLast("" + 100);
                    str.AddLast("" + 0.1);
                    str.AddLast("" + 17);
                    vr = new valInRow(c, str);
                    colarry.AddLast(vr);
                    c++;
                }
            }
            drowTable(10);
            Session.Add("cyc", ""+10);
            Session.Add("row", 1);
            Session.Add("colarry", colarry);
           
        }

        

        protected void Button8_Click(object sender, EventArgs e)
        {
            try
            {
                double qe = Convert.ToDouble(TextBox3.Text);
                error.Text = "";
                number_of_cycles_required = (qe/100);
       
                Convert.ToDouble(TextBox2.Text);
                LinkedList<valInRow> colarry2 = new LinkedList<valInRow>();
                 Label8.Visible = true;
                 Label19.Visible = true;
                  Label9.Visible = true;
                  Label13.Visible = true;
                  TextBox4.Visible = true;
                  Button11.Visible = true;
                  Label17.Visible = true;
                  
                  RemovalExceptions(colarry2);
                  calTable3(colarry2);
                drowTable3();
                calTable4(colarry2);
                drowTable4();
                Label16.Visible = true;
                Label15.Text = " " + row + " cycles";
                Label15.Visible = true;
                  Label19.Text += "" + sumRW;
                  double q = Math.Round((6000 / sumZ),2);
                  Label17.Text = "" + q;
         
                Session.Add("cyc", cycBox.Text);
                Session.Add("colarry", colarry);

            }
            catch { error.Text = "Error in the text!"; }


        }

        protected void Button11_Click(object sender, EventArgs e)
        {
         
            try
            {
                double qe = Convert.ToDouble(TextBox4.Text);
                error.Text = "";

                Label11.Visible = true;
                Label18.Visible = true;
                double q = Math.Round((6000 / sumZ), 2);
               Label18.Text = ""+ (q * (qe / 100));


                Session.Add("cyc", cycBox.Text);
                Session.Add("colarry", colarry);

            }
            catch { error.Text = "Error in the text!"; }


        }


    }
}