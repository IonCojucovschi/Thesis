using System;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
using Android.OS;
using Android.Support.V4.Widget;
using Android.Views;
using Android.Widget;
using Core.Resources.Drawables;
using Core.ViewModels.Base;
using Int.Core.Application.Menu.Contract;
using Int.Core.Application.Widget.Contract.Table.Adapter;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Droid.Extensions;
using Int.Droid.Factories.Adapter.RecyclerView;
using Int.Droid.Wrappers;
using Object = Java.Lang.Object;

namespace Droid.Page.Base
{
    public abstract partial class NavigationBasePage<TViewModel> : BasePage<TViewModel>
        where TViewModel : ProjectNavigationBaseViewModel
    {
        private float DrawerWidthAspet => 331.0f / 375.0f;

        protected sealed override int LayoutResource => Resource.Layout.base_page;
        protected abstract int LayoutContentResource { get; }

        protected override void FindViews()
        {
            base.FindViews();

            ModelView.CurrentPageName = GetType().Name;

            var mainContentView = FindViewById<FrameLayout>(Resource.Id.main_content);
            LayoutInflater.Inflate(LayoutContentResource, mainContentView);
        }

        protected override void OnResume()
        {
            base.OnResume();
            Drawer.CloseDrawers();
        }

        protected override void InitViews()
        {
            base.InitViews();

            if (ModelView.TypeMenu != ProjectNavigationBaseViewModel.HeaderAreaActionType.RightSideMenu)
                Drawer.SetDrawerLockMode(DrawerLayout.LockModeLockedClosed);

            Drawer.SetScrimColor(Color.Transparent);
            Drawer.Post(SetSideDrawerWidth);
            DrawerMainContent.Post(PreConfigureMainContentView);
            DrawerMainContent.BringToFront();
            Drawer.AddDrawerListener(new DrawerListener(SideMenuRootView,
                HeaderRootView,
                DrawerMainContent,
                ModelView.CornerRadiusSideMenu.Iphone6PointsToDevicePixels(),
                ModelView));

            ModelView.CurrentPageName = GetType().Name;

            ModelView.MenuOpen = ToggleSideMenu;

            var adapter = ComponentAdapterRecyclerFactory.CreateAdapter((inflater, parent) =>
                new MenuCellViewHolder(inflater, parent, ModelView.SideMenuCellModel));
            SideMenuListView.SetAdapterRv(adapter);
        }

        private void SetSideDrawerWidth()
        {
            var width = (int) (Drawer.MeasuredWidth * DrawerWidthAspet +
                               ModelView.CornerRadiusSideMenu.Iphone6PointsToDevicePixels());
            SideMenuRootView.LayoutParameters.Width = width;
        }

        private void PreConfigureMainContentView()
        {
            DrawerMainContent.LayoutParameters.Width = DrawerMainContent.MeasuredWidth;

            var shadowView = new View(this);
            var shadowWidth = (int) (DrawerMainContent.MeasuredWidth * 0.05);

            var shape = new RectShape();
            var shapeDrawable = new GradientDrawable(GradientDrawable.Orientation.LeftRight,
                new[] {0, Convert.ToInt32("FF000000", 16)});
            shapeDrawable.SetGradientType(GradientType.LinearGradient);
            shapeDrawable.SetGradientCenter(1.0f, 0.5f);
            shadowView.SetBackgroundCompat(shapeDrawable);

            DrawerMainContent.AddView(shadowView, 0);

            var shadowLayoutParams = new RelativeLayout.LayoutParams(
                shadowWidth,
                DrawerMainContent.MeasuredHeight)
            {
                LeftMargin = -shadowWidth / 3
            };
            shadowView.LayoutParameters = shadowLayoutParams;
        }

        private bool ToggleSideMenu()
        {
            var isDrawerOpened = Drawer.IsDrawerOpen(SideMenuRootView);

            if (isDrawerOpened)
                Drawer.CloseDrawer(SideMenuRootView);
            else
                Drawer.OpenDrawer(SideMenuRootView);

            return !isDrawerOpened;
        }

        public class DrawerListener : Object, DrawerLayout.IDrawerListener
        {
            private readonly int _cornerRadius;
            private readonly View _headerView;
            private readonly View _rootView;
            private readonly View _sideDrawer;
            public readonly ProjectNavigationBaseViewModel _viewModel;
            private bool _isOpened;

            public DrawerListener(View sideDrawer, View headerView, View rootView, int cornerRadius,
                ProjectNavigationBaseViewModel viewModel)
            {
                _sideDrawer = sideDrawer;
                _headerView = headerView;
                _rootView = rootView;
                _cornerRadius = cornerRadius;
                _viewModel = viewModel;
            }

            public void OnDrawerClosed(View drawerView)
            {
                _isOpened = false;
            }

            public void OnDrawerOpened(View drawerView)
            {
                _isOpened = true;
            }

            public void OnDrawerSlide(View drawerView, float slideOffset)
            {
                AnimateViews(slideOffset);
            }

            public void OnDrawerStateChanged(int newState)
            {
            }

            private void AnimateViews(float slideOffset)
            {
                // Better not try to optimize here anything.
                // Even line order matters.
                _viewModel.IsMenuOpened = !_isOpened;

                _viewModel.CurrentActivity.HideKeyboard();


                if (_viewModel.IsMenuOpened)
                    _viewModel.HeaderLeftImageView.SetImageFromResource(DrawableConstants.Menu);
                else _viewModel.HeaderLeftImageView.SetImageFromResource(null);

                if (_viewModel.MenuOpen?.Invoke() ?? false)
                    _viewModel.HeaderLeftImageView.SetImageFromResource(DrawableConstants.Menu);
                else _viewModel.HeaderLeftImageView.SetImageFromResource(null);

                _sideDrawer.SetX(0);
                var correctedDrawerWidth = _sideDrawer.MeasuredWidth - _cornerRadius;

                if (slideOffset < 1.0f)
                {
                    var pxToMove = correctedDrawerWidth * slideOffset;
                    _rootView.Left = 0;
                    _rootView.SetX(pxToMove);
                }
                else
                {
                    _rootView.SetX(0);
                    _rootView.Left = correctedDrawerWidth;
                }

                if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
                {
                    _sideDrawer.SetZ(0);
                    _rootView.SetZ(1 + 10 * slideOffset);
                }

                var cornerRadius = slideOffset * _cornerRadius;
                var shape = new RoundRectShape(new[] {cornerRadius, cornerRadius, 0, 0, 0, 0, 0, 0}, null, null);
                var shapeDrawable = GetHeaderDrawable();
                shapeDrawable.Shape = shape;
                _headerView.SetBackgroundCompat(shapeDrawable);
            }

            private ShapeDrawable GetHeaderDrawable()
            {
                var shapeDrawable = _headerView.Background as ShapeDrawable;
                if (shapeDrawable != null) return shapeDrawable;

                shapeDrawable = new ShapeDrawable();

                shapeDrawable.Paint.Color =
                    (_headerView.Background as ColorDrawable)?.Color
                    ?? Color.Transparent;

                return shapeDrawable;
            }
        }
    }

    public class MenuCellViewHolder : ComponentViewHolder<IItemMenu>
    {
        public MenuCellViewHolder(LayoutInflater inflator, ViewGroup parent, ICrossCellViewHolder<IItemMenu> cellModel)
            : base(inflator.Inflate(Resource.Layout.item_menu, parent, false), cellModel)
        {
        }

        [CrossView(nameof(ProjectNavigationBaseViewModel.SideMenuCell.CellRootView))]
        [InjectView(Resource.Id.cell_root_view)]
        public LinearLayout CellRootView { get; set; }

        [CrossView(nameof(ProjectNavigationBaseViewModel.SideMenuCell.SelectionIndicatingView))]
        [InjectView(Resource.Id.selection_indicating_view)]
        public View SelectionIndicatingView { get; set; }

        [CrossView(nameof(ProjectNavigationBaseViewModel.SideMenuCell.LabelTextView))]
        [InjectView(Resource.Id.cell_text_view)]
        public TextView LabelTextView { get; set; }
    }
}