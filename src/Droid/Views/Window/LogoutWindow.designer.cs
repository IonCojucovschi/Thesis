using Android.Views;
using Android.Widget;
using Core.ViewModels.Window;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Droid.Wrappers;

namespace Droid.Views.Window
{
    partial class LogoutWindow
    {
        [InjectView(Resource.Id.background_view)]
        [CrossView(nameof(LogoutViewModel.BackgroundView))]
        public View BackgroundView { get; set; }

        [InjectView(Resource.Id.main_window_view)]
        [CrossView(nameof(LogoutViewModel.MainWindowView))]
        public View MainWindowView { get; set; }

        [InjectView(Resource.Id.label_message)]
        [CrossView(nameof(LogoutViewModel.LabelMessage))]
        public TextView LabelMessage { get; set; }

        [InjectView(Resource.Id.label_yes)]
        [CrossView(nameof(LogoutViewModel.LabelYes))]
        public TextView LabelYes { get; set; }

        [InjectView(Resource.Id.label_no)]
        [CrossView(nameof(LogoutViewModel.LabelNo))]
        public TextView LabelNo { get; set; }

        [InjectView(Resource.Id.logout_background_image_view)]
        [CrossView(nameof(LogoutViewModel.LogoutBackgroundImage))]
        public ImageView LogoutBackgorundImage { get; set; }

        [InjectView(Resource.Id.shadow_image_view)]
        [CrossView(nameof(LogoutViewModel.ShadowImage))]
        public ImageView ShadowImage { get; set;}
    }
}