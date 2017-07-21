using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V4.View;
using System.Collections.Generic;
using System;

namespace Greymind.Turns.Android
{
    [Activity(Label = "Greymind Turns", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
            SetContentView(Resource.Layout.Main);

            var viewPager = FindViewById<ViewPager>(Resource.Id.viewpager);
            viewPager.Adapter = new TabsPagerAdapter(this);
            
            var groupsTab = ActionBar.NewTab();
            groupsTab.SetText("Groups");
            groupsTab.TabSelected += (sender, args) =>
            {
                viewPager.CurrentItem = 0;
            };

            ActionBar.AddTab(groupsTab);

            var activityTab = ActionBar.NewTab();
            activityTab.SetText("Activity");
            activityTab.TabSelected += (sender, args) =>
            {
                viewPager.CurrentItem = 1;
            };

            ActionBar.AddTab(activityTab);

            viewPager.PageSelected += (sender, args) =>
            {
                ActionBar.GetTabAt(args.Position).Select();
            };
        }
    }
}

