
using Android.App;
using Android.Content.PM;
using Core.ViewModels;
using Droid.Page.Base;

namespace Droid.Page
{
    [Activity(Label = "Dashboard",
        ScreenOrientation = ScreenOrientation.Portrait,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        Theme = "@style/AppTheme")]
    public partial class Dashboard : NavigationBasePage<DashboardViewModel>
    {
        protected override int LayoutContentResource => Resource.Layout.item_dashboard;

        public override void OnBackPressed()
        {
        }
    }
}