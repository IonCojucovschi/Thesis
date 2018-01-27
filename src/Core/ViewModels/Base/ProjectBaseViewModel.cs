//
// BasePageViewModel.cs
//
// Author:
//       Songurov Fiodor <songurov@gmail.com>
//
// Copyright (c) 2016 Songurov Fiodor
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
using Core.Helpers.Manager;
using Core.Models.DAL;
using Core.Resources.Page;
using Int.Core.Application.Exception;
using Int.Core.Application.Widget.Contract;
using Int.Core.Application.Window.Contract;
using Int.Core.Wrappers.Widget.CrossViewInjection;

#if __IOS__
using Int.iOS.Data.MVVM;
using Int.iOS.Window;
#else
using Int.Droid.Data.MVVM;
using Int.Droid.Window;
#endif

namespace Core.ViewModels.Base
{
    public abstract class ProjectBaseViewModel : BaseNativeViewModel
    {
        protected const float CornerRadiusBackground = 5.0f;
        protected const float CornerRadiusButton = 7.0f;

        [CrossView]
        public IView RootView { get; protected set; }

        public float CornerRadiusSideMenu => 10.0f;

        protected UserModel ConcreteCurrentUser => UserManager.Instance.CurrentUser() as UserModel;

        public override void OnPause() { }

        #region IDialog

        public override void Hide()
        {
            try
            {
                WindowShare.Instance.Hide();
            }
            catch (Exception e)
            {
                ExceptionLogger.RaiseNonFatalException(e);
            }
        }

        public override void Show()
        {
            Hide();
            try
            {
                WindowShare.Instance.Show(RShare.Wait, null);
            }
            catch (Exception e)
            {
                ExceptionLogger.RaiseNonFatalException(e);
            }
        }

        public override void Show(string text)
        {
            Hide();
            try
            {
                WindowShare.Instance.Show(text, TimeIWindow.Normal);
            }
            catch (Exception e)
            {
                ExceptionLogger.RaiseNonFatalException(e);
            }
        }

        public override void ShowSuccess(string message = "", int timeSecond = 3)
        {
            Hide();
            try
            {
                WindowShare.Instance.ShowSuccess(message, TimeIWindow.Normal);
            }
            catch (Exception e)
            {
                ExceptionLogger.RaiseNonFatalException(e);
            }
        }

        public override void ShowError(string message = "", int timeSecond = 3)
        {
            Hide();
            try
            {
                WindowShare.Instance.ShowError(message, TimeIWindow.Normal);
            }
            catch (Exception e)
            {
                ExceptionLogger.RaiseNonFatalException(e);
            }
        }

        #endregion
    }
}