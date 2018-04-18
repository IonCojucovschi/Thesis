

using Android.App;
using Android.Content.PM;
using Core.ViewModels.Account;
using Droid.Page.Base;

namespace Droid.Page
{
    [Activity(Label = "AccountDescriptions",
        ScreenOrientation = ScreenOrientation.Portrait,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        Theme = "@style/AppTheme")]
    public partial class AccountDescriptions : NavigationBasePage<AccountDescriptionsViewModel>
    {
        protected override int LayoutContentResource => Resource.Layout.account_description;
    }
}