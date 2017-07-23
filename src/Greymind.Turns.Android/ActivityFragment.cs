﻿using Android.OS;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;

namespace Greymind.Turns.Android
{
    public class ActivityFragment : global::Android.Support.V4.App.Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.ActivityFragment, null);

            var recyclerView = view.FindViewById<RecyclerView>(Resource.Id.RecyclerView);
            var layoutManager = new LinearLayoutManager(view.Context);

            recyclerView.SetLayoutManager(layoutManager);

            var activityAdapter = new ActivityAdapter(MainActivity.TurnsRepository);
            activityAdapter.ItemClick += (sender, position) =>
            {
                Toast
                    .MakeText(view.Context, $"Position: {position}", ToastLength.Short)
                    .Show();
            };

            recyclerView.SetAdapter(activityAdapter);

            return view;
        }
    }
}