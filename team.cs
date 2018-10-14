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
    class team
    {

        public string code;
        public char rank;
        public int pnts;
        public int played;
        public team(string code1, char rank1, int pnt, int playso)
        {
            played = playso;
            code = code1;
            rank = rank1;
            pnts = pnt;
        }
    }

}