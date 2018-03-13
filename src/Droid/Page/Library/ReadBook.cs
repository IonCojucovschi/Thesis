
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
using Com.Joanzapata.Pdfview;

namespace Droid.Page
{
    [Activity(Label = "ReadBook", ScreenOrientation = ScreenOrientation.Portrait,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        Theme = "@style/AppTheme")]
    public partial class ReadBook : Activity////NavigationBasePage<ReadBookViewModel>
    {
        ///protected override int LayoutContentResource => Resource.Layout.read_book;
        private int totalPagesINT;
        private int curentPagesINT;

        public PDFView pdfView { get; set; }
        public RelativeLayout BottomWrapper { get; set; }
        public SeekBar ProgresPages { get; set; }
        public Button GoPageButton { get; set; }
        public EditText GoPagheText { get; set; }
        public TextView CurrentPage { get; set; }
        public TextView TotalPages { get; set; }



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.read_book);
                  
         
            GetPages();
            InitViews();

            //string url = RestConstants.BaseUrl + BooksManager.Instance._curentBook.download_linq;

            //BookView.LoadUrl(url);
            // Create your application here
        }

        private void InitViews()
        {

            if (pdfView != null)
            {
                curentPagesINT = pdfView.CurrentPage + 1;
                totalPagesINT = pdfView.PageCount + 1;
            }

            GoPageButton.SetBackgroundColor(Android.Graphics.Color.Blue);
            GoPagheText.Text = "";
            CurrentPage.Text =""+ curentPagesINT;
            TotalPages.Text = "" + totalPagesINT;
        }



        protected void GetPages()
        {

            pdfView = FindViewById<PDFView>(Resource.Id.read_book_view);
            BottomWrapper = FindViewById<RelativeLayout>(Resource.Id.bottomVrapperReadBook);
            ProgresPages = FindViewById<SeekBar>(Resource.Id.progressPage);
            GoPageButton = FindViewById<Button>(Resource.Id.goPageButton);
            GoPagheText = FindViewById<EditText>(Resource.Id.go_pageText);
            CurrentPage = FindViewById<TextView>(Resource.Id.curentPage);
            TotalPages = FindViewById<TextView>(Resource.Id.totalPages);

            ///load book into view 
            pdfView.FromAsset("Jamie_McGuire_-_Fericirea_mea_esti_tu.pdf").Load();



          }
    



    }
   

}
