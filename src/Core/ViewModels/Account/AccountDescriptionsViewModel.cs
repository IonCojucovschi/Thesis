//
// SplashViewModel.cs
//
// Author:
//       Songurov Fiodor <songurov@gmail.com>
//
// Copyright (c) 2017 Songurov Fiodor
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System;
using System.Linq;
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
using Int.Core.Extensions;
using Int.Core.Wrappers.Widget.CrossViewInjection;

namespace Core.ViewModels.Account
{
    public class AccountDescriptionsViewModel : ProjectNavigationBaseViewModel
    {
        private string NewPasswordTextHint => RAccount.NewPasswordTextHint;
        private string ConfirmPasswordTextHint => RAccount.ConfirmPasswordTextHint;
        private string OldPasswordTextHint => RAccount.OldPasswordTextHint;
        private string ButtonConfirmTextString => RAccount.ButtonConfirmText;
        private string FieldIsEmpty => RAccount.FieldIsEmpty;
        private string NewPasswordTextErrorLessChar => RAccount.NewPasswordTextErrorLessChar;
        private string NewPasswordErrorLimitChar => RAccount.NewPasswordTextErrorLimitChar;
        private string ConfirmPasswordErrorText => RAccount.ConfirmPasswordErrorText;
        private string SuccesChangePasswordText => RAccount.SuccesChangePasswordText;

        protected override string HeaderText => RAccount.HeaderText.ToUpperInvariant();
        protected override HeaderAreaActionType HeaderAreaAction => HeaderAreaActionType.LeftBack;

        [CrossView]
        public IText NewPasswordText { get; protected set; }

        [CrossView]
        public IText ConfirmPasswordText { get; protected set; }

        [CrossView]
        public IText OldPassword { get; protected set; }


        [CrossView]
        public IText ButtonConfirmText { get; protected set; }

        [CrossView]
        public IView ContainerView { get; protected set; }

        [CrossView]
        public IView LineNewView { get; protected set; }

        [CrossView]
        public IView LineConfirmView { get; protected set; }

        [CrossView]
        public IView LineOldView { get; protected set; }

        [CrossView]
        public IImage MainBackgroundImageView { get; protected set; }

        [CrossView]
        public IImage ShadowImage { get; protected set; }

        public override void UpdateData()
        {
            base.UpdateData();
            InitView();
        }

        private void InitView()
        {
            MainBackgroundImageView?.SetImageFromResource(DrawableConstants.BackgroundImage);
            ContainerView?.SetBackgroundColor(ColorConstants.WhiteColor, CornerRadiusBackground,
                ColorConstants.WhiteColor, 1.0f);
            ShadowImage?.SetImageFromResource(DrawableConstants.ShadowImage);

            if (!NewPasswordText.IsNull())
            {
                NewPasswordText.Hint = NewPasswordTextHint;
                NewPasswordText.SetHintColor(ColorConstants.TextLightGreyColor);
                NewPasswordText.SetFont(FontsConstant.MontserratSemiBold, FontsConstant.Size13);
                NewPasswordText.SetTextColor(ColorConstants.TextGreyColor);
            }

            if (!ConfirmPasswordText.IsNull())
            {
                ConfirmPasswordText.Hint = ConfirmPasswordTextHint;
                ConfirmPasswordText.SetHintColor(ColorConstants.TextLightGreyColor);
                ConfirmPasswordText.SetFont(FontsConstant.MontserratSemiBold, FontsConstant.Size13);
                ConfirmPasswordText.SetTextColor(ColorConstants.TextGreyColor);
            }

            if (!OldPassword.IsNull())
            {
                OldPassword.Hint = OldPasswordTextHint;
                OldPassword.SetHintColor(ColorConstants.TextLightGreyColor);
                OldPassword.SetFont(FontsConstant.MontserratSemiBold, FontsConstant.Size13);
                OldPassword.SetTextColor(ColorConstants.TextGreyColor);
            }


            if (!ButtonConfirmText.IsNull())
            {
                ButtonConfirmText.Text = ButtonConfirmTextString;
                ButtonConfirmText.SetFont(FontsConstant.MontserratSemiBold, FontsConstant.Size15);
                ButtonConfirmText.SetTextColor(ColorConstants.TextWhiteColor);

                ButtonConfirmText.SetBackgroundColor(ColorConstants.BlueColor, type: RadiusType.Aspect);
                ButtonConfirmText.SetSelectedColor(
                    ColorConstants.BlueColor.SelectorTransparence(ColorConstants.Procent50));

                ButtonConfirmText.Click -= ButtonConfirmText_Confirm;
                ButtonConfirmText.Click += ButtonConfirmText_Confirm;
            }

            LineNewView?.SetBackgroundColor(ColorConstants.TextLightGreyColor);
            LineConfirmView?.SetBackgroundColor(ColorConstants.TextLightGreyColor);
            LineOldView?.SetBackgroundColor(ColorConstants.TextLightGreyColor);
        }

        protected override void MenuAction(object sender, EventArgs e)
        {
        }

        private void ButtonConfirmText_Confirm(object sender, EventArgs e)
        {
            if (NewPasswordText.Text.IsNullOrWhiteSpace() ||
                ConfirmPasswordText.Text.IsNullOrWhiteSpace())
            {
                ShowError(FieldIsEmpty);
                return;
            }

            if (NewPasswordText.Text.Length < 6)
            {
                ShowError(NewPasswordTextErrorLessChar);
                return;
            }

            if (NewPasswordText.Text.Length > 25)
            {
                ShowError(NewPasswordErrorLimitChar);
                return;
            }

            if (!NewPasswordText.Text.Equals(ConfirmPasswordText.Text))
            {
                ShowError(ConfirmPasswordErrorText);
                return;
            }

            var newpass = NewPasswordText?.Text;
            var oldPass = OldPassword?.Text;

            UserManager.Instance.UpdateUser(new UserModel
            {
                Password = oldPass,
                NewPassword = newpass
            });

            Show();

            ThreadPool.QueueUserWorkItem(_ =>
                UserManager.Instance.ChangePassword(
                    obj =>
                    {
                        UserManager.Instance.UpdateUser(new UserModel
                        {
                            Password = newpass
                        });
                        Hide();
                        ShowSuccess(SuccesChangePasswordText);
                        // Sleep is given for user can read message. Also Android crashes here because of "window not attached or smth."
                        Thread.Sleep(3200);
                        this.GoPage(PageConstants.LoginName);
                    }, message => ShowError(message)));
        }
    }
}