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
using Core.ViewModels.Window;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using iOS.Views.Window.Base;
using UIKit;
using Int.iOS.Extensions;

namespace iOS.Views.Window
{
    public class ForgotPasswordWindow
        : ProjectBaseWindow<ForgotPasswordViewModel>
    {
        private readonly ForgotEmailView _view;

        public ForgotPasswordWindow() : base(typeof(ForgotEmailView))
        {
            _view = CreateObject<ForgotEmailView>();

            _view.Mail.ResponderNext(null, null);
        }

        [CrossView(nameof(ForgotPasswordViewModel.LabelCancel))]
        public UILabel Yes => _view.Cancel;

        [CrossView(nameof(ForgotPasswordViewModel.LabelSend))]
        public UILabel No => _view.Send;

        [CrossView(nameof(ForgotPasswordViewModel.EmailEditText))]
        public UITextField Mail => _view.Mail;

        [CrossView(nameof(ForgotPasswordViewModel.EmailUnderline))]
        public UIView Undeline => _view.Underline;

        [CrossView(nameof(ForgotPasswordViewModel.MainWindowView))]
        public UIView MainView => _view.MainWin;

        [CrossView(nameof(ForgotPasswordViewModel.BackgroundView))]
        public UIView Root => _view.RootView;
    }
}
