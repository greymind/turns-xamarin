using System;
using Android.Support.V4.App;
using Java.Lang;

namespace Greymind.Turns.Android
{
    public class TabsFragmentPagerAdapter : FragmentPagerAdapter
    {
        private string[] Titles;

        public override int Count => Titles.Length;

        public TabsFragmentPagerAdapter(
            global::Android.Support.V4.App.FragmentManager manager,
            string[] titles)
            : base(manager)
        {
            Titles = titles;
        }

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            return new Java.Lang.String(Titles[position]);
        }

        public override global::Android.Support.V4.App.Fragment GetItem(int position)
        {
            switch (position)
            {
                case 0:
                    return new ActivityFragment();

                case 1:
                    return new GroupsFragment();

                default:
                    throw new NotSupportedException($"Position {position} is not supported!");
            }
        }
    }
}