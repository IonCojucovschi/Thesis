using System;
using Android.Widget;
using Core.ViewModels.Library;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Droid.Factories.Adapter.RecyclerView;
using Int.Droid.Wrappers;

namespace Droid.Page
{
    public partial class LocalBooks
    {
        [CrossView(nameof(LocalBooksViewModel.ListView))]
        [InjectView(Resource.Id.category_list)]
        public BaseRecyclerView ListView { get; set; }

        [CrossView(nameof(LocalBooksViewModel.RefreshButton))]
        [InjectView(Resource.Id.improspateaza_lista)]
        public TextView RefreshButton { get; set; }

        [CrossView(nameof(LocalBooksViewModel.DeleteButton))]
        [InjectView(Resource.Id.sterge_lista)]
        public TextView DeleteButton { get; set; }
    }
}
