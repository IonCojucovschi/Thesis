using Android.App;
using Android.Content.PM;
using Core.ViewModels;
using Droid.Page.Base;

namespace Droid.Page
{
    [Activity(MainLauncher = true,
        ScreenOrientation = ScreenOrientation.Portrait,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        Theme = "@style/SplashTheme")]
    public partial class Splash : BasePage<SplashViewModel>
    {
        protected override int LayoutResource => Resource.Layout.splash;

        public override void OnBackPressed()
        {
        }
    }
}