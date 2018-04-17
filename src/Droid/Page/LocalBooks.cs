
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
using Core.Helpers.Manager;
using Java.IO;

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
            LoadLocalBooks();
            // Create your application here
        }
        LocalBooksManager bookManger=new LocalBooksManager();
        string pathDIR = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath.ToString();//Android.App.Application.Context.FilesDir.AbsolutePath.ToString();
        private void LoadLocalBooks()
        {
            var books = bookManger.GetAllBooksListFromDevidce(new File(pathDIR), pathDIR);
            string dir = "some text";
        }



    }
}
