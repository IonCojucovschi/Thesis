using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Widget;
using Droid.Page.Base;
using Core.ViewModels.Library;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Droid.Wrappers;
using Android.Views;
using Com.Bumptech.Glide;
using Core.Services;
using Core.Helpers.Manager;

namespace Droid.Page
{
    [Activity(Label = "BoockDetails",
        ScreenOrientation = ScreenOrientation.Portrait,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        Theme = "@style/AppTheme")]
    public partial class BoockDetails : NavigationBasePage<BookDetailsViewModel>
    {
        protected override int LayoutContentResource => Resource.Layout.boock_view;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
        }
        protected override void InitViews()
        {
            base.InitViews();

            if (BookImage != null)
            {
                string download_imageurl = RestConstants.BaseUrl + BooksManager.Instance._curentBook.download_linq;
                Glide.With(this)
                     .Load(download_imageurl)
                     .CenterCrop()
                     .Into(BookImage);
            }
        }
    }

    public partial class BoockDetails
    {
        [CrossView(nameof(BookDetailsViewModel.BookImage))]
        [InjectView(Resource.Id.book_image_view)]
        public ImageView BookImage { get; set; }

        [CrossView(nameof(BookDetailsViewModel.DownloadText))]
        [InjectView(Resource.Id.download_book)]
        public TextView DownloadText { get; set; }

        [CrossView(nameof(BookDetailsViewModel.ReadText))]
        [InjectView(Resource.Id.read_book)]
        public TextView ReadText { get; set; }

        [CrossView(nameof(BookDetailsViewModel.TitleText))]
        [InjectView(Resource.Id.title_book_view)]
        public TextView TitleText { get; set; }

        [CrossView(nameof(BookDetailsViewModel.AuthorText))]
        [InjectView(Resource.Id.author_book_view)]
        public TextView AuthorText { get; set; }

        [CrossView(nameof(BookDetailsViewModel.CategoryText))]
        [InjectView(Resource.Id.category_book_view)]
        public TextView CategoryText { get; set; }

        [CrossView(nameof(BookDetailsViewModel.RatingText))]
        [InjectView(Resource.Id.rating_book_view)]
        public TextView RatingText { get; set; }

        [CrossView(nameof(BookDetailsViewModel.NmbDownloadText))]
        [InjectView(Resource.Id.downloads_book_view)]
        public TextView NmbDownloadText { get; set; }

        [CrossView(nameof(BookDetailsViewModel.DescriptionText))]
        [InjectView(Resource.Id.description_book_view)]
        public TextView DescriptionText { get; set; }

        [CrossView(nameof(BookDetailsViewModel.ItemContentRootView))]
        [InjectView(Resource.Id.detail_item_wrapper)]
        public View ItemContentRootView { get; set; }

    }

}