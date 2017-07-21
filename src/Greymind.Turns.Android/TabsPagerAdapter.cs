using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.V4.View;
using Java.Lang;

namespace Greymind.Turns.Android
{
    public class TabsPagerAdapter : PagerAdapter
    {
        private Context context;
        private string[] tabs;

        public override int Count => tabs.Length;

        public TabsPagerAdapter(Context context)
        {
            this.context = context;
            this.tabs = new[] { "Groups", "Activity" };
        }

        public override bool IsViewFromObject(View view, Java.Lang.Object @object)
        {
            return view == @object;
        }

        public override Java.Lang.Object InstantiateItem(ViewGroup container, int position)
        {
            var view = new TextView(context);
            view.SetText(tabs[position], TextView.BufferType.Normal);
            var viewPager = container.JavaCast<ViewPager>();
            viewPager.AddView(view);
            return view;
        }

        public override void DestroyItem(ViewGroup container, int position, Java.Lang.Object view)
        {
            var viewPager = container.JavaCast<ViewPager>();
            viewPager.RemoveView(view as View);
        }
    }
}