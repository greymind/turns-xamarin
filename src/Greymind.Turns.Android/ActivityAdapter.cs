using System;
using Android.Support.V7.Widget;
using Android.Views;

namespace Greymind.Turns.Android
{
    public class ActivityAdapter : RecyclerView.Adapter
    {
        private readonly TurnsRepository turnsRepository;
        private Activity[] activities;

        public event EventHandler<int> ItemClick;

        public override int ItemCount
            => activities.Length;

        public ActivityAdapter(TurnsRepository turnsRepository)
        {
            this.turnsRepository = turnsRepository;
            ReloadActivities();
        }

        private void ReloadActivities()
        {
            activities = turnsRepository.GetActivities();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context)
                .Inflate(Resource.Layout.ActivityCardView, parent, attachToRoot: false);

            var viewHolder = new ActivityViewHolder(itemView, (position) => ItemClick?.Invoke(this, position));

            return viewHolder;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var viewHolder = holder as ActivityViewHolder;

            viewHolder.ActivityName.Text = activities[position].Name;
            viewHolder.GroupName.Text = activities[position].Group.Name;
        }
    }
}