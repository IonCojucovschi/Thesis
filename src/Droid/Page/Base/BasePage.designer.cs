using Android.Views;
using Core.ViewModels.Base;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Droid.Wrappers;

namespace Droid.Page.Base
{
    partial class BasePage<TViewModel>
    {
        [CrossView(nameof(ProjectBaseViewModel.RootView))]
        [InjectView(Resource.Id.root_view)]
        public virtual View RootView { get; set; }
    }
}