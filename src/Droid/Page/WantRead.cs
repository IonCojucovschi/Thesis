using System.ComponentModel;
using Android.App;
using Android.Content.PM;
using Android.Views;
using Android.Widget;
using Core.Models.DAL.CategoryBooks;
using Core.ViewModels;
using Droid.Page.Base;
using Int.Core.Application.Widget.Contract.Table.Adapter;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Droid.Extensions;
using Int.Droid.Factories.Adapter.RecyclerView;
using Int.Droid.Wrappers;

namespace Droid.Page
{
    [Activity(Label = "Product",
        ScreenOrientation = ScreenOrientation.Portrait,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        Theme = "@style/AppTheme")]
    public partial class WantRead : NavigationBasePage<WantReadViewModel>
    {
        private const float ListHeaderHeight = 21.0f;
        protected override int LayoutContentResource => Resource.Layout.category_books_view;

        protected override void InitViews()
        {
            base.InitViews();

            ListView.SetAdapter(ComponentAdapterRecyclerFactory.CreateAdapter((inflater, parent) =>
                                                                          new BooksCellViewHolder(inflater, parent, ModelView.CellModel)));

            // Create your application here
        }
    }
    public class WishCellViewHolder : ComponentViewHolder<IBooklist>
    {
        public WishCellViewHolder(LayoutInflater inflator, ViewGroup parent,
                                     ICrossCellViewHolder<IBooklist> cellModel)
            : base(inflator.Inflate(Resource.Layout.item_list_book, parent, false), cellModel) { }

        [CrossView(nameof(WantReadViewModel.WishBookCell.TitleText))]
        [InjectView(Resource.Id.title_item)]
        public TextView TitleText { get; set; }

        [CrossView(nameof(WantReadViewModel.WishBookCell.AuthorText))]
        [InjectView(Resource.Id.author_item)]
        public TextView AuthorText { get; set; }

        [CrossView(nameof(WantReadViewModel.WishBookCell.DetailText))]
        [InjectView(Resource.Id.detail_item)]
        public TextView DetailText { get; set; }

        [CrossView(nameof(WantReadViewModel.WishBookCell.BookImage))]
        [InjectView(Resource.Id.image_for_book_item)]
        public FFImageLoading.Views.ImageViewAsync BookImage { get; set; }

        [CrossView(nameof(WantReadViewModel.WishBookCell.CellContentRootView))]
        [InjectView(Resource.Id.cell_content_root_view)]
        public View CellContent { get; set; }
    }
}