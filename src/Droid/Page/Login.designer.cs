//
//  Splash.designer.cs
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

using Android.Views;
using Android.Widget;
using Core.ViewModels;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Droid.Wrappers;

namespace Droid.Page
{
    partial class Login
    {
        [CrossView(nameof(LoginViewModel.BackgroundImageView))]
        [InjectView(Resource.Id.login_background)]
        public ImageView BackgroundImageView { get; set; }

        [CrossView(nameof(LoginViewModel.BackgroundUsername))]
        [InjectView(Resource.Id.username_background)]
        public View BackgroundUsername { get; set; }

        [CrossView(nameof(LoginViewModel.BackgroundPassword))]
        [InjectView(Resource.Id.password_background)]
        public View BackgroundPassword { get; set; }

        [CrossView(nameof(LoginViewModel.EmailTextView))]
        [InjectView(Resource.Id.email)]
        public TextView EmailTextView { get; set; }

        [CrossView(nameof(LoginViewModel.PasswordTextView))]
        [InjectView(Resource.Id.password)]
        public TextView PasswordTextView { get; set; }

        [CrossView(nameof(LoginViewModel.LoginButton))]
        [InjectView(Resource.Id.login)]
        public TextView LoginButton { get; set; }

        [CrossView(nameof(LoginViewModel.ImageView))]
        [InjectView(Resource.Id.logo)]
        public ImageView LoginImage { get; set; }

        [CrossView(nameof(LoginViewModel.RememberMeImageView))]
        [InjectView(Resource.Id.remember_me_image)]
        public ImageView RememberMeImageView { get; set; }

        [CrossView(nameof(LoginViewModel.RememberMeImageWrapper))]
        [InjectView(Resource.Id.image_remember_wrapper)]
        public ImageView RememberMeImageWrapper { get; set; }

        [CrossView(nameof(LoginViewModel.RememberMeTextView))]
        [InjectView(Resource.Id.remember_me_text)]
        public TextView RememberMeTextView { get; set; }

        [CrossView(nameof(LoginViewModel.RememberMeTouchArea))]
        [InjectView(Resource.Id.remember_me_touch_area)]
        public View RememberMeTouchArea { get; set; }

        [CrossView(nameof(LoginViewModel.ForgotPasswordTextView))]
        [InjectView(Resource.Id.text_view_forgot_password)]
        public TextView ForgotPasswordTextView { get; set; }

        [CrossView(nameof(LoginViewModel.ForgotPasswordUndeline))]
        [InjectView(Resource.Id.forgot_password_underline)]
        public View ForgotPasswordUndeline { get; set; }
    }
}