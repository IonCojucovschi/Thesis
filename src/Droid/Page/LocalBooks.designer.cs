using System;
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
    }
}
