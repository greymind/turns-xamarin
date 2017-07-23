using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace Greymind.Turns.Android
{
    public class ActivityViewHolder : RecyclerView.ViewHolder
    {
        public TextView ActivityName { get; private set; }
        public TextView GroupName { get; private set; }

        public ActivityViewHolder(View itemView, Action<int> listener)
            : base(itemView)
        {
            ActivityName = itemView.FindViewById<TextView>(Resource.Id.ActivityName);
            GroupName = itemView.FindViewById<TextView>(Resource.Id.GroupName);

            itemView.Click += (sender, e) => listener(Position);
        }
    }
}