﻿using Android.App;
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
        IOnTabReselectedListener
    {
        //private MyPagerAdapter adapter;
        private ViewPager viewPager;
        private PagerSlidingTabStrip tabs;

        private Drawable oldBackground = null;
        private int currentColor;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.Main);

            var toolbar = FindViewById<global::Android.Support.V7.Widget.Toolbar>(Resource.Id.Toolbar);
            SetSupportActionBar(toolbar);

            var titles = new[] { "Groups", "Activity" };
            var adapter = new TabsFragmentPagerAdapter(SupportFragmentManager, titles);

            viewPager = FindViewById<ViewPager>(Resource.Id.ViewPager);
            viewPager.Adapter = adapter;

            viewPager.PageMargin = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 4, Resources.DisplayMetrics);
            viewPager.OffscreenPageLimit = titles.Length;
            viewPager.CurrentItem = 0;

            tabs = FindViewById<PagerSlidingTabStrip>(Resource.Id.Tabs);
            tabs.SetViewPager(viewPager);

            tabs.OnTabReselectedListener = this;

            ChangeColor(Resources.GetColor(Resource.Color.green));

            SupportActionBar.SetDisplayHomeAsUpEnabled(false);
            SupportActionBar.SetHomeButtonEnabled(false);
        }

        public void OnTabReselected(int position)
        {
            Toast.MakeText(this, "Tab reselected: " + position, ToastLength.Short).Show();
        }

        private void ChangeColor(Color newColor)
        {
            tabs.SetBackgroundColor(newColor);

            // change ActionBar color just if an ActionBar is available
            var colorDrawable = new ColorDrawable(newColor);
            var bottomDrawable = new ColorDrawable(Color.Transparent);
            var layerDrawable = new LayerDrawable(new[] { colorDrawable, bottomDrawable });

            if (oldBackground == null)
            {
                SupportActionBar.SetBackgroundDrawable(layerDrawable);
            }
            else
            {
                var td = new TransitionDrawable(new[] { oldBackground, layerDrawable });
                SupportActionBar.SetBackgroundDrawable(td);
                td.StartTransition(200);
            }

            oldBackground = layerDrawable;
            currentColor = newColor;
        }

        [Java.Interop.Export("onColorClicked")]
        public void OnColorClicked(View v)
        {
            var color = Color.ParseColor(v.Tag.ToString());
            ChangeColor(color);
        }

        protected override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            outState.PutInt("currentColor", currentColor);
        }

        protected override void OnRestoreInstanceState(Bundle savedInstanceState)
        {
            base.OnRestoreInstanceState(savedInstanceState);
            currentColor = savedInstanceState.GetInt("currentColor");
            ChangeColor(new Color(currentColor));
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.TopMenus, menu);
            return base.OnCreateOptionsMenu(menu);
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            Toast.MakeText(this, "Action selected: " + item.TitleFormatted,
                ToastLength.Short).Show();
            return base.OnOptionsItemSelected(item);
        }
    }
}

