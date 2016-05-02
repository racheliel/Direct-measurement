using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4
{
    
    public class valInRow
    {
        private int row;
        private LinkedList<string> val;

        public valInRow(int r, LinkedList<string> v)
        {
            row = r;
            val = v;
        }

        public int Row
        {
            get { return row; }
            set { row = value; }
        }

        public LinkedList<string> Val
        {
            get { return val; }
            set { val = value; }
        }

        public int getValSize(LinkedList<string> v)
        {
            return v.Count;
        }

        public LinkedList<string> removeFromVal(LinkedList<string> v,string s)
        {
            LinkedList<string> newVal = new LinkedList<string>();
            foreach(string i in v)
            {
                if(!i.Equals(s))
                {
                    newVal.AddLast(i);
                }
                
            }
            return newVal;
        }

     



    }

}