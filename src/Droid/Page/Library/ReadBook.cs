
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
using System.Timers;
using Android.Support.V7.App;
using static Android.Widget.SeekBar;

namespace Droid.Page
{
    [Activity(Label = "ReadBook", ScreenOrientation = ScreenOrientation.Portrait,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        Theme = "@style/AppTheme")]
    public partial class ReadBook : AppCompatActivity, IOnSeekBarChangeListener////NavigationBasePage<ReadBookViewModel>
    {
        ///protected override int LayoutContentResource => Resource.Layout.read_book;
        private static int totalPagesINT;
        private static int curentPagesINT;

        public PDFView pdfView { get; set; }
        public RelativeLayout BottomWrapper { get; set; }
        public SeekBar seekBar { get; set; }
        //public Button GoPageButton { get; set; }
        //public EditText GoPagheText { get; set; }
        public TextView CurrentPage { get; set; }
        public TextView TotalPages { get; set; }

        private Timer WhenMakeElementsInvisible;

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


            //GoPageButton.SetBackgroundColor(Android.Graphics.Color.Blue);
            //GoPagheText.Text = "";
            CurrentPage.Text =""+ curentPagesINT;
            TotalPages.Text = "" + totalPagesINT;
        }



        protected void GetPages()
        {

            pdfView = FindViewById<PDFView>(Resource.Id.read_book_view);
            BottomWrapper = FindViewById<RelativeLayout>(Resource.Id.bottomVrapperReadBook);
            seekBar = FindViewById<SeekBar>(Resource.Id.progressPage);
            //GoPageButton = FindViewById<Button>(Resource.Id.goPageButton);
            //GoPagheText = FindViewById<EditText>(Resource.Id.go_pageText);
            CurrentPage = FindViewById<TextView>(Resource.Id.curentPage);
            TotalPages = FindViewById<TextView>(Resource.Id.totalPages);

            ///load book into view 

            pdfView.FromAsset("Jamie_McGuire_-_Fericirea_mea_esti_tu.pdf").Load();
            pdfView.Click -= WhenBookIsLoaded;
            pdfView.Click += WhenBookIsLoaded;


            seekBar.SetOnSeekBarChangeListener(this);
            //GoPageButton.Click -= GoToLoadInputPage;
            //GoPageButton.Click += GoToLoadInputPage;
          }
    
        private void WhenBookIsLoaded(object sender,EventArgs e)
        {
            if (pdfView != null)
            {
                curentPagesINT = pdfView.CurrentPage + 1;
                totalPagesINT = pdfView.PageCount + 1;
            }
            CurrentPage.Text = "" + curentPagesINT;
            TotalPages.Text = "" + totalPagesINT;

            WhenMakeElementsInvisible = new Timer();
            WhenMakeElementsInvisible.Interval = 4000;/// 4 sec
            WhenMakeElementsInvisible.AutoReset = false;
            WhenMakeElementsInvisible.Elapsed -= MakeInvisible_Visible;
            WhenMakeElementsInvisible.Elapsed += MakeInvisible_Visible;
            WhenMakeElementsInvisible.Start();

         }

        private void MakeInvisible_Visible(object sender, EventArgs e)
        {
            //if(GoPageButton.Visibility == ViewStates.Visible)
            //{
            //    GoPageButton.Visibility = ViewStates.Invisible;
            //}
            //else
            //{
            //    GoPageButton.Visibility = ViewStates.Visible;
            //    GoPageButton.SetBackgroundColor(Android.Graphics.Color.Blue);
            //}

        }



        //private void GoToLoadInputPage(object sender,EventArgs e)
        //{
        //    if (pdfView != null)
        //    {
        //        curentPagesINT = pdfView.CurrentPage + 1;
        //        totalPagesINT = pdfView.PageCount + 1;
        //    }
           
        //    if(GoPagheText.Text!="")
        //    {
        //        var inpPage = Convert.ToInt32(GoPagheText.Text);
        //        pdfView.FromAsset("Jamie_McGuire_-_Fericirea_mea_esti_tu.pdf").DefaultPage(inpPage).Load();

        //        curentPagesINT = pdfView.CurrentPage + 1;
        //        totalPagesINT = pdfView.PageCount + 1;
        //        CurrentPage.Text = "" + curentPagesINT;

        //    }else{
        //        TotalPages.Text = "" + totalPagesINT;
        //        CurrentPage.Text = "" + curentPagesINT;

        //    }
        
        //}

        public void OnProgressChanged(SeekBar seekBar, int progress, bool fromUser)
        {
            if(progress<pdfView.PageCount)
            {
                CurrentPage.Text = "" + progress;
            }
        }
        private async void GoPage(int progress)
        {
            pdfView.FromAsset("Jamie_McGuire_-_Fericirea_mea_esti_tu.pdf").DefaultPage(progress).Load();
        }

        public void OnStartTrackingTouch(SeekBar seekBar)
        {
            seekBar.Max = pdfView.PageCount;
            CurrentPage.Text = pdfView.CurrentPage + "";
            TotalPages.Text = seekBar.Max+"";
        }

        public void OnStopTrackingTouch(SeekBar seekBar)
        {
            GoPage(Convert.ToInt32(CurrentPage.Text));

        }
    }
   

}
