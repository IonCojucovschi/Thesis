//
//  LogoutViewModel.cs
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
using System.Threading;
using Core.Extensions;
using Core.Helpers;
using Core.Helpers.Manager;
using Core.Resources.Colors;
using Core.Resources.Drawables;
using Core.Resources.Locales.Page;
using Core.ViewModels.Base;
using Int.Core.Application.Widget.Contract;
using Int.Core.Wrappers.Widget.CrossViewInjection;

namespace Core.ViewModels.Window
{
    public class LogoutViewModel : ProjectBaseViewModel
    {
        private readonly string LabelMessageString = RWindow.LabelMessage;
        private readonly string LabelNoString = RWindow.LabelNo;
        private readonly string LabelYesString = RWindow.LabelYes;

        [CrossView]
        public IView BackgroundView { get; set; }

        [CrossView]
        public IView MainWindowView { get; set; }

        [CrossView]
        public IText LabelMessage { get; set; }

        [CrossView]
        public IText LabelYes { get; set; }

        [CrossView]
        public IText LabelNo { get; set; }

        [CrossView]
        public IImage LogoutBackgroundImage { get; set; }

        [CrossView]
        public IImage ShadowImage { get; set; }

        public override void UpdateData()
        {
            LogoutBackgroundImage?.SetImageFromResource(DrawableConstants.BackgroundImage);
            ShadowImage?.SetImageFromResource(DrawableConstants.ShadowImage);

            if (BackgroundView != null)
            {
                //BackgroundView.SetBackgroundColor(ColorConstants.AppMainColorTransparent);
                BackgroundView.Click -= BackgroundView_Click;
                BackgroundView.Click += BackgroundView_Click;
            }

            if (MainWindowView != null)
            {
                MainWindowView.SetBackgroundColor(ColorConstants.WhiteColor, CornerRadiusBackground,
                    ColorConstants.WhiteColor, 1.0f);
                MainWindowView.Click -= MainWindowView_Click;
                MainWindowView.Click += MainWindowView_Click;
            }

            if (LabelMessage != null)
            {
                LabelMessage.SetTextColor(ColorConstants.TextLogoutAnsverColor);
                LabelMessage.SetFont(FontsConstant.MontserratRegular, FontsConstant.Size18);
                LabelMessage.Text = LabelMessageString;
            }

            if (LabelYes != null)
            {
                LabelYes.SetBackgroundColor(ColorConstants.BlueColor, borderColor: ColorConstants.BlueColor, borderWidth: 1.0f, type: RadiusType.Aspect);
                LabelYes.SetSelectedColor(ColorConstants.BlueColor.SelectorTransparence(ColorConstants.Procent50));
                LabelYes.SetTextColor(ColorConstants.WhiteColor);
                LabelYes.SetFont(FontsConstant.MontserratBold, FontsConstant.Size13);
                LabelYes.Text = LabelYesString;
                LabelYes.Click -= LabelYes_Click;
                LabelYes.Click += LabelYes_Click;
            }

            if (LabelNo == null) return;
            LabelNo.SetBackgroundColor(ColorConstants.TransparentColor, borderColor: ColorConstants.BlueColor, borderWidth: 1.0f, type: RadiusType.Aspect);
            LabelNo.SetSelectedColor(ColorConstants.TextLightGreyColor.SelectorTransparence(ColorConstants.Procent50));
            LabelNo.SetTextColor(ColorConstants.BlueColor);
            LabelNo.SetFont(FontsConstant.MontserratBold, FontsConstant.Size13);
            LabelNo.Text = LabelNoString;
            LabelNo.Click -= LabelNo_Click;
            LabelNo.Click += LabelNo_Click;
        }

        private void BackgroundView_Click(object sender, EventArgs e)
        {
            CurrentPopupWindow?.Close();
        }

        private void MainWindowView_Click(object sender, EventArgs e)
        {
            // Supress parent click.
        }

        private void LabelYes_Click(object sender, EventArgs e)
        {
            Show();

            ThreadPool.QueueUserWorkItem(_ =>
                UserManager.Instance.Logout(obj =>
                {
                    Hide();
                    CurrentPopupWindow?.Close();
                    this.GoPage(PageConstants.LoginName);
                }, message => ShowError(message)));
        }

        private void LabelNo_Click(object sender, EventArgs e)
        {
            CurrentPopupWindow?.Close();
        }
    }
}