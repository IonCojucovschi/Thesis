

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