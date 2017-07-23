using System;
using System.Linq;
using Android.Support.V7.Widget;
using Android.Views;

namespace Greymind.Turns.Android
{
    public class PersonTurnsAdapter : RecyclerView.Adapter
    {
        private readonly TurnsRepository turnsRepository;
        private readonly int activityId;

        private PersonTurns[] personTurns;

        public event EventHandler<PersonTurns> ItemClick;

        public override int ItemCount
            => personTurns.Length;

        public PersonTurnsAdapter(TurnsRepository turnsRepository, int activityId)
        {
            this.turnsRepository = turnsRepository;
            this.activityId = activityId;

            ReloadPersonTurns();
        }

        private void ReloadPersonTurns()
        {
            personTurns = turnsRepository.GetTurnsForActivity(activityId)
                .GroupBy(t => t.PersonId)
                .Select(g => new PersonTurns
                {
                    PersonName = turnsRepository.GetPerson(g.Key).Name,
                    TurnsCount = g.Count(),
                    LatestTurnTimestamp = g.Any()
                        ? g.Max(t => t.Timestamp)
                        : (DateTime?)null
                })
                .OrderByDescending(t => t.TurnsCount)
                .ThenByDescending(t => t.LatestTurnTimestamp)
                .ToArray();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context)
                .Inflate(Resource.Layout.PersonTurnCardView, parent, attachToRoot: false);

            var viewHolder = new PersonTurnsViewHolder(itemView,
                (position) => ItemClick?.Invoke(this, personTurns[position]));

            return viewHolder;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var viewHolder = holder as PersonTurnsViewHolder;

            var turn = personTurns[position];

            viewHolder.PersonName.Text = turn.PersonName;
            viewHolder.TurnsCount.Text = turn.TurnsCount.ToString();
        }
    }
}