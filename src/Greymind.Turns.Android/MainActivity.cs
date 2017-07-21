using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V4.View;
using System.Collections.Generic;
using System;
using com.refractored;
using Android.Util;
using Android.Support.V7.App;

namespace Greymind.Turns.Android
{
    [Activity(Label = "Greymind Turns", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/Theme.AppCompat.Light")]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            //var toolbar = FindViewById<Toolbar>(Resource.Id.Toolbar);
            //SetActionBar(toolbar);

            //ActionBar.SetTitle(Resource.String.ApplicationName);

            var titles = new[] { "Groups", "Activity" };
            var adapter = new TabsFragmentPagerAdapter(SupportFragmentManager, titles);

            var viewPager = FindViewById<ViewPager>(Resource.Id.ViewPager);
            viewPager.PageMargin = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 4, Resources.DisplayMetrics);
            viewPager.OffscreenPageLimit = titles.Length;
            viewPager.Adapter = adapter;
            viewPager.CurrentItem = 0;

            var tabs = FindViewById<PagerSlidingTabStrip>(Resource.Id.Tabs);
            tabs.SetViewPager(viewPager);
        }
    }
}

