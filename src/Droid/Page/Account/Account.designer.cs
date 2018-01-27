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

using Android.Support.V7.Widget;
using Android.Widget;
using Core.ViewModels.Account;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Droid.Wrappers;

namespace Droid.Page
{
    public partial class Account
    {
        [InjectView(Resource.Id.account_info_list)]
        [CrossView(nameof(AccountViewModel.ListViewYour))]
        public RecyclerView ListViewYour { get; set; }

        [InjectView(Resource.Id.button_change_password)]
        [CrossView(nameof(AccountViewModel.ChangePasswordText))]
        public TextView ChangePasswordText { get; set; }

        //[InjectView(Resource.Id.account_current_header)]
        //[CrossView(nameof(AccountViewModel.TitleAccountLabel))]
        //public TextView TitleAccountLabel { get; set; }

        [InjectView(Resource.Id.shadow_image_view)]
        [CrossView(nameof(AccountViewModel.ShadowImage))]
        public ImageView ShadowImage { get; set; }

        [InjectView(Resource.Id.space1)]
        public Space Space1 { get; set; }

        [InjectView(Resource.Id.space2)]
        public Space Space2 { get; set; }

        [InjectView(Resource.Id.space3)]
        public Space Space3 { get; set; }

        //[InjectView(Resource.Id.space4)]
        //public Space Space4 { get; set; }
    }
}
