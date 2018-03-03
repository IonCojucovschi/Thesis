using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Android.Widget;
using Core.Models.DAL.CategoryBooks;
using Core.ViewModels.Library;
using Droid.Page.Base;
using Int.Core.Application.Widget.Contract.Table.Adapter;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Droid.Factories.Adapter.RecyclerView;
using Int.Droid.Wrappers;

namespace Droid.Page
{
    
    [Activity(Label = "Library",
              ScreenOrientation = ScreenOrientation.Portrait,MainLauncher = false,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        Theme = "@style/AppTheme")]
    public partial class Library_base : NavigationBasePage<LibraryViewModel>
    {
        protected override int LayoutContentResource =>Resource.Layout.category_books_view ;

        protected override void InitViews()
        {
            base.InitViews();

            ListView.SetAdapter(ComponentAdapterRecyclerFactory.CreateAdapter((inflater, parent) =>
                                                                             new LybraryCellViewHolder(inflater,
                                               parent,
                                               ModelView.CellModel)));
        }

        public override void OnBackPressed() { }
       
    }
    public partial class Library_base
    {
        [CrossView(nameof(LibraryViewModel.ListView))]
        [InjectView(Resource.Id.category_list)]
        public BaseRecyclerView ListView { get; set; }
    }


    public class LybraryCellViewHolder : ComponentViewHolder<ICategoryContent>
    {
        public LybraryCellViewHolder(LayoutInflater inflator, ViewGroup parent,
                                     ICrossCellViewHolder<ICategoryContent> cellModel)
            : base(inflator.Inflate(Resource.Layout.item_list_category_boock, parent, false), cellModel) { }

        [CrossView(nameof(LibraryViewModel.LibraryCell.CategoryText))]
        [InjectView(Resource.Id.category_name_item)]
        public TextView CategoryText { get; set; }

        [CrossView(nameof(LibraryViewModel.LibraryCell.QuantityText))]
        [InjectView(Resource.Id.category_quantity_item)]
        public TextView QuantityText { get; set; }

        [CrossView(nameof(LibraryViewModel.LibraryCell.CellContentRootView))]
        [InjectView(Resource.Id.category_item_content)]
        public View CellContent { get; set; }
    }





}