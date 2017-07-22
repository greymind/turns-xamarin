using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V4.View;
using System.Collections.Generic;
using System;
using com.refractored;
using Android.Util;
using Android.Support.V7.App;
using Android.Graphics.Drawables;
using Android.Graphics;
using Android.Views;

namespace Greymind.Turns.Android
{
    [Activity(Label = "Turns", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity,
        ViewPager.IOnPageChangeListener
    {
        private ViewPager viewPager;
        private PagerSlidingTabStrip tabs;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            var toolbar = FindViewById<global::Android.Support.V7.Widget.Toolbar>(Resource.Id.Toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.ic_menu_white_24dp);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            var titles = new[] { "Activities", "Groups" };
            var adapter = new TabsFragmentPagerAdapter(SupportFragmentManager, titles);

            viewPager = FindViewById<ViewPager>(Resource.Id.ViewPager);
            viewPager.Adapter = adapter;

            viewPager.OffscreenPageLimit = titles.Length;
            viewPager.CurrentItem = 0;

            tabs = FindViewById<PagerSlidingTabStrip>(Resource.Id.Tabs);
            tabs.SetViewPager(viewPager);

            tabs.OnPageChangeListener = this;
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
        }

        protected override void OnRestoreInstanceState(Bundle savedInstanceState)
        {
            base.OnRestoreInstanceState(savedInstanceState);
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.TopMenu, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case global::Android.Resource.Id.Home:
                    //drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
                    Toast.MakeText(this, "Home action selected",
                        ToastLength.Short).Show();
                    return true;
            }

            Toast.MakeText(this, "Action selected: " + item.TitleFormatted,
                ToastLength.Short).Show();
            return base.OnOptionsItemSelected(item);
        }

        public void OnPageScrollStateChanged(int state)
        {

        }

        public void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels)
        {

        }

        public void OnPageSelected(int position)
        {
            Toast.MakeText(this, "OnPageSelected selected: " + position,
                ToastLength.Short).Show();
        }
    }
}

