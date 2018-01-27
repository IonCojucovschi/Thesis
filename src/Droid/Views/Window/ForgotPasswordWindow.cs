using Core.ViewModels.Window;
using Droid.Views.Window.Base;

namespace Droid.Views.Window
{
    public partial class ForgotPasswordWindow : ProjectBaseWindow<ForgotPasswordViewModel>
    {
        protected override int LayoutId => Resource.Layout.window_forgot_password;
    }
}