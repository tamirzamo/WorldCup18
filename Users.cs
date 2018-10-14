using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace WorldCup18
{
    public class Users
    {
        
        public string[] teams { get; set; }
        public int pnts { get; set; }
        public string ImageUrl { get; set; }
        public string name { get; set; }
        public string Department { get; set; }



        public Users(string name1, string frist, string sec, string third, string four, int pnt)
        {

            name = name1;
            teams = new string[] { frist, sec, third, four };
            pnts = pnt;
        }



        public override string ToString()
        {
            return name + " " + pnts;
        }
    }
}