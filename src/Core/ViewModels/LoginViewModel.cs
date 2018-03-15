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
using System.Threading;
using Core.Extensions;
using Core.Helpers;
using Core.Helpers.Manager;
using Core.Models.DAL;
using Core.Resources.Colors;
using Core.Resources.Drawables;
using Core.Resources.Locales.Page;
using Core.ViewModels.Base;
using Core.ViewModels.Window;
using Int.Core.Application.Widget.Contract;
using Int.Core.Extensions;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Core.Resources.Settings;

#if __IOS__
using iOS.Views.Window;
using Int.iOS.Window;
#else
using Int.Droid.Window;
using Droid.Views.Window;
#endif

namespace Core.ViewModels
{
    public class LoginViewModel : ProjectBaseViewModel
    {
        private const string NullAuthenticationServiceError = "AuthenticateServiceMock is null";

        private string EmailIsEmptyMessage => RLogin.EmailIsEmptyMessage;
        private string EmailIsInvalidMessage => RLogin.EmailIsInvalidMessage;
        private string PasswordIsEmptyMessage => RLogin.PasswordIsEmptyMessage;

        private string ForgotPasswordLabel => RLogin.ForgotPasswordLabel;
        private string LogInLabel => RLogin.LogInLabel;
        private string RememberMeLable => RLogin.RememberMeLable;

        private string EmailHint => RLogin.EmailHint;
        private string PasswordHint => RLogin.PasswordHint;

        private string EmailValue { get; set; }
        private string PasswordValue { get; set; }

        [CrossView]
        public IImage BackgroundImageView { get; protected set; }

        [CrossView]
        public IView BackgroundUsername { get; protected set; }

        [CrossView]
        public IView BackgroundPassword { get; protected set; }

        [CrossView]
        public IImage ImageView { get; protected set; }

        [CrossView]
        public IText EmailTextView { get; protected set; }

        [CrossView]
        public IText PasswordTextView { get; protected set; }

        [CrossView]
        public IText LoginButton { get; protected set; }

        [CrossView]
        public IImage RememberMeImageView { get; protected set; }

        [CrossView]
        public IImage RememberMeImageWrapper { get; protected set; }

        [CrossView]
        public IText RememberMeTextView { get; protected set; }

        [CrossView]
        public IView RememberMeTouchArea { get; protected set; }

        [CrossView]
        public IText ForgotPasswordTextView { get; protected set; }

        [CrossView]
        public IView ForgotPasswordUndeline { get; protected set; }

        public override void UpdateData()
        {
            WindowShare.Instance.Setting(new ProjectSettingWindow());

            BackgroundImageView?.SetImageFromResource(DrawableConstants.BackgroundImage);
            BackgroundUsername?.SetBackgroundColor(ColorConstants.WhiteColor, type: RadiusType.Aspect);
            BackgroundPassword?.SetBackgroundColor(ColorConstants.WhiteColor, type: RadiusType.Aspect);

            ForgotPasswordUndeline?.SetBackgroundColor(ColorConstants.WhiteColor);

            ImageView?.SetImageFromResource(DrawableConstants.LogoPng);

            if (EmailTextView != null)
            {
                EmailTextView.Hint = EmailHint;
                EmailTextView.SetTextColor(ColorConstants.TextGreyColor);
                EmailTextView.SetHintColor(ColorConstants.TextHintColor);
                EmailTextView.SetFont(FontsConstant.MontserratMedium, FontsConstant.Size13);
            }

            if (PasswordTextView != null)
            {
                if (UserManager.Instance.IsRememberMe())
                {
                    if (EmailTextView != null)
                        EmailTextView.Text = ConcreteCurrentUser?.Username;
                    PasswordTextView.Text = ConcreteCurrentUser?.Password;
                }

                PasswordTextView.Hint = PasswordHint;
                PasswordTextView.SetTextColor(ColorConstants.TextGreyColor);
                PasswordTextView.SetHintColor(ColorConstants.TextHintColor);
                PasswordTextView.SetFont(FontsConstant.MontserratMedium, FontsConstant.Size13);
            }

            if (!ForgotPasswordTextView.IsNull())
            {
                ForgotPasswordTextView.Text = ForgotPasswordLabel;
                ForgotPasswordTextView.SetFont(FontsConstant.MontserratMedium, FontsConstant.Size13);
                ForgotPasswordTextView.SetTextColor(ColorConstants.WhiteColor);
                ForgotPasswordTextView.SetSelectedTextColor(
                    ColorConstants.WhiteColor.SelectorTransparence(ColorConstants.Procent50));
                ForgotPasswordTextView.Click -= ForgotPasswordTextView_Click;
                ForgotPasswordTextView.Click += ForgotPasswordTextView_Click;
            }

            if (RememberMeImageView != null)
                SetRememberMeCheckImage();

            if (RememberMeTextView != null)
            {
                RememberMeTextView.Text = RememberMeLable;
                RememberMeTextView.SetFont(FontsConstant.MontserratRegular, FontsConstant.Size12);
                RememberMeTextView.SetTextColor(ColorConstants.WhiteColor);
                RememberMeTextView.SetSelectedTextColor(
                    ColorConstants.BlueColor.SelectorTransparence(ColorConstants.Procent50));
            }

            if (RememberMeTouchArea != null)
            {
                RememberMeTouchArea.Click -= RememberMeTouchArea_Click;
                RememberMeTouchArea.Click += RememberMeTouchArea_Click;
            }

            if (LoginButton == null) return;

            LoginButton.Text = LogInLabel;
            LoginButton.SetTextColor(ColorConstants.TextGreyColor);
            LoginButton.SetFont(FontsConstant.MontserratBold, FontsConstant.Size13);

            LoginButton.SetBackgroundColor(ColorConstants.YellowColor, type: RadiusType.Aspect);
            LoginButton.SetSelectedColor(ColorConstants.YellowColor.SelectorTransparence(ColorConstants.Procent50));

            LoginButton.Click += (sender, e) =>
            {
                EmailValue = EmailTextView?.Text;
                PasswordValue = PasswordTextView?.Text;
                LoginClickHandler();
            };
        }

        private void RememberMeTouchArea_Click(object sender, EventArgs e)
        {
            UserManager.Instance.ToogleRememberMe();
            SetRememberMeCheckImage();
        }

        private void SetRememberMeCheckImage()
        {
            RememberMeImageView.SetImageFromResource(UserManager.Instance.IsRememberMe()
                ? DrawableConstants.CheckIcon
                : DrawableConstants.UncheckIcon);
        }

        private void ForgotPasswordTextView_Click(object sender, EventArgs e)
        {
            this.GetWindow<ForgotPasswordWindow, ForgotPasswordViewModel>();
        }

        private void LoginClickHandler()
        {
            var validationResult = IsValidCredentials();
            if (!validationResult.Item1)
            {
                ShowError(validationResult.Item2);
                return;
            }

            UserManager.Instance.UpdateUser(new UserModel
            {
                Username = EmailTextView.Text,
                Password = PasswordTextView.Text,
                Remember = UserManager.Instance.IsRememberMe()
            });

            ///Show();

            ThreadPool.QueueUserWorkItem(_ =>
            {
                UserModel usr=new UserModel();
                UserManager.Instance.Login(obj =>
                {
                    Hide();
                    usr=UserManager.Instance.CurrentUser() as UserModel;
                    //usr.Remember = true;
                    if(usr.active==1)this.GoPage(PageConstants.DashboardName);
                   
                }, (obj)=>ShowError(obj));
            });
        }

        private Tuple<bool, string> IsValidCredentials()
        {
            var result = new Tuple<bool, string>(true, string.Empty);

            if (string.IsNullOrWhiteSpace(EmailValue))
                result = new Tuple<bool, string>(false, EmailIsEmptyMessage);

            if (string.IsNullOrWhiteSpace(PasswordValue))
                result = new Tuple<bool, string>(false, PasswordIsEmptyMessage);

            return result;
        }
    }
}