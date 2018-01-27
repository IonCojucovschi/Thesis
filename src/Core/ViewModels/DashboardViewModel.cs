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

using Core.Helpers;
using Core.Resources.Colors;
using Core.Resources.Drawables;
using Core.Resources.Locales.Page;
using Core.ViewModels.Base;
using Int.Core.Application.Widget.Contract;
using Int.Core.Wrappers.Widget.CrossViewInjection;

namespace Core.ViewModels
{
    public class DashboardViewModel : ProjectNavigationBaseViewModel
    {
        protected override string HeaderText => RDetailItems.DashboardHeaderText.ToUpperInvariant();
        protected override HeaderAreaActionType HeaderAreaAction => HeaderAreaActionType.RightSideMenu;

        private string DashboardWelcomeText => RDetailItems.DashboardWelcomeText;

        [CrossView]
        public IText WelcomeText { get; protected set; }

        [CrossView]
        public IText NameSurnameText { get; protected set; }

        [CrossView]
        public IImage BackgroundImage { get; protected set; }

        public override void UpdateData()
        {
            base.UpdateData();

            BackgroundImage?.SetImageFromResource(DrawableConstants.BackgroundDashboardImage);

            if (WelcomeText != null)
            {
                WelcomeText.SetTextColor(ColorConstants.WhiteColor);
                WelcomeText.SetFont(FontsConstant.MontserratSemiBold, FontsConstant.Size42);
                WelcomeText.Text = DashboardWelcomeText;
            }

            if (NameSurnameText != null)
            {
                NameSurnameText.SetTextColor(ColorConstants.WhiteColor);
                NameSurnameText.SetFont(FontsConstant.MontserratRegular, FontsConstant.Size21);
                NameSurnameText.Text = ConcreteCurrentUser?.FullName;
            }
        }
    }
}