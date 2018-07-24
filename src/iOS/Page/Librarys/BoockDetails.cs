using Core.ViewModels.Library;
using Foundation;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using iOS.Page.BasePage;
using System;
using UIKit;
using Newtonsoft.Json.Serialization;

namespace iOS.Storyboard
{
    public partial class BoockDetails : BasePageSideMenu<BookDetailsViewModel>
    {
        public BoockDetails(IntPtr handle) : base(handle) { }

        [CrossView(nameof(BookDetailsViewModel.BookImage))]
        UIImageView prop1 => bookImage;

        [CrossView(nameof(BookDetailsViewModel.DownloadText))]
        UILabel downloadB => downloadButton;

        [CrossView(nameof(BookDetailsViewModel.ReadText))]
        UILabel redB => readButton;

        [CrossView(nameof(BookDetailsViewModel.TitleText))]
        UILabel prrop2 => titleText;

        [CrossView(nameof(BookDetailsViewModel.AuthorText))]
        UILabel prrop3 => authorText;

        [CrossView(nameof(BookDetailsViewModel.CategoryText))]
        UILabel prrop4 => categoryText;

        [CrossView(nameof(BookDetailsViewModel.NmbDownloadText))]
        UILabel proop5 => downloadsText;

        [CrossView(nameof(BookDetailsViewModel.RatingText))]
        UILabel prrop6 => ratingText;

        [CrossView(nameof(BookDetailsViewModel.DescriptionText))]
        UITextView prop7 => descriptionText;

    }
}