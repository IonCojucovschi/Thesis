//
//  ForgotPasswordWindow.cs
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
using Core.ViewModels.Base;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using iOS.Views.Window.Base;
using UIKit;

namespace iOS.Views.Window
{
    public class SideMenuViewWindow<T> : ProjectBaseWindow<T>
        where T : ProjectBaseViewModel
    {
        private readonly SideMenuView _view;

        public SideMenuViewWindow() : base(typeof(SideMenuView))
        {
            _view = CreateObject<SideMenuView>();
        }

        [CrossView(nameof(ProjectNavigationBaseViewModel.SideMenuImage))]
        UIImageView imageViewMenu1 => _view.ImageRoot;

        [CrossView(nameof(ProjectNavigationBaseViewModel.SideMenuTopRightImageView))]
        UIImageView imageViewMenu => _view.ImageMenu;

        [CrossView(nameof(ProjectNavigationBaseViewModel.SideMenuTopImageView))]
        UIImageView imageViewLogo => _view.ImageLogo;

        [CrossView(nameof(ProjectNavigationBaseViewModel.SideMenuBottomImageView))]
        UIImageView imageViewLogout => _view.LogoutImage;

        [CrossView(nameof(ProjectNavigationBaseViewModel.SideMenuBottomTouchArea))]
        UIView imageViewLogouts => _view.FooterViewArea;

        [CrossView(nameof(ProjectNavigationBaseViewModel.SideMenuBottomTextView))]
        UILabel imageViewTextLogout => _view.TextLogoutW;

        [CrossView(nameof(ProjectNavigationBaseViewModel.SideMenuListView))]
        UITableView imageViewTextTableView => _view.TableViewW;

        [CrossView(nameof(ProjectNavigationBaseViewModel.LineImageHeader))]
        UIImageView imageViewRootViews => _view.ViewHeader;

        [CrossView(nameof(ProjectNavigationBaseViewModel.LineImageFooter))]
        UIImageView imageViewRootVieaws => _view.ViewFooter;

        [CrossView(nameof(ProjectNavigationBaseViewModel.SideMenuRootView))]
        UIView imageViewRootView => this;

        public UITableView TableView => _view.TableViewW;

    }
}
