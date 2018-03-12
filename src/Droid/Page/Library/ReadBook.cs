
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
using Android.Webkit;
using Android.Widget;
using Core.Helpers.Manager;
using Core.Services;
using Core.ViewModels.Library;
using Droid.Page.Base;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Droid.Wrappers;

namespace Droid.Page
{
    [Activity(Label = "ReadBook", ScreenOrientation = ScreenOrientation.Portrait,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        Theme = "@style/AppTheme")]
    public partial class ReadBook : NavigationBasePage<ReadBookViewModel>
    {
        protected override int LayoutContentResource => Resource.Layout.read_book;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
             
            string url = RestConstants.BaseUrl + BooksManager.Instance._curentBook.download_linq;

            BookView.LoadUrl(url);
            // Create your application here
        }
    }
    public partial class ReadBook
    {
       // [CrossView(nameof(ReadBookViewModel.BookView))]
        [InjectView(Resource.Id.read_book_view)]
        public WebView BookView { get; set; }

    }



}
