using Android.Views;
using Android.Widget;
using Core.ViewModels.Window;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Droid.Wrappers;

namespace Droid.Views.Window
{
    partial class ForgotPasswordWindow
    {
        [InjectView(Resource.Id.background_view)]
        [CrossView(nameof(ForgotPasswordViewModel.BackgroundView))]
        public View BackgroundView { get; set; }

        [InjectView(Resource.Id.main_window_view)]
        [CrossView(nameof(ForgotPasswordViewModel.MainWindowView))]
        public View MainWindowView { get; set; }

        [InjectView(Resource.Id.email_text)]
        [CrossView(nameof(ForgotPasswordViewModel.EmailEditText))]
        public EditText EmailEditText { get; set; }

        [InjectView(Resource.Id.email_underline)]
        [CrossView(nameof(ForgotPasswordViewModel.EmailUnderline))]
        public View EmailUnderline { get; set; }

        [InjectView(Resource.Id.label_cancel)]
        [CrossView(nameof(ForgotPasswordViewModel.LabelCancel))]
        public TextView LabelCancel { get; set; }

        [InjectView(Resource.Id.label_send)]
        [CrossView(nameof(ForgotPasswordViewModel.LabelSend))]
        public TextView LabelSend { get; set; }

        [InjectView(Resource.Id.shadow_image_view)]
        [CrossView(nameof(ForgotPasswordViewModel.ShadowImage))]
        public ImageView ShadowImage { get; set; }
    }
}