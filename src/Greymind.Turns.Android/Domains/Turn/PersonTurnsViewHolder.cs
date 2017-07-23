using System;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace Greymind.Turns.Android
{
    public class PersonTurnsViewHolder : RecyclerView.ViewHolder
    {
        public TextView PersonName { get; private set; }
        public TextView TurnsCount { get; private set; }

        public PersonTurnsViewHolder(View itemView, Action<int> listener)
            : base(itemView)
        {
            PersonName = itemView.FindViewById<TextView>(Resource.Id.PersonName);
            TurnsCount = itemView.FindViewById<TextView>(Resource.Id.TurnsCount);

            itemView.Click += (sender, e) => listener(Position);
        }
    }
}