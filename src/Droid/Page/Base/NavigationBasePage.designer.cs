using Android.Support.V4.Widget;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Core.ViewModels.Base;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Droid.Wrappers;

namespace Droid.Page.Base
{
    partial class NavigationBasePage<TViewModel>
    {
        [CrossView(nameof(ProjectBaseViewModel.RootView))]
        [InjectView(Resource.Id.main_content)]
        public override View RootView { get; set; }

        [InjectView(Resource.Id.root_view)]
        public ViewGroup DrawerMainContent { get; set; }

        [InjectView(Resource.Id.drawer_layout)]
        public DrawerLayout Drawer { get; set; }



        [CrossView(nameof(ProjectNavigationBaseViewModel.SideMenuImage))]
        [InjectView(Resource.Id.side_menu_image_view)]
        public ImageView SideMenuImage { get; set; }

        [CrossView(nameof(ProjectNavigationBaseViewModel.SideMenuTint))]
        [InjectView(Resource.Id.side_menu_image_tint)]
        public View SideMenuTint { get; set; }



        [CrossView(nameof(ProjectNavigationBaseViewModel.HeaderRootView))]
        [InjectView(Resource.Id.header_root_view)]
        public LinearLayout HeaderRootView { get; set; }

        [CrossView(nameof(ProjectNavigationBaseViewModel.HeaderLeftTouchArea))]
        [InjectView(Resource.Id.left_button_container)]
        public LinearLayout HeaderLeftTouchAreaView { get; set; }

        [CrossView(nameof(ProjectNavigationBaseViewModel.HeaderLeftImageView))]
        [InjectView(Resource.Id.left_button_image)]
        public ImageView HeaderLeftImageView { get; set; }

        [CrossView(nameof(ProjectNavigationBaseViewModel.HeaderRightTouchArea))]
        [InjectView(Resource.Id.right_button_container)]
        public LinearLayout HeaderRightTouchAreaView { get; set; }

        [CrossView(nameof(ProjectNavigationBaseViewModel.HeaderRightImageView))]
        [InjectView(Resource.Id.right_button_image)]
        public ImageView HeaderRightImageView { get; set; }

        [CrossView(nameof(ProjectNavigationBaseViewModel.HeaderTextView))]
        [InjectView(Resource.Id.header_text_view)]
        public TextView HeaderTextView { get; set; }





        [CrossView(nameof(ProjectNavigationBaseViewModel.SideMenuRootView))]
        [InjectView(Resource.Id.side_menu_root_view)]
        public View SideMenuRootView { get; set; }

        [CrossView(nameof(ProjectNavigationBaseViewModel.SideMenuTopRightImageTouchArea))]
        [InjectView(Resource.Id.side_menu_right_button_container)]
        public LinearLayout SideMenuTopRightImageTouchArea { get; set; }

        //[CrossView(nameof(ProjectNavigationBaseViewModel.SideMenuTopRightImageView))]
        //[InjectView(Resource.Id.side_menu_right_button_image)]
        //public ImageView SideMenuTopRightImageView { get; set; }

        [CrossView(nameof(ProjectNavigationBaseViewModel.SideMenuTopImageView))]
        [InjectView(Resource.Id.side_menu_top_image)]
        public ImageView SideMenuTopImageView { get; set; }

        [CrossView(nameof(ProjectNavigationBaseViewModel.SideMenuTopTextView))]
        [InjectView(Resource.Id.side_menu_top_text)]
        public TextView SideMenuTopTextView { get; set; }




        [CrossView(nameof(ProjectNavigationBaseViewModel.LineImageHeader))]
        [InjectView(Resource.Id.line_image_header)]
        public ImageView LineImageHeader { get; set; }

        [CrossView(nameof(ProjectNavigationBaseViewModel.SideMenuListView))]
        [InjectView(Resource.Id.side_menu_list)]
        public RecyclerView SideMenuListView { get; set; }

        [CrossView(nameof(ProjectNavigationBaseViewModel.LineImageFooter))]
        [InjectView(Resource.Id.line_image_footer)]
        public ImageView LineImageFooter { get; set; }




        [CrossView(nameof(ProjectNavigationBaseViewModel.SideMenuBottomTouchArea))]
        [InjectView(Resource.Id.side_menu_bottom_touch_area)]
        public View SideMenuBottomTouchArea { get; set; }

        [CrossView(nameof(ProjectNavigationBaseViewModel.SideMenuBottomTextView))]
        [InjectView(Resource.Id.side_menu_bottom_text)]
        public TextView SideMenuBottomTextView { get; set; }
    }
}