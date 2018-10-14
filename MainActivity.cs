using Android.App;
using Android.OS;
using WorldCup18.Fragments;

using Android.Support.Design.Widget;
using Android.Support.V7.App;
using System.Collections.Generic;
using QuickType;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WorldCup18
{
    [Activity(Label = "@string/app_name", MainLauncher = true, LaunchMode = Android.Content.PM.LaunchMode.SingleTop, Icon = "@drawable/worldicon")]
    public class MainActivity : AppCompatActivity
    {
        private string[] RankA = { "ESP", "GER", "BRA", "ARG", "BEL", "FRA", "POR" };//0-6
        private string[] RankB = { "RUS", "POL", "PER", "SUI", "ENG", "COL", "MEX", "URU", "CRO" };//7-15
        private string[] RankC = { "DEN", "ISL", "CRC", "SWE", "TUN", "EGY", "SEN", "IRN" };//16-23
        private string[] RankD = { "SRB", "AUS", "JPN", "MAR", "PAN", "NGA", "KOR", "KSA" };//24-31
        private string[] names = { "tamir_", "matan_", "lior_", "shai_", "adam_", "avi_" };
        List<Users> Friendslist = new List<Users>();
        List<team> list = new List<team>();

        BottomNavigationView bottomNavigation;
        protected async override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.main);

            Friendslist.Add(new Users("tamir", "BEL", "URU", "SEN", "MAR", 0));
            Friendslist.Add(new Users("matan", "BRA", "ENG", "DEN", "SRB", 0));
            Friendslist.Add(new Users("lior", "FRA", "ENG", "SWE", "SRB", 0));
            Friendslist.Add(new Users("shai", "BRA", "URU", "EGY", "SRB", 0));
            Friendslist.Add(new Users("adam", "GER", "URU", "DEN", "PAN", 0));
            Friendslist.Add(new Users("avi", "BRA", "ENG", "SEN", "KSA", 0));
            Friendslist[0].ImageUrl = "tamir.jpg";
            Friendslist[1].ImageUrl = "matan.jpg";
            Friendslist[2].ImageUrl = "lior.jpg";
            Friendslist[3].ImageUrl = "shai.jpg";
            Friendslist[4].ImageUrl = "adam.jpg";
            Friendslist[5].ImageUrl = "avi.jpg";
            for (int j = 0; j < 32; j++)
            {
                if (j >= 0 && j <= 6)
                    list.Add(new team(RankA[j], 'A', 0, 0));
                else if (j >= 7 && j <= 15)
                    list.Add(new team(RankB[j - 7], 'B', 0, 0));
                else if (j >= 16 && j <= 23)
                    list.Add(new team(RankC[j - 16], 'C', 0, 0));
                else if (j >= 24 && j <= 31)
                    list.Add(new team(RankD[j - 24], 'D', 0, 0));

            }

            using (WebClient w = new WebClient())
            {
                var json = w.DownloadString("https://raw.githubusercontent.com/openfootball/world-cup.json/master/2018/worldcup.json");

                var rounds = Rounds.FromJson(json);
                await Task.Run(() => datau(rounds));
            }
       
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            if (toolbar != null)
            {
                SetSupportActionBar(toolbar);
                SupportActionBar.SetDisplayHomeAsUpEnabled(false);
                SupportActionBar.SetHomeButtonEnabled(false);

            }

            bottomNavigation = FindViewById<BottomNavigationView>(Resource.Id.bottom_navigation);


            bottomNavigation.NavigationItemSelected += BottomNavigation_NavigationItemSelected;

            LoadFragment(Resource.Id.menu_home);
        }

        private void BottomNavigation_NavigationItemSelected(object sender, BottomNavigationView.NavigationItemSelectedEventArgs e)
        {
            LoadFragment(e.Item.ItemId);
        }

        void LoadFragment(int id)
        {
            Android.Support.V4.App.Fragment fragment = null;
            var serializedStuff = JsonConvert.SerializeObject(Friendslist);
            var serializedStuff2 = JsonConvert.SerializeObject(list);
            var bundle = new Bundle();
            bundle.PutString("friend", serializedStuff);
            bundle.PutString("list", serializedStuff2);
            switch (id)
            {
                case Resource.Id.menu_home:
                    fragment = Fragment1.NewInstance(bundle);
                    break;
                case Resource.Id.menu_audio:
                    fragment = Fragment2.NewInstance();
                    break;
                case Resource.Id.menu_video:
                    fragment = Fragment3.NewInstance(bundle);
                    break;
            }
            if (fragment == null)
                return;

            SupportFragmentManager.BeginTransaction()
               .Replace(Resource.Id.content_frame, fragment).CommitNowAllowingStateLoss();
               
        }



        public async void datau(Rounds rounds)
        {

            rounds.RoundsRounds[14].Matches[0].Score1 = 0;
            rounds.RoundsRounds[14].Matches[0].Score2 = 1;
            rounds.RoundsRounds[14].Matches[1].Score1 = 1;
            rounds.RoundsRounds[14].Matches[1].Score2 = 2;

            for (int i = 0; i < rounds.RoundsRounds.LongLength; i++)
            {
                for (int j = 0; j < rounds.RoundsRounds[i].Matches.LongLength; j++)

                {


                    if (rounds.RoundsRounds[i].Matches.LongLength <2)
                    {
                        break;
                    }

                    if (i>=15)
                    {
                        list.Find(x => x.code.Contains(rounds.RoundsRounds[i].Matches[j].Team1.Code)).pnts += 2;
                        list.Find(x => x.code.Contains(rounds.RoundsRounds[i].Matches[j].Team2.Code)).pnts += 2;


                    }

                    if (rounds.RoundsRounds[i].Matches[j].Score1Et == null)
                    {
                        if (rounds.RoundsRounds[i].Matches[j].Score1 == rounds.RoundsRounds[i].Matches[j].Score2 && rounds.RoundsRounds[i].Matches[j].Score1 != null)
                        {
                            list.Find(x => x.code.Contains(rounds.RoundsRounds[i].Matches[j].Team1.Code)).pnts += 1;
                            list.Find(x => x.code.Contains(rounds.RoundsRounds[i].Matches[j].Team2.Code)).pnts += 1;
                            list.Find(x => x.code.Contains(rounds.RoundsRounds[i].Matches[j].Team1.Code)).played++;
                            list.Find(x => x.code.Contains(rounds.RoundsRounds[i].Matches[j].Team2.Code)).played++;

                        }
                        else if (rounds.RoundsRounds[i].Matches[j].Score1 != null)
                        {


                            var home = list.Find(x => x.code.Contains(rounds.RoundsRounds[i].Matches[j].Team1.Code));
                            var away = list.Find(x => x.code.Contains(rounds.RoundsRounds[i].Matches[j].Team2.Code));

                            if (rounds.RoundsRounds[i].Matches[j].Score1 > rounds.RoundsRounds[i].Matches[j].Score2)
                            {
                                if (home.rank > away.rank) list.Find(x => x.code.Contains(home.code)).pnts += 4;
                                else list.Find(x => x.code.Contains(home.code)).pnts += 3;
                                list.Find(x => x.code.Contains(rounds.RoundsRounds[i].Matches[j].Team1.Code)).played++;
                                list.Find(x => x.code.Contains(rounds.RoundsRounds[i].Matches[j].Team2.Code)).played++;

                            }
                            else
                            {

                                if (away.rank > home.rank) list.Find(x => x.code.Contains(away.code)).pnts += 4;
                                else list.Find(x => x.code.Contains(away.code)).pnts += 3;

                                list.Find(x => x.code.Contains(rounds.RoundsRounds[i].Matches[j].Team1.Code)).played++;
                                list.Find(x => x.code.Contains(rounds.RoundsRounds[i].Matches[j].Team2.Code)).played++;
                            }
                        }
                    }
                    else
                    {
                        if (rounds.RoundsRounds[i].Matches[j].Score1Et == rounds.RoundsRounds[i].Matches[j].Score2Et && rounds.RoundsRounds[i].Matches[j].Score1Et != null)
                        {
                            list.Find(x => x.code.Contains(rounds.RoundsRounds[i].Matches[j].Team1.Code)).pnts += 1;
                            list.Find(x => x.code.Contains(rounds.RoundsRounds[i].Matches[j].Team2.Code)).pnts += 1;
                            list.Find(x => x.code.Contains(rounds.RoundsRounds[i].Matches[j].Team1.Code)).played++;
                            list.Find(x => x.code.Contains(rounds.RoundsRounds[i].Matches[j].Team2.Code)).played++;

                        }
                        else if (rounds.RoundsRounds[i].Matches[j].Score1Et != null)
                        {


                            var home = list.Find(x => x.code.Contains(rounds.RoundsRounds[i].Matches[j].Team1.Code));
                            var away = list.Find(x => x.code.Contains(rounds.RoundsRounds[i].Matches[j].Team2.Code));

                            if (rounds.RoundsRounds[i].Matches[j].Score1Et > rounds.RoundsRounds[i].Matches[j].Score2Et)
                            {
                                if (home.rank > away.rank) list.Find(x => x.code.Contains(home.code)).pnts += 4;
                                else list.Find(x => x.code.Contains(home.code)).pnts += 3;
                                list.Find(x => x.code.Contains(rounds.RoundsRounds[i].Matches[j].Team1.Code)).played++;
                                list.Find(x => x.code.Contains(rounds.RoundsRounds[i].Matches[j].Team2.Code)).played++;

                            }
                            else
                            {

                                if (away.rank > home.rank) list.Find(x => x.code.Contains(away.code)).pnts += 4;
                                else list.Find(x => x.code.Contains(away.code)).pnts += 3;

                                list.Find(x => x.code.Contains(rounds.RoundsRounds[i].Matches[j].Team1.Code)).played++;
                                list.Find(x => x.code.Contains(rounds.RoundsRounds[i].Matches[j].Team2.Code)).played++;
                            }
                        }

                    }







                }

            }



            
            foreach (var x in Friendslist)
            {
                // Friendslist[z].pnts += list.Find(x => x.code.Contains(Friendslist[z].teams[0])).pnts;
                // Friendslist[z].pnts += list.Find(x => x.code.Contains(Friendslist[z].teams[1])).pnts;
                // Friendslist[z].pnts += list.Find(x => x.code.Contains(Friendslist[z].teams[2])).pnts;
                // Friendslist[z].pnts += list.Find(x => x.code.Contains(Friendslist[z].teams[3])).pnts;
                // z++;
                x.pnts += list.Find(xw => xw.code.Contains(x.teams[0])).pnts;
                x.pnts += list.Find(xw => xw.code.Contains(x.teams[1])).pnts;
                x.pnts += list.Find(xw => xw.code.Contains(x.teams[2])).pnts;
                x.pnts += list.Find(xw => xw.code.Contains(x.teams[3])).pnts;
            }

        }//endd func

    }
}

