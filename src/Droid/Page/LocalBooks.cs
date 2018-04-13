
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Core.ViewModels.Library;
using Droid.Page.Base;

namespace Droid.Page
{
    [Activity(Label = "LocalBooks",
              ScreenOrientation = ScreenOrientation.Portrait, MainLauncher = false,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        Theme = "@style/AppTheme")]
    public partial class LocalBooks : NavigationBasePage<LibraryViewModel>
    {
        protected override int LayoutContentResource =>Resource.Layout.category_books_view;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }
    }
}
