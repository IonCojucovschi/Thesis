//
//  BasePageSideMenu.cs
//
//  Author:
//       Songurov <songurov@gmail.com>
//
//  Copyright (c) 2017 Songurov
//
//  This library is free software; you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as
//  published by the Free Software Foundation; either version 2.1 of the
//  License, or (at your option) any later version.
//
//  This library is distributed in the hope that it will be useful, but
//  WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
//  Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public
//  License along with this library; if not, write to the Free Software
//  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA

using System;
using System.Collections.Generic;
using Core.ViewModels.Base;
using Int.Core.Application.Menu.Contract;
using Int.Core.Extensions;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.iOS.Extensions;
using Int.iOS.Factories.Adapter;
using iOS.Storyboard;
using iOS.Views.Window;
using iOS.Views.Window.Menu.CellView;
using UIKit;
using static Core.ViewModels.Base.ProjectNavigationBaseViewModel;

namespace iOS.Page.BasePage
{
    public abstract class BasePageSideMenu<T> : BasePage<T> where T : ProjectNavigationBaseViewModel
    {
        protected BasePageSideMenu(IntPtr intP) : base(intP) { }

        protected UITableView TableViewMenu { get; set; }

        private bool _openMenu;

        private readonly SideMenuViewWindow<T> _menuView = new SideMenuViewWindow<T>();

        protected HeaderPage Header => GetContainerView<HeaderPage>();

        protected override void BindViews()
        {
            base.BindViews();

            ModelView.CurrentPageName = GetType().Name;

            TableViewMenu = _menuView.TableView;

            if (!TableViewMenu.IsNull())
                TableViewMenu.Source = ComponentViewSourceFactory.CreateForTable(nameof(MenuViewCell),
                                                                                 new List<IItemMenu>(),
                                                                                 TableViewMenu,
                                                                                 crossCellModel: new SideMenuCell(ModelView), register: true);
            if (ModelView.TypeMenu == HeaderAreaActionType.RightSideMenu)
            {
                View.OnSwipe((obj) =>
                    {
                        switch (obj.Direction)
                        {
                            case UISwipeGestureRecognizerDirection.Left:
                                SwipeLeftToRight();
                                break;
                            case UISwipeGestureRecognizerDirection.Right:
                                SwipeRightToLeft();
                                break;
                        }
                    });
            }

            ModelView.MenuOpen = PerformTableTransition;
        }

        private void SwipeLeftToRight()
        {
            if (_openMenu)
                PerformTableTransition();
        }

        private void SwipeRightToLeft()
        {
            if (!_openMenu)
                PerformTableTransition();
        }

        private bool PerformTableTransition()
        {
            if (_openMenu)
            {
                _menuView.AnimationFade(AnimationType.Out);
                _openMenu = false;
            }
            else
            {
                _menuView.Show();
                _menuView.AnimationFade(AnimationType.In);
                _openMenu = true;
            }

            return _openMenu;
        }

        #region Designer 

        //Header
        [CrossView(nameof(ProjectNavigationBaseViewModel.HeaderTextView))]
        UILabel textViewHeader => Header.TextHeader;

        [CrossView(nameof(ProjectNavigationBaseViewModel.HeaderLeftImageView))]
        UIImageView imageViewHeader => Header.ImageIconHeader;

        [CrossView(nameof(ProjectNavigationBaseViewModel.HeaderRightImageView))]
        UIImageView imageViewHeader2 => Header.ImageRight;

        [CrossView(nameof(ProjectNavigationBaseViewModel.HeaderRootView))]
        UIView rootview => Header.View;

        [CrossView(nameof(ProjectNavigationBaseViewModel.HeaderLeftTouchArea))]
        UIView rootviews => Header.AreaViewTouch;

        [CrossView(nameof(ProjectNavigationBaseViewModel.HeaderRightTouchArea))]
        UIView rootviews2 => Header.AreaViewTouchRight;

        #endregion
    }
}
