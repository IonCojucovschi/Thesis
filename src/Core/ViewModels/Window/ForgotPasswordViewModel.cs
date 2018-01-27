//
//  ForgotPasswordViewModel.cs
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
using Core.Models.DAL;
using Core.Resources.Colors;
using Core.Resources.Drawables;
using Core.Resources.Locales.Page;
using Core.ViewModels.Base;
using Int.Core.Application.Widget.Contract;
using Int.Core.Wrappers.Widget.CrossViewInjection;

namespace Core.ViewModels.Window
{
    public class ForgotPasswordViewModel : ProjectBaseViewModel
    {
        private string Email => RLogin.EmailHint;
        private string LabelCancelString => RWindow.LabelCancel;
        private string LabelSendString => RWindow.LabelSend;
        private string EmailIsEmpty => RWindow.EmailIsEmpty;

        [CrossView]
        public IView BackgroundView { get; set; }

        [CrossView]
        public IView MainWindowView { get; set; }

        [CrossView]
        public IText EmailEditText { get; set; }

        [CrossView]
        public IView EmailUnderline { get; set; }

        [CrossView]
        public IText LabelCancel { get; set; }

        [CrossView]
        public IText LabelSend { get; set; }

        [CrossView]
        public IImage ShadowImage { get; set; }

        public override void UpdateData()
        {
            ShadowImage?.SetImageFromResource(DrawableConstants.ShadowImage);

            if (BackgroundView != null)
            {
                BackgroundView.SetBackgroundColor(ColorConstants.AppMainColorTransparent);
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

            if (EmailEditText != null)
            {
                EmailEditText.SetFont(FontsConstant.MontserratMedium, FontsConstant.Size13);
                EmailEditText.SetTextColor(ColorConstants.TextGreyColor);
                EmailEditText.SetHintColor(ColorConstants.TextHintColor);
                EmailEditText.Hint = Email;
                EmailEditText.Text = string.Empty;
            }

            EmailUnderline?.SetBackgroundColor(ColorConstants.LightView);

            if (LabelCancel != null)
            {
                LabelCancel.SetBackgroundColor(ColorConstants.TransparentColor, borderColor: ColorConstants.BlueColor, borderWidth: 1.0f, type: RadiusType.Aspect);
                LabelCancel.SetSelectedColor(ColorConstants.BlueColor.SelectorTransparence(ColorConstants.Procent50));
                LabelCancel.SetTextColor(ColorConstants.BlueColor);
                LabelCancel.SetFont(FontsConstant.MontserratBold, FontsConstant.Size13);
                LabelCancel.Text = LabelCancelString;
                LabelCancel.Click -= LabelCancel_Click;
                LabelCancel.Click += LabelCancel_Click;
            }

            if (LabelSend == null) return;

            LabelSend.SetBackgroundColor(ColorConstants.BlueColor, borderColor: ColorConstants.BlueColor, borderWidth: 1.0f, type: RadiusType.Aspect);
            LabelSend.SetSelectedColor(ColorConstants.BlueColor.SelectorTransparence(ColorConstants.Procent50));
            LabelSend.SetTextColor(ColorConstants.WhiteColor);
            LabelSend.SetFont(FontsConstant.MontserratBold, FontsConstant.Size13);
            LabelSend.Text = LabelSendString;
            LabelSend.Click -= LabelSend_Click;
            LabelSend.Click += LabelSend_Click;
        }

        private void BackgroundView_Click(object sender, EventArgs e)
        {
            CurrentPopupWindow?.Close();
        }

        private void MainWindowView_Click(object sender, EventArgs e)
        {
            // Supress parent click.
        }

        private void LabelSend_Click(object sender, EventArgs e)
        {
            var emailAddr = EmailEditText?.Text;

            if (string.IsNullOrWhiteSpace(emailAddr))
            {
                ShowError(EmailIsEmpty);
                return;
            }

            UserManager.Instance.UpdateUser(new UserModel
            {
                Username = emailAddr
            });

            Show();

            ThreadPool.QueueUserWorkItem(_ =>
                UserManager.Instance.RecoverPassword(
                    obj =>
                    {
                        ShowSuccess(obj);
                        CurrentPopupWindow?.Close();
                    }, message => ShowError(message)));
        }

        private void LabelCancel_Click(object sender, EventArgs e)
        {
            CurrentPopupWindow?.Close();
        }
    }
}