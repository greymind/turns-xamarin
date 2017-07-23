using System;
using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using com.refractored;

namespace Greymind.Turns.Android
{
    [Activity(Label = "Turns", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity,
        ViewPager.IOnPageChangeListener
    {
        public static TurnsRepository TurnsRepository { get; set; }

        private ViewPager viewPager;
        private PagerSlidingTabStrip tabs;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            var toolbar = FindViewById<global::Android.Support.V7.Widget.Toolbar>(Resource.Id.Toolbar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            var menuDrawable = GetDrawable(Resource.Drawable.ic_menu_white_24dp);
            Helper.TintDrawable(Resources, menuDrawable);
            SupportActionBar.SetHomeAsUpIndicator(menuDrawable);

            var titles = new[] { "Activities", "Groups" };
            var adapter = new TabsFragmentPagerAdapter(SupportFragmentManager, titles);

            viewPager = FindViewById<ViewPager>(Resource.Id.ViewPager);
            viewPager.Adapter = adapter;

            viewPager.OffscreenPageLimit = titles.Length;
            viewPager.CurrentItem = 0;

            tabs = FindViewById<PagerSlidingTabStrip>(Resource.Id.Tabs);
            tabs.SetViewPager(viewPager);

            tabs.OnPageChangeListener = this;

            var fab = FindViewById<FloatingActionButton>(Resource.Id.Fab);
            fab.Click += (sender, e) =>
            {
                Snackbar
                    .Make(fab, "Here's a snackbar!", Snackbar.LengthLong)
                    .SetAction("Action", v => Console.WriteLine("Action handler"))
                    .Show();
            };

            TurnsRepository = new TurnsRepository();
            TurnsRepository.InitializeMockData();
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

            for (int i = 0; i < menu.Size(); i++)
            {
                var itemDrawable = menu.GetItem(i).Icon;
                Helper.TintDrawable(Resources, itemDrawable);
            }

            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case global::Android.Resource.Id.Home:
                    //drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
                    Toast.MakeText(this, "Home action selected", ToastLength.Short).Show();
                    return true;
            }

            Toast.MakeText(this, "Action selected: " + item.TitleFormatted, ToastLength.Short).Show();
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
            Toast.MakeText(this, "OnPageSelected selected: " + position, ToastLength.Short).Show();
        }
    }
}