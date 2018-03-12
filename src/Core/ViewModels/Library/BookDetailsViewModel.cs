using System;
using System.Collections.Generic;
using System.Text;
using Core.ViewModels.Base;
using Core.Models.DAL.CategoryBooks;
using Core.Helpers.Manager;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Core.Application.Widget.Contract;
using Core.Resources.Colors;
using Core.Helpers;
using Core.Resources.Drawables;
using Core.Services;

namespace Core.ViewModels.Library
{
    public class BookDetailsViewModel : ProjectNavigationBaseViewModel
    {
        protected override string HeaderText => "Detalii carte";
        protected override HeaderAreaActionType HeaderAreaAction => HeaderAreaActionType.LeftBack;
        public IBooklist curenBook;

        public override void UpdateData()
        {
            base.UpdateData();
            curenBook = BooksManager.Instance._curentBook;
            InitializeView();
        }

        [CrossView]
        public IImage BookImage { get; set; }

        [CrossView]
        public IText DownloadText { get; set; }

        [CrossView]
        public IText ReadText { get; set; }

        [CrossView]
        public IText TitleText { get; set; }

        [CrossView]
        public IText AuthorText { get; set; }

        [CrossView]
        public IText CategoryText { get; set; }

        [CrossView]
        public IText RatingText { get; set; }

        [CrossView]
        public IText NmbDownloadText { get; set; }

        [CrossView]
        public IText DescriptionText { get; set; }

        [CrossView]
        public IView ItemContentRootView { get; set; }


        private void InitializeView()
        {
            ItemContentRootView?.SetBackgroundColor(ColorConstants.WhiteColor, CornerRadiusBackground);
            ReadText.Click -= QuickReadBook;
            ReadText.Click += QuickReadBook;

            DownloadText.Click -= DownloadBook;
            DownloadText.Click += DownloadBook;

            if(BookImage!=null)
            {
                // to do download image from srv and show   it
            }

            if(ReadText!=null)
            {
                ReadText.SetTextColor(ColorConstants.WhiteColor);
                ReadText.SetFont(FontsConstant.MontserratMedium, FontsConstant.Size15);
                ReadText.SetBackgroundColor(ColorConstants.BlueColor, type: RadiusType.Aspect);
            }
            if(DownloadText != null)
            {
                DownloadText.SetTextColor(ColorConstants.WhiteColor);
                DownloadText.SetFont(FontsConstant.MontserratMedium, FontsConstant.Size15);
                DownloadText.SetBackgroundColor(ColorConstants.BlueColor, type: RadiusType.Aspect);
            }
            if (TitleText!=null)
            {
                TitleText.Text = curenBook?.title;
                TitleText.SetFont(FontsConstant.MontserratMedium, FontsConstant.Size15);
            }

            if (AuthorText != null)
            {
                AuthorText.Text = curenBook?.author;
                AuthorText.SetFont(FontsConstant.MontserratMedium, FontsConstant.Size15);
            }
            if (CategoryText != null)
            {
                CategoryText.Text = curenBook?.category;
                CategoryText.SetFont(FontsConstant.MontserratMedium, FontsConstant.Size15);
            }
            if (RatingText != null)
            {
                RatingText.Text = curenBook?.rating;
                RatingText.SetFont(FontsConstant.MontserratMedium, FontsConstant.Size15);
            }
            if (NmbDownloadText != null)
            {
                NmbDownloadText.Text = curenBook?.downloands_number;
                NmbDownloadText.SetFont(FontsConstant.MontserratMedium, FontsConstant.Size15);
            }
            if(DescriptionText!=null)
            {
                DescriptionText.Text = curenBook?.description;
                DescriptionText.SetFont(FontsConstant.MontserratMedium, FontsConstant.Size15);
            }

        }

        private void QuickReadBook(object sender,EventArgs e)
        {
            //there i use google service to open pdf file 
            string url = RestConstants.BaseUrl + BooksManager.Instance._curentBook.download_linq;
            this.OpenLink("http://docs.google.com/gview?embedded=true&url="+url);
        }
        private void DownloadBook(object sender, EventArgs e)
        {
            ///TO DO there must implemet code to download pdf filw


        }
    }
}
