using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Widget;
using Core.Models.DAL.CategoryBooks;
using Core.ViewModels.Library;
using Droid.Page.Base;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Droid.Factories.Adapter.RecyclerView;
using Int.Droid.Wrappers;
using Int.Core.Application.Widget.Contract.Table.Adapter;

namespace Droid.Page
{
    [Activity(Label = "CategoryBoocks",
        ScreenOrientation = ScreenOrientation.Portrait,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        Theme = "@style/AppTheme")]
    public partial class CategoryBoocks : NavigationBasePage<CategoryBooksViewModel>
    {
        protected override int LayoutContentResource => Resource.Layout.category_books_view;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            ListView.SetAdapter(ComponentAdapterRecyclerFactory.CreateAdapter((inflater, parent) =>
                                                                          new BooksCellViewHolder(inflater, parent, ModelView.CellModel)));

            // Create your application here
        }
    }
    public partial class CategoryBoocks
    {
        [CrossView(nameof(CategoryBooksViewModel.ListView))]
        [InjectView(Resource.Id.category_list)]
        public BaseRecyclerView ListView { get; set; }

    }


    public class BooksCellViewHolder : ComponentViewHolder<IBooklist>
    {
        public BooksCellViewHolder(LayoutInflater inflator, ViewGroup parent,
                                     ICrossCellViewHolder<IBooklist> cellModel)
            : base(inflator.Inflate(Resource.Layout.item_list_book, parent, false), cellModel) { }

        [CrossView(nameof(CategoryBooksViewModel.CategoryBookCell.TitleText))]
        [InjectView(Resource.Id.title_item)]
        public TextView TitleText { get; set; }

        [CrossView(nameof(CategoryBooksViewModel.CategoryBookCell.AuthorText))]
        [InjectView(Resource.Id.author_item)]
        public TextView AuthorText { get; set; }

        [CrossView(nameof(CategoryBooksViewModel.CategoryBookCell.DetailText))]
        [InjectView(Resource.Id.detail_item)]
        public TextView DetailText { get; set; }

        [CrossView(nameof(CategoryBooksViewModel.CategoryBookCell.BookImage))]
        [InjectView(Resource.Id.image_for_book_item)]
        public ImageView BookImage { get; set; }

        [CrossView(nameof(CategoryBooksViewModel.CategoryBookCell.CellContentRootView))]
        [InjectView(Resource.Id.cell_content_root_view)]
        public View CellContent { get; set; }



    }







}