//
// BasePageViewModel.cs
//
// Author:
//       Songurov Fiodor <songurov@gmail.com>
//
// Copyright (c) 2016 Songurov Fiodor
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using Core.Extensions;
using Core.Helpers;
using Core.Helpers.Manager;
using Core.Models.DAL;
using Core.Resources.Colors;
using Core.Resources.Drawables;
using Core.Resources.Locales.Page;
using Core.ViewModels.Window;
using Int.Core.Application.Menu.Contract;
using Int.Core.Application.Widget.Contract;
using Int.Core.Application.Widget.Contract.Table;
using Int.Core.Application.Widget.Contract.Table.Adapter;
using Int.Core.Extensions;
using Int.Core.Wrappers.Widget.CrossViewInjection;

#if __IOS__
using iOS.Views.Window;
#else
using Droid.Views.Window;
#endif

namespace Core.ViewModels.Base
{
    [Serializable]
    public abstract class ProjectNavigationBaseViewModel : ProjectBaseViewModel
    {
        private MenuManager _menuManager;
        private string Logout => RMenu.Logout;

        public string CurrentPageName { get; set; }

        public bool IsMenuOpened { get; set; }

        public Func<bool> MenuOpen { get; set; }

        public virtual ICrossCellViewHolder<IItemMenu> SideMenuCellModel { get; protected set; }

        public override void UpdateData()
        {
            _menuManager = MenuManager.Instance;
            SideMenuCellModel = new SideMenuCell(this);

            RootView?.SetBackgroundColor(ColorConstants.SemiLightGrey);

            SetupHeaderView();
            SetupSideMenuView();
        }

        #region HeaderRelated

        [CrossView]
        public IView HeaderRootView { get; protected set; }

        [CrossView]
        public IText HeaderTextView { get; protected set; }

        [CrossView]
        public IView HeaderLeftTouchArea { get; protected set; }

        [CrossView]
        public IImage HeaderLeftImageView { get; protected set; }

        [CrossView]
        public IView HeaderRightTouchArea { get; protected set; }

        [CrossView]
        public IImage HeaderRightImageView { get; protected set; }

        protected abstract string HeaderText { get; }

        protected abstract HeaderAreaActionType HeaderAreaAction { get; }

        public HeaderAreaActionType TypeMenu => HeaderAreaAction;

        protected virtual void SetupHeaderView()
        {
            HeaderRootView?.SetBackgroundColor(ColorConstants.BlueColor);

            if (!HeaderTextView.IsNull())
            {
                HeaderTextView.Text = HeaderText;
                HeaderTextView.SetTextColor(ColorConstants.WhiteColor);
                HeaderTextView.SetFont(FontsConstant.MontserratSemiBold);
            }

            if (HeaderLeftImageView.IsNull()) return;

            HeaderLeftImageView.SetSelected(ColorConstants.BlueColor);

            if (HeaderRightImageView.IsNull()) return;
            HeaderRightImageView.SetSelected(ColorConstants.BlueColor);

            switch (HeaderAreaAction)
            {
                case HeaderAreaActionType.LeftNothing:
                    HeaderLeftImageView.SetImageFromResource(DrawableConstants.MenuClose);
                    break;
                case HeaderAreaActionType.LeftBack:
                    HeaderLeftImageView.SetImageFromResource(DrawableConstants.BackIcon);
                    if (!HeaderLeftTouchArea.IsNull())
                    {
                        HeaderLeftTouchArea.Click -= BackAction;
                        HeaderLeftTouchArea.Click += BackAction;
                    }
                    break;

                case HeaderAreaActionType.RightNothing:
                    HeaderRightImageView.SetImageFromResource(DrawableConstants.MenuClose);
                    break;
                case HeaderAreaActionType.RightBack:
                    HeaderRightImageView.SetImageFromResource(DrawableConstants.BackIcon);
                    if (!HeaderLeftTouchArea.IsNull())
                    {
                        HeaderRightTouchArea.Click -= BackAction;
                        HeaderRightTouchArea.Click += BackAction;
                    }
                    break;
                case HeaderAreaActionType.RightSideMenu:
                    HeaderRightImageView.SetImageFromResource(DrawableConstants.Menu);

                    if (!HeaderRightTouchArea.IsNull())
                    {
                        HeaderRightTouchArea.Click -= MenuAction;
                        HeaderRightTouchArea.Click += MenuAction;
                        if (!HeaderLeftTouchArea.IsNull())
                        {
                            HeaderLeftTouchArea.Click -= LeftMenuAction;
                            HeaderLeftTouchArea.Click += LeftMenuAction;
                        }
                    }

                    break;
            }
        }

        protected virtual void BackAction(object sender, EventArgs e)
        {
                this.GoBack();
        }

        protected virtual void MenuAction(object sender, EventArgs e)
        {
            IsMenuOpened = MenuOpen?.Invoke() ?? false;

            HeaderLeftImageView.SetImageFromResource(null);
        }

        protected virtual void LeftMenuAction(object sender, EventArgs e)
        {
            if (IsMenuOpened)
                IsMenuOpened = MenuOpen?.Invoke() ?? false;
        }

        public enum HeaderAreaActionType
        {
            LeftNothing,
            LeftBack,
            RightNothing,
            RightBack,
            RightSideMenu
        }

        #endregion

        #region SideMenuRelated

        [CrossView]
        public IImage SideMenuImage { get; protected set; }

        [CrossView]
        public IView SideMenuTint { get; protected set; }

        [CrossView]
        public IImage SideMenuTopRightImageView { get; protected set; }

        [CrossView]
        public IView SideMenuTopRightImageTouchArea { get; protected set; }

        [CrossView]
        public IImage SideMenuTopImageView { get; protected set; }

        [CrossView]
        public IText SideMenuTopTextView { get; protected set; }

        [CrossView]
        public IView SideMenuBottomTouchArea { get; protected set; }

        [CrossView]
        public IImage SideMenuBottomImageView { get; protected set; }

        [CrossView]
        public IText SideMenuBottomTextView { get; protected set; }

        [CrossView]
        public IView SideMenuRootView { get; protected set; }

        [CrossView]
        public IListView SideMenuListView { get; protected set; }

        [CrossView]
        public IImage LineImageHeader { get; protected set; }

        [CrossView]
        public IImage LineImageFooter { get; protected set; }

        private string MenuName => ConcreteCurrentUser?.FullName;

        protected virtual void SetupSideMenuView()
        {
            if (!SideMenuRootView.IsNull())
            {
                SideMenuRootView.Click -= SideMenuRootView_Click;
                SideMenuRootView.Click += SideMenuRootView_Click;
            }

            if (!SideMenuImage.IsNull())
                SideMenuImage.SetImageFromResource(DrawableConstants.BackgroundImage);

            if (!SideMenuTopImageView.IsNull())
                SideMenuTopImageView.SetImageFromResource(DrawableConstants.LogoPng);

            if (!SideMenuTopRightImageView.IsNull())
                SideMenuTopRightImageView.SetImageFromResource(null);

            if (!SideMenuTopTextView.IsNull())
            {
                SideMenuTopTextView.Text = "";
                SideMenuTopTextView.SetTextColor(ColorConstants.WhiteColor);
                SideMenuTopTextView.SetFont(FontsConstant.MontserratSemiBold, FontsConstant.Size24);
            }

            if (!SideMenuBottomTouchArea.IsNull())
            {
                SideMenuBottomTouchArea.SetBackgroundColor(
                    ColorConstants.DarkColor.SelectorTransparence(ColorConstants.Procent10));
                SideMenuBottomTouchArea.SetSelectedColor(
                    ColorConstants.YellowColor.SelectorTransparence(ColorConstants.Procent50));
                SideMenuBottomTouchArea.Click -= SideMenuBottomTouchArea_Click;
                SideMenuBottomTouchArea.Click += SideMenuBottomTouchArea_Click;
            }

            if (!SideMenuBottomImageView.IsNull())
                SideMenuBottomImageView.SetImageFromResource(null);

            if (!SideMenuBottomTextView.IsNull())
            {
                SideMenuBottomTextView.Text = Logout.ToUpperInvariant();
                SideMenuBottomTextView.SetTextColor(ColorConstants.YellowColor);
                SideMenuBottomTextView.SetFont(FontsConstant.MontserratMedium, FontsConstant.Size15);
            }

            if (!LineImageHeader.IsNull())
                LineImageHeader.SetImageFromResource(null);

            if (!LineImageFooter.IsNull())
                LineImageFooter.SetImageFromResource(null);

            if (SideMenuListView.IsNull()) return;
            var menuList = _menuManager.GetAll();
            SideMenuListView.UpdateDataSource(menuList);
        }

        private void SideMenuBottomTouchArea_Click(object sender, EventArgs e)
        {
            this.GetWindow<LogoutWindow, LogoutViewModel>();
        }

        private void SideMenuRootView_Click(object sender, EventArgs e)
        {
            MenuOpen?.Invoke();
        }

        public class SideMenuCell : ICrossCellViewHolder<IItemMenu>
        {
            private readonly ProjectNavigationBaseViewModel _baseViewModel;

            public SideMenuCell(ProjectNavigationBaseViewModel viewModel)
            {
                _baseViewModel = viewModel;
            }

            [CrossView]
            public IView CellRootView { get; protected set; }

            [CrossView]
            public IView SelectionIndicatingView { get; protected set; }

            [CrossView]
            public IText LabelTextView { get; protected set; }

            public void Bind(IItemMenu model)
            {
                SetSelectionColor(model.ClickArgument == _baseViewModel.CurrentPageName);

                if (LabelTextView.IsNull()) return;
                LabelTextView.Text = model.Name.ToUpperInvariant();
                LabelTextView?.SetFont(FontsConstant.MontserratSemiBold, FontsConstant.Size15);

                if (CellRootView.IsNull()) return;
                CellRootView.Tag = model;
                CellRootView.Click -= ClickHandler;
                CellRootView.Click += ClickHandler;
            }

            public void OnCreate()
            {
                CellRootView?.SetBackgroundColor(ColorConstants.TransparentColor);
            }

            private void ClickHandler(object sender, EventArgs e)
            {
                if (!(sender is IView iView)) return;
                if (!(iView.Tag is MenuItem menuItem)) return;

                if (menuItem.ClickArgument == _baseViewModel.CurrentPageName)
                    return;

                _baseViewModel.GoPage(menuItem.ClickArgument);
            }

            private void SetSelectionColor(bool selected)
            {
                if (selected)
                {
                    SelectionIndicatingView?.SetBackgroundColor(ColorConstants.YellowColor);
                    LabelTextView?.SetTextColor(ColorConstants.YellowColor);

                    return;
                }

                SelectionIndicatingView?.SetBackgroundColor(ColorConstants.TransparentColor);
                LabelTextView?.SetTextColor(ColorConstants.WhiteColor);
            }
        }

        #endregion
    }
}