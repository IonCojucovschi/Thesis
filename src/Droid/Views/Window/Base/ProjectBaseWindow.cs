using Core;
using Core.ViewModels.Base;
using Int.Core.Data.MVVM.Contract;
using Int.Droid.Window;

namespace Droid.Views.Window.Base
{
    public abstract class ProjectBaseWindow<T> : BaseWindow where T : ProjectBaseViewModel
    {
        public override IBaseViewModel ModelView => App.Instance.GetView(typeof(T));

        public override void Show()
        {
            base.Show();
            (ModelView as ProjectBaseViewModel)?.UpdateData();
        }
    }
}