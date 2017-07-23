using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace Greymind.Turns.Android
{
    public class GroupsViewHolder : RecyclerView.ViewHolder
    {
        public TextView GroupName { get; private set; }
        public TextView Members { get; private set; }

        public GroupsViewHolder(View itemView, Action<int> listener)
            : base(itemView)
        {
            GroupName = itemView.FindViewById<TextView>(Resource.Id.GroupName);
            Members = itemView.FindViewById<TextView>(Resource.Id.Members);

            itemView.Click += (sender, e) => listener(Position);
        }
    }
}