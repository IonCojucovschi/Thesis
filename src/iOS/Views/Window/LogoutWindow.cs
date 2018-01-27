//
//  LogoutWindow.cs
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
using Core.ViewModels.Window;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using iOS.Views.Window.Base;
using UIKit;

namespace iOS.Views.Window
{
    public class LogoutWindow
        : ProjectBaseWindow<LogoutViewModel>
    {
        private readonly LogoutView _view;

        public LogoutWindow() : base(typeof(LogoutView))
        {
            _view = CreateObject<LogoutView>();
        }

        [CrossView(nameof(LogoutViewModel.LabelYes))]
        public UILabel Yes => _view.Yes;

        [CrossView(nameof(LogoutViewModel.LabelNo))]
        public UILabel No => _view.No;

        [CrossView(nameof(LogoutViewModel.LabelMessage))]
        public UILabel Message => _view.Message;

        [CrossView(nameof(LogoutViewModel.MainWindowView))]
        public UIView MainView => _view.MainWin;

        [CrossView(nameof(LogoutViewModel.BackgroundView))]
        public UIView Root => _view.Root;

        [CrossView(nameof(LogoutViewModel.LogoutBackgroundImage))]
        public UIView Root2 => _view.ImageRoot;
    }
}
