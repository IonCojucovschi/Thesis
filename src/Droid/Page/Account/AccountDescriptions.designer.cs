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
using Core.ViewModels.Account;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Droid.Wrappers;

namespace Droid.Page
{
    public partial class AccountDescriptions
    {
        [CrossView(nameof(AccountDescriptionsViewModel.NewPasswordText))]
        [InjectView(Resource.Id.new_password)]
        public TextView NewPasswordText { get; set; }

        [CrossView(nameof(AccountDescriptionsViewModel.ConfirmPasswordText))]
        [InjectView(Resource.Id.confirm_password)]
        public TextView ConfirmPasswordText { get; set; }

        [CrossView(nameof(AccountDescriptionsViewModel.ButtonConfirmText))]
        [InjectView(Resource.Id.confirm_button)]
        public TextView ButtonConfirmText { get; set; }

        [CrossView(nameof(AccountDescriptionsViewModel.ContainerView))]
        [InjectView(Resource.Id.container_view)]
        public View ContainerView { get; set; }

        [CrossView(nameof(AccountDescriptionsViewModel.LineNewView))]
        [InjectView(Resource.Id.view_line_new_password)]
        public View LineNewView { get; set; }

        [CrossView(nameof(AccountDescriptionsViewModel.LineConfirmView))]
        [InjectView(Resource.Id.view_line_confirm_password)]
        public View LineConfirmView { get; set; }

        [CrossView(nameof(AccountDescriptionsViewModel.MainBackgroundImageView))]
        [InjectView(Resource.Id.account_background_image_view)]
        public ImageView MainBgImageView { get; set; }

        [CrossView(nameof(AccountDescriptionsViewModel.ShadowImage))]
        [InjectView(Resource.Id.shadow_image_view)]
        public ImageView ShadowImage { get; set; }

        [CrossView(nameof(AccountDescriptionsViewModel.OldPassword))]
        [InjectView(Resource.Id.old_password)]
        public TextView OldPassword { get; set; }

        [CrossView(nameof(AccountDescriptionsViewModel.LineOldView))]
        [InjectView(Resource.Id.view_line_old_password)]
        public View LineOldView { get; set; }
    }
}