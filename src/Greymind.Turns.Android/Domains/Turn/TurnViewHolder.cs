using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace Greymind.Turns.Android
{
    public class TurnViewHolder : RecyclerView.ViewHolder
    {
        public TextView PersonName { get; private set; }
        public TextView Timestamp { get; private set; }

        public TurnViewHolder(View itemView, Action<int> listener)
            : base(itemView)
        {
            PersonName = itemView.FindViewById<TextView>(Resource.Id.PersonName);
            Timestamp = itemView.FindViewById<TextView>(Resource.Id.Timestamp);

            itemView.Click += (sender, e) => listener(Position);
        }
    }
}