
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
using Android.Views.Animations;

namespace Droid.Page
{
    [Activity(Label = "ReadBook", 
              Theme = "@style/AppTheme")]
    public partial class ReadBook : Activity, IOnSeekBarChangeListener
    {
        
        private static int totalPagesINT;
        private static int curentPagesINT;
        private bool IsOpenedCounder=false;
        public PDFView pdfView { get; set; }
        public LinearLayout BottomWrapper { get; set; }
        public SeekBar seekBar { get; set; }
        public TextView CurrentPage { get; set; }
        public TextView TotalPages { get; set; }


        private float diplayHeightvar;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.read_book);

            diplayHeightvar = Resources.DisplayMetrics.HeightPixels; /// Resources.DisplayMetrics.Density;

            InitViews();
            GetPages();

            //string url = RestConstants.BaseUrl + BooksManager.Instance._curentBook.download_linq;

            //BookView.LoadUrl(url);
            /////pdfView.FromFile(file with pdf)
            // Create your application here
        }

        private void GetPages()
        {

            //pdfView.FromAsset("Jamie_McGuire_-_Fericirea_mea_esti_tu.pdf").Load();
            pdfView.FromFile(LocalBooksManager.Instance.CurentBook.FileContent).DefaultPage(LocalBooksManager.Instance.CurentBook.LastPage+1).Load();
      

            CurrentPage.Text =""+ curentPagesINT;
            TotalPages.Text = "" + totalPagesINT;
            seekBar.SetOnSeekBarChangeListener(this);

            pdfView.Click -= WhenBookIsLoaded;
            pdfView.Click += WhenBookIsLoaded;
        }



        protected void InitViews()
        {

            pdfView = FindViewById<PDFView>(Resource.Id.read_book_view);
            seekBar = FindViewById<SeekBar>(Resource.Id.progressPage);
            CurrentPage = FindViewById<TextView>(Resource.Id.curentPage);
            TotalPages = FindViewById<TextView>(Resource.Id.totalPages);
            BottomWrapper = FindViewById<LinearLayout>(Resource.Id.pagewrapperCounter);
            ///load book into view 
                      
          }
    
        private void WhenBookIsLoaded(object sender,EventArgs e)
        {
            //if(IsOpenedCounder)
            //{
            //    Animation anim=AnimationUtils.LoadAnimation(this,Resource.Animation.top_to_bottom);
            //    BottomWrapper.StartAnimation(anim);
            //    IsOpenedCounder = false;
            //}
            //else
            //{
            //    Animation anim = AnimationUtils.LoadAnimation(this, Resource.Animation.bottom_to_top);
            //    BottomWrapper.StartAnimation(anim);
            //    IsOpenedCounder = true;
            //}
            if (IsOpenedCounder)
            {
                BottomWrapper.SetY(0);
                IsOpenedCounder = false;
            }
            else
            {
                BottomWrapper.SetY(-160);
                IsOpenedCounder = true;
            }


            if (pdfView != null)
            {
                curentPagesINT = pdfView.CurrentPage + 1;
                totalPagesINT = pdfView.PageCount + 1;
            }
            CurrentPage.Text = "" + curentPagesINT;
            TotalPages.Text = "" + totalPagesINT;


         }


        public void OnProgressChanged(SeekBar seekBar, int progress, bool fromUser)
        {
            if(progress<pdfView.PageCount)
            {
                CurrentPage.Text = "" + progress;
            }
        }
        private async void GoPage(int progress)
        {
            var itm = LocalBooksManager.Instance.CurentBook;
            itm.LastPage = curentPagesINT;
            LocalBooksManager.Instance.UpdateLocalBook(itm);
            ///pdfView.FromAsset("Jamie_McGuire_-_Fericirea_mea_esti_tu.pdf").DefaultPage(progress).Load();
            pdfView.FromFile(LocalBooksManager.Instance.CurentBook.FileContent).DefaultPage(progress).Load();
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
