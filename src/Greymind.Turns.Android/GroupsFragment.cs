using Android.OS;
using Android.Views;

namespace Greymind.Turns.Android
{
    public class GroupsFragment : global::Android.Support.V4.App.Fragment
    {
        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);

            var view = inflater.Inflate(Resource.Layout.GroupsFragment, null);
            return view;
        }
    }
}