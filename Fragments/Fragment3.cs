using Android.OS;
using Android.Support.V4.App;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace WorldCup18.Fragments
{
    public class Fragment3 : Fragment
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public static Fragment3 NewInstance(Bundle mybundle)
        {
            var frag3 = new Fragment3 { Arguments = mybundle };
            return frag3;
        }


        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            var ignored = base.OnCreateView(inflater, container, savedInstanceState);
            var viewc = inflater.Inflate(Resource.Layout.fragment3, container, false);
            ListView myList = viewc.FindViewById<ListView>(Resource.Id.listView);

            var friend = Arguments.GetString("friend");
            var Friendslist = JsonConvert.DeserializeObject<IList<Users>>(friend);
            Friendslist.Add(new Users("kkkkkk", "BEL", "URU", "SEN", "MAR", 100));
            Friendslist[6].ImageUrl = "tamir.jpg";
            var res= Friendslist.OrderBy(f => f.pnts);
            var zzzz= res.Reverse();
            IEnumerable<Users> sortedEnum=  zzzz;
            
            IList<Users> sortedList = sortedEnum.ToList();
            
            myList.Adapter = new MyCustomListAdapter(sortedList);

            return viewc;
        }
    }
}