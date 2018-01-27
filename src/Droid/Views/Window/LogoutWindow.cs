using Core.ViewModels.Window;
using Droid.Views.Window.Base;

namespace Droid.Views.Window
{
    public partial class LogoutWindow : ProjectBaseWindow<LogoutViewModel>
    {
        protected override int LayoutId => Resource.Layout.window_logout;
    }
}