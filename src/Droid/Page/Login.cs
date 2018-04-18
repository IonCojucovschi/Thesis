using Android.App;
using Android.Content.PM;
using Core.ViewModels;
using Droid.Page.Base;

namespace Droid.Page
{
    [Activity(Label = "Login",
        ScreenOrientation = ScreenOrientation.Portrait,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        Theme = "@style/AppTheme")]
    public partial class Login : BasePage<LoginViewModel>
    {
        protected override int LayoutResource => Resource.Layout.login;

        public override void OnBackPressed()
        {
        }
    }
}