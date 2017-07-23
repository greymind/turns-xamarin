using System;
using System.Linq;
using Android.Support.V7.Widget;
using Android.Views;

namespace Greymind.Turns.Android
{
    public class GroupsAdapter : RecyclerView.Adapter
    {
        private readonly TurnsRepository turnsRepository;
        private Group[] groups;

        public event EventHandler<int> ItemClick;

        public override int ItemCount
            => groups.Length;

        public GroupsAdapter(TurnsRepository turnsRepository)
        {
            this.turnsRepository = turnsRepository;
            ReloadGroups();
        }

        private void ReloadGroups()
        {
            groups = turnsRepository.GetGroups();
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            var itemView = LayoutInflater.From(parent.Context)
                .Inflate(Resource.Layout.GroupsCardView, parent, attachToRoot: false);

            var viewHolder = new GroupsViewHolder(itemView, (position) => ItemClick?.Invoke(this, position));

            return viewHolder;
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            var viewHolder = holder as GroupsViewHolder;

            viewHolder.GroupName.Text = groups[position].Name;
            viewHolder.Members.Text = string.Join(", ", groups[position].Members.Select(m => m.Name));
        }
    }
}