using Android.App;
using Android.Widget;
using Android.OS;

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

            var groupsTab = ActionBar.NewTab();
            groupsTab.SetText("Groups");
            groupsTab.TabSelected += (sender, args) =>
            {

            };

            ActionBar.AddTab(groupsTab);

            var activityTab = ActionBar.NewTab();
            activityTab.SetText("Activity");
            activityTab.TabSelected += (sender, args) =>
            {

            };

            ActionBar.AddTab(activityTab);
        }
    }
}

