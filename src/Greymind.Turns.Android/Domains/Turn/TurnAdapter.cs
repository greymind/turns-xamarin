using System;
using System.Linq;
using Android.Support.V7.Widget;
using Android.Views;

namespace Greymind.Turns.Android
{
    public class TurnAdapter : RecyclerView.Adapter
    {
        private readonly TurnsRepository turnsRepository;
        private readonly int activityId;

        private Turn[] turns;

        public event EventHandler<Turn> ItemClick;

        public override int ItemCount
            => turns.Length;

        public TurnAdapter(TurnsRepository turnsRepository, int activityId)
        {
            this.turnsRepository = turnsRepository;
            this.activityId = activityId;

            ReloadTurns();
        }

        private void ReloadTurns()
        {
            turns = turnsRepository.GetTurnsForActivity(activityId)
                .OrderByDescending(t => t.Timestamp)
                .ToArray();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context)
                .Inflate(Resource.Layout.TurnCardView, parent, attachToRoot: false);

            var viewHolder = new TurnViewHolder(itemView,
                (position) => ItemClick?.Invoke(this, turns[position]));

            return viewHolder;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var viewHolder = holder as TurnViewHolder;

            var turn = turns[position];

            viewHolder.PersonName.Text = turnsRepository.GetPerson(turn.PersonId).Name;
            viewHolder.Timestamp.Text = turn.Timestamp.ToShortDateString();
        }
    }
}