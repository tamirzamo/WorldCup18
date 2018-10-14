using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace WorldCup18.Fragments
{
    public class Fragment1 : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public static Fragment1 NewInstance(Bundle mybundle)
        {
            var frag1 = new Fragment1 { Arguments =mybundle };
            return frag1;
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {

            var friend = Arguments.GetString("friend");
            var Friendslist = JsonConvert.DeserializeObject<IList<Users>>(friend);

            var listid = Arguments.GetString("list");
            var list = JsonConvert.DeserializeObject<IList<team>>(listid);
            
           
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            var viewc = inflater.Inflate(Resource.Layout.fragment1, container, false);
            TextView a =viewc.FindViewById<TextView>(Resource.Id.tamir_tbl_txt2);
            TextView b = viewc.FindViewById<TextView>(Resource.Id.tamir_tbl_txt3);
            TextView c = viewc.FindViewById<TextView>(Resource.Id.tamir_tbl_txt4);
            TextView d = viewc.FindViewById<TextView>(Resource.Id.tamir_tbl_txt5);
            TextView e = viewc.FindViewById<TextView>(Resource.Id.tamir_tbl_txt6);
            a.Append(Friendslist[0].teams[0] + "|" + list.First(x => x.code.Contains(Friendslist[0].teams[0])).pnts.ToString() + "|" + list.First(x => x.code.Contains(Friendslist[0].teams[0])).played.ToString());
     
            b.Append(Friendslist[0].teams[1] + "|" + list.First(x => x.code.Contains(Friendslist[0].teams[1])).pnts.ToString() + "|" + list.First(x => x.code.Contains(Friendslist[0].teams[1])).played.ToString());
            c.Append(Friendslist[0].teams[2] + "|" + list.First(x => x.code.Contains(Friendslist[0].teams[2])).pnts.ToString() + "|" + list.First(x => x.code.Contains(Friendslist[0].teams[2])).played.ToString());
            d.Append(Friendslist[0].teams[3] + "|" + list.First(x => x.code.Contains(Friendslist[0].teams[3])).pnts.ToString() + "|" + list.First(x => x.code.Contains(Friendslist[0].teams[3])).played.ToString());
            e.Append((Friendslist[0].pnts.ToString()));


            TextView mata1 = viewc.FindViewById<TextView>(Resource.Id.matan_tbl_txt2);
            TextView mata2 = viewc.FindViewById<TextView>(Resource.Id.matan_tbl_txt3);
            TextView mata3 = viewc.FindViewById<TextView>(Resource.Id.matan_tbl_txt4);
            TextView mata4 = viewc.FindViewById<TextView>(Resource.Id.matan_tbl_txt5);
            TextView mata5 = viewc.FindViewById<TextView>(Resource.Id.matan_tbl_txt6);
            mata1.Append(Friendslist[1].teams[0] + "|" + list.First(x => x.code.Contains(Friendslist[1].teams[0])).pnts.ToString() + "|" + list.First(x => x.code.Contains(Friendslist[1].teams[0])).played.ToString());
            // a.SetBackgroundResource(Resource.Drawable.Brazil);
            mata2.Append(Friendslist[1].teams[1] + "|" + list.First(x => x.code.Contains(Friendslist[1].teams[1])).pnts.ToString() + "|" + list.First(x => x.code.Contains(Friendslist[1].teams[1])).played.ToString());
            mata3.Append(Friendslist[1].teams[2] + "|" + list.First(x => x.code.Contains(Friendslist[1].teams[2])).pnts.ToString() + "|" + list.First(x => x.code.Contains(Friendslist[1].teams[2])).played.ToString());
            mata4.Append(Friendslist[1].teams[3] + "|" + list.First(x => x.code.Contains(Friendslist[1].teams[3])).pnts.ToString() + "|" + list.First(x => x.code.Contains(Friendslist[1].teams[3])).played.ToString());
            mata5.Append((Friendslist[1].pnts.ToString()));

            TextView lior1 = viewc.FindViewById<TextView>(Resource.Id.lior_tbl_txt2);
            TextView lior2 = viewc.FindViewById<TextView>(Resource.Id.lior_tbl_txt3);
            TextView lior3 = viewc.FindViewById<TextView>(Resource.Id.lior_tbl_txt4);
            TextView lior4 = viewc.FindViewById<TextView>(Resource.Id.lior_tbl_txt5);
            TextView lior5 = viewc.FindViewById<TextView>(Resource.Id.lior_tbl_txt6);
            lior1.Append(Friendslist[2].teams[0] + "|" + list.First(x => x.code.Contains(Friendslist[2].teams[0])).pnts.ToString() + "|" + list.First(x => x.code.Contains(Friendslist[2].teams[0])).played.ToString());

            //lior1.SetBackgroundResource(Resource.Drawable.Brazil);

            string xxxx = list.First(x => x.code.Contains(Friendslist[2].teams[1])).pnts.ToString();
            lior2.Append(Friendslist[2].teams[1] + "|" + list.First(x => x.code.Contains(Friendslist[2].teams[1])).pnts.ToString() + "|" + list.First(x => x.code.Contains(Friendslist[2].teams[1])).played.ToString());
            lior3.Append(Friendslist[2].teams[2] + "|" + list.First(x => x.code.Contains(Friendslist[2].teams[2])).pnts.ToString() + "|" + list.First(x => x.code.Contains(Friendslist[2].teams[2])).played.ToString());
            lior4.Append(Friendslist[2].teams[3] + "|" + list.First(x => x.code.Contains(Friendslist[2].teams[3])).pnts.ToString() + "|" + list.First(x => x.code.Contains(Friendslist[2].teams[3])).played.ToString());
            lior5.Append((Friendslist[2].pnts.ToString()));


            TextView shai1 = viewc.FindViewById<TextView>(Resource.Id.shai_tbl_txt2);
            TextView shai2 = viewc.FindViewById<TextView>(Resource.Id.shai_tbl_txt3);
            TextView shai3 = viewc.FindViewById<TextView>(Resource.Id.shai_tbl_txt4);
            TextView shai4 = viewc.FindViewById<TextView>(Resource.Id.shai_tbl_txt5);
            TextView shai5 = viewc.FindViewById<TextView>(Resource.Id.shai_tbl_txt6);
            shai1.Append(Friendslist[3].teams[0] + "|" + list.First(x => x.code.Contains(Friendslist[3].teams[0])).pnts.ToString() + "|" + list.First(x => x.code.Contains(Friendslist[3].teams[0])).played.ToString());
            // a.SetBackgroundResource(Resource.Drawable.Brazil);
            shai2.Append(Friendslist[3].teams[1] + "|" + list.First(x => x.code.Contains(Friendslist[3].teams[1])).pnts.ToString() + "|" + list.First(x => x.code.Contains(Friendslist[3].teams[1])).played.ToString());
            shai3.Append(Friendslist[3].teams[2] + "|" + list.First(x => x.code.Contains(Friendslist[3].teams[2])).pnts.ToString() + "|" + list.First(x => x.code.Contains(Friendslist[3].teams[2])).played.ToString());
            shai4.Append(Friendslist[3].teams[3] + "|" + list.First(x => x.code.Contains(Friendslist[3].teams[3])).pnts.ToString() + "|" + list.First(x => x.code.Contains(Friendslist[3].teams[3])).played.ToString());
            shai5.Append((Friendslist[3].pnts.ToString()));

            TextView adam1 = viewc.FindViewById<TextView>(Resource.Id.adam_tbl_txt2);
            TextView adam2 = viewc.FindViewById<TextView>(Resource.Id.adam_tbl_txt3);
            TextView adam3 = viewc.FindViewById<TextView>(Resource.Id.adam_tbl_txt4);
            TextView adam4 = viewc.FindViewById<TextView>(Resource.Id.adam_tbl_txt5);
            TextView adam5 = viewc.FindViewById<TextView>(Resource.Id.adam_tbl_txt6);
            adam1.Append(Friendslist[4].teams[0] + "|" + list.First(x => x.code.Contains(Friendslist[4].teams[0])).pnts.ToString() + "|" + list.First(x => x.code.Contains(Friendslist[4].teams[0])).played.ToString());
            // a.SetBackgroundResource(Resource.Drawable.Brazil);
            adam2.Append(Friendslist[4].teams[1] + "|" + list.First(x => x.code.Contains(Friendslist[4].teams[1])).pnts.ToString() + "|" + list.First(x => x.code.Contains(Friendslist[4].teams[1])).played.ToString());
            adam3.Append(Friendslist[4].teams[2] + "|" + list.First(x => x.code.Contains(Friendslist[4].teams[2])).pnts.ToString() + "|" + list.First(x => x.code.Contains(Friendslist[4].teams[2])).played.ToString());
            adam4.Append(Friendslist[4].teams[3] + "|" + list.First(x => x.code.Contains(Friendslist[4].teams[3])).pnts.ToString() + "|" + list.First(x => x.code.Contains(Friendslist[4].teams[3])).played.ToString());
            adam5.Append((Friendslist[4].pnts.ToString()));


            TextView avi1 = viewc.FindViewById<TextView>(Resource.Id.avi_tbl_txt2);
            TextView avi2 = viewc.FindViewById<TextView>(Resource.Id.avi_tbl_txt3);
            TextView avi3 = viewc.FindViewById<TextView>(Resource.Id.avi_tbl_txt4);
            TextView avi4 = viewc.FindViewById<TextView>(Resource.Id.avi_tbl_txt5);
            TextView avi5 = viewc.FindViewById<TextView>(Resource.Id.avi_tbl_txt6);
            avi1.Append(Friendslist[5].teams[0] + "|" + list.First(x => x.code.Contains(Friendslist[5].teams[0])).pnts.ToString() + "|" + list.First(x => x.code.Contains(Friendslist[5].teams[0])).played.ToString());
            // a.SetBackgroundResource(Resource.Drawable.Brazil);
            avi2.Append(Friendslist[5].teams[1] + "|" + list.First(x => x.code.Contains(Friendslist[5].teams[1])).pnts.ToString() + "|" + list.First(x => x.code.Contains(Friendslist[5].teams[1])).played.ToString());
            avi3.Append(Friendslist[5].teams[2] + "|" + list.First(x => x.code.Contains(Friendslist[5].teams[2])).pnts.ToString() + "|" + list.First(x => x.code.Contains(Friendslist[5].teams[2])).played.ToString());
            avi4.Append(Friendslist[5].teams[3] + "|" + list.First(x => x.code.Contains(Friendslist[5].teams[3])).pnts.ToString() + "|" + list.First(x => x.code.Contains(Friendslist[5].teams[3])).played.ToString());
            avi5.Append((Friendslist[5].pnts.ToString()));
            return viewc;
        }
    }
}