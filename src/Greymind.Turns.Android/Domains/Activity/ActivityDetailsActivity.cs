using System.Linq;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace Greymind.Turns.Android
{
    [Activity(Label = "Activity Details")]
    public class ActivityDetailsActivity : AppCompatActivity
    {
        private Activity activity;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.ActivityDetails);

            var toolbar = FindViewById<global::Android.Support.V7.Widget.Toolbar>(Resource.Id.Toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            var menuDrawable = GetDrawable(Resource.Drawable.ic_arrow_back_white_24dp);
            Helper.TintDrawable(Resources, menuDrawable);
            SupportActionBar.SetHomeAsUpIndicator(menuDrawable);

            var activityId = Intent.GetIntExtra("ActivityId", 0);

            activity = MainActivity.TurnsRepository.GetActivities()
                .Single(a => a.Id == activityId);

            var activityName = FindViewById<TextView>(Resource.Id.ActivityName);
            activityName.Text = activity.Name;

            var groupName = FindViewById<TextView>(Resource.Id.GroupName);
            groupName.Text = activity.Group.Name;

            var nextTurnPersonName = FindViewById<TextView>(Resource.Id.NextTurnPersonName);
            nextTurnPersonName.Text = $"Next turn: {activity.GetNextTurnPersonName()}";

            //
            var personTurnsRecyclerView = FindViewById<RecyclerView>(Resource.Id.PersonTurnsRecyclerView);
            {
                var layoutManager = new NoScrollLinearLayoutManager(ApplicationContext);
                personTurnsRecyclerView.SetLayoutManager(layoutManager);
            }

            var personTurnsAdapter = new PersonTurnsAdapter(MainActivity.TurnsRepository, activityId);
            personTurnsAdapter.ItemClick += (sender, turn) =>
            {
            };

            personTurnsRecyclerView.SetAdapter(personTurnsAdapter);

            //
            var turnsRecyclerView = FindViewById<RecyclerView>(Resource.Id.TurnRecyclerView);
            {
                var layoutManager = new NoScrollLinearLayoutManager(ApplicationContext);
                turnsRecyclerView.SetLayoutManager(layoutManager);
            }

            var turnAdapter = new TurnAdapter(MainActivity.TurnsRepository, activityId);
            turnAdapter.ItemClick += (sender, turn) =>
            {
            };

            turnsRecyclerView.SetAdapter(turnAdapter);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case global::Android.Resource.Id.Home:
                    OnBackPressed();
                    return true;
            }

            return base.OnOptionsItemSelected(item);
        }
    }
}