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
using System.Collections.Generic;
using System.Linq;
using Core.Extensions;
using Core.Helpers;
using Core.Helpers.Manager;
using Core.Models.DAL.Account;
using Core.Resources.Colors;
using Core.Resources.Drawables;
using Core.Resources.Locales.Page;
using Core.ViewModels.Base;
using Int.Core.Application.Widget.Contract;
using Int.Core.Application.Widget.Contract.Table;
using Int.Core.Application.Widget.Contract.Table.Adapter;
using Int.Core.Extensions;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using System.Threading;

namespace Core.ViewModels.Account
{
    public class AccountViewModel : ProjectNavigationBaseViewModel
    {
        private string ChangePasswordTextString => RAccount.HeaderAccountText;

        protected override string HeaderText => RAccount.HeaderText.ToUpperInvariant();
        protected override HeaderAreaActionType HeaderAreaAction => HeaderAreaActionType.RightSideMenu;

        [CrossView]
        public IListView ListViewYour { get; protected set; }

        [CrossView]
        public IText ChangePasswordText { get; protected set; }

        [CrossView]
        public IImage ShadowImage { get; protected set; }


        private void ChangePasswordText_Click(object sender, EventArgs e)
        {
            this.GoPage(PageConstants.AccountDescriptionsName);
        }

        public override void UpdateData()
        {
            base.UpdateData();

            ListViewYour?.UpdateDataSource(UserManager.Instance.GetAccount());

            ListViewYour?.SetBackgroundColor(ColorConstants.WhiteColor, CornerRadiusBackground,
                ColorConstants.WhiteColor, 1.0f);

            if (ChangePasswordText == null) return;
            ChangePasswordText.SetBackgroundColor(ColorConstants.BlueColor, type: RadiusType.Aspect);
            ChangePasswordText.SetSelectedColor(
                ColorConstants.WhiteColor.SelectorTransparence(ColorConstants.Procent50));
            ChangePasswordText.Text = ChangePasswordTextString;
            ChangePasswordText.SetTextColor(ColorConstants.WhiteColor);
            ChangePasswordText.SetFont(FontsConstant.MontserratSemiBold, FontsConstant.Size15);

            ShadowImage?.SetImageFromResource(DrawableConstants.ShadowImage);

            ChangePasswordText.Click -= ChangePasswordText_Click;
            ChangePasswordText.Click += ChangePasswordText_Click;
        }

        public override void GoBack()
        {
            base.GoBack();
            UserManager.Instance.ChangeUserModel = null;
        }

        public class AccountCell : ICrossCellViewHolder<ItemAccount>
        {
            private static bool _changeObject = false;

            private readonly ProjectBaseViewModel _baseViewModel;

            private readonly string _saveData = RAccount.SaveDatesFooterButton;

            private IList<ItemAccount> CurentUserUpdate => UserManager.Instance.GetAccount();

            public AccountCell(ProjectBaseViewModel viewModel)
            {
                _baseViewModel = viewModel;
            }

            [CrossView]
            public IView CellContentRootView { get; set; }

            [CrossView]
            public IText Name { get; set; }

            [CrossView]
            public IText Value { get; set; }

            [CrossView]
            public IView DashView { get; set; }

            [CrossView]
            public IText HeaderText { get; set; }

            public void Bind(ItemAccount model)
            {
                _changeObject = false;

                if (Name != null)
                {
                    Name.Text = model?.LabelName;
                    Name.SetTextColor(ColorConstants.TextGreyColor);
                    Name.SetFont(FontsConstant.MontserratRegular, FontsConstant.Size15);
                }

                if (Value != null)
                {
                    Value.SetTextColor(ColorConstants.TextLightGreyColor);
                    Value.SetFont(FontsConstant.MontserratLight, FontsConstant.Size15);
                    Value.SetHintColor(ColorConstants.TextLightGreyColor);
                    Value.Hint = model?.LabelValue;
                    Value.Tag = model?.LabelName;

                    Value.TextChanged -= TextChangeHandler;
                    Value.TextChanged += TextChangeHandler;
                }

                DashView?.SetBackgroundColor(ColorConstants.ExtraLightGrey);
            }

            public void OnCreate() { }

            private void TextChangeHandler(IText sender)
            {
                var userContent = UserManager.Instance.GetAccount();
                if (sender?.Tag == null) return;
                var item = userContent.FirstOrDefault(p => p.LabelName == sender.Tag.ToString());
                var user = CurentUserUpdate.FirstOrDefault(p => p.LabelName == item?.LabelName);

                if (user != null)
                {
                    if (sender?.Text == "")
                    {
                        CurentUserUpdate.FirstOrDefault(p => p.LabelName == user.LabelName).LabelValue = sender?.Hint;
                    }
                    else
                    {
                        _changeObject = true;
                        CurentUserUpdate.FirstOrDefault(p => p.LabelName == user.LabelName).LabelValue = sender?.Text;
                    }
                }
            }

            public void BindFooter(IText button)
            {
                if (button.IsNull()) return;
                button.SetBackgroundColor(ColorConstants.WhiteColor, type: RadiusType.Aspect, borderColor: ColorConstants.BlueColor, borderWidth: 1);
                button.SetTextColor(ColorConstants.BlueColor);
                button.SetFont(FontsConstant.MontserratMedium);
                button.SetSelectedColor(ColorConstants.SemiLightGrey.SelectorTransparence(ColorConstants.Procent50));

                button.Text = _saveData;

                button.Click -= Button_Click;
                button.Click += Button_Click;
            }

            private void Button_Click(object sender, EventArgs e)
            {
                UserManager.Instance.ChangeUserModel.Name = CurentUserUpdate
                    .FirstOrDefault(p => p.TypeLabel == LabelName.FullName)
                    ?.LabelValue.Split(' ').FirstOrDefault();

                UserManager.Instance.ChangeUserModel.Lastname = CurentUserUpdate
                    .FirstOrDefault(p => p.TypeLabel == LabelName.FullName)
                    ?.LabelValue.Split(' ').LastOrDefault();

                UserManager.Instance.ChangeUserModel.Phone = CurentUserUpdate
                    .FirstOrDefault(p => p.TypeLabel == LabelName.Phone)
                    ?.LabelValue;

                UserManager.Instance.ChangeUserModel.Mobile = CurentUserUpdate
                    .FirstOrDefault(p => p.TypeLabel == LabelName.Mobile)
                    ?.LabelValue;

                UserManager.Instance.ChangeUserModel.Address = CurentUserUpdate
                    .FirstOrDefault(p => p.TypeLabel == LabelName.Address)
                    ?.LabelValue;

                UserManager.Instance.ChangeUserModel.Email = CurentUserUpdate
                    .FirstOrDefault(p => p.TypeLabel == LabelName.Email)
                    ?.LabelValue;

                _baseViewModel.Show();

                if (_changeObject)
                {
                    UserManager.Instance.ChangeUserData(
                    message =>
                   {
                       UserManager.Instance.ChangeUserModel = null;

                       ThreadPool.QueueUserWorkItem((a) =>
                       {
                           _baseViewModel.ShowSuccess(message);
                       });

                       _baseViewModel.GoPage(PageConstants.DashboardName);
                   },
                   message => _baseViewModel.ShowError(message));
                }
                else
                {
                    _baseViewModel.ShowError("Enter some data to save on the server!");
                }
            }
        }
    }
}