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

using Android.Widget;
using Core.ViewModels;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Droid.Wrappers;

namespace Droid.Page
{
    partial class Dashboard
    {
        [CrossView(nameof(DashboardViewModel.BackgroundImage))]
        [InjectView(Resource.Id.dashboard_background_view)]
        public ImageView BackgroundImageView { get; set; }

        [CrossView(nameof(DashboardViewModel.WelcomeText))]
        [InjectView(Resource.Id.welcome_text_view)]
        public TextView WelcomeText { get; set; }

        [CrossView(nameof(DashboardViewModel.NameSurnameText))]
        [InjectView(Resource.Id.name_surname_text_view)]
        public TextView NameSurnameText { get; set; }
    }
}
