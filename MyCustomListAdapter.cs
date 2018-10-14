using Android.Views;
using Android.Widget;
using System.Collections.Generic;
using WorldCup18;
namespace WorldCup18
{
    public class MyCustomListAdapter : BaseAdapter<Users>
    {
         public IList<Users> friends;

        public MyCustomListAdapter(IList<Users> users1)
        {
            this.friends = users1;
        }

        public override Users this[int position]
        {
            get
            {
                return friends[position];
            }
        }

        public override int Count
        {
            get
            {
                return friends.Count;
            }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var view = convertView;

            if (view == null)
            {
                view = LayoutInflater.From(parent.Context).Inflate(Resource.Layout.userRow, parent, false);

                var photo = view.FindViewById<ImageView>(Resource.Id.photoImageView);
                var name = view.FindViewById<TextView>(Resource.Id.nameTextView);
                var department = view.FindViewById<TextView>(Resource.Id.departmentTextView);

                view.Tag = new ViewHolder() { Photo = photo, Name = name, Department = department };
            }

            var holder = (ViewHolder)view.Tag;

            holder.Photo.SetImageDrawable(ImageManager.Get(parent.Context, friends[position].ImageUrl));
            holder.Name.Text = friends[position].name;
            holder.Department.Text = friends[position].pnts.ToString();


            return view;

        }
    }
}