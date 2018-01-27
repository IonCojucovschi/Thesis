using Android.App;
using Core;
using Core.ViewModels.Base;
using Int.Droid.Factories.Activity;

namespace Droid.Page.Base
{
    [Activity(Label = "", Icon = "@mipmap/icon")]
    public abstract partial class BasePage<TViewModel> :
        ComponentMVVMActivity<TViewModel> where TViewModel : ProjectBaseViewModel
    {
        protected override TViewModel ModelView => App.Instance.GetView(typeof(TViewModel)) as TViewModel;

        protected override void FindViews()
        {
        }

        protected override void HandlerViews()
        {
        }

        protected override void RemoveHandlerViews()
        {
        }

        protected override void TranslateViews()
        {
        }
    }
}