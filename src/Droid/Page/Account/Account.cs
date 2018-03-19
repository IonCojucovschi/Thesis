//
// Splash.cs
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

using Android.App;
using Android.Content.PM;
using Android.Views;
using Android.Widget;
using Core.Models.DAL.Account;
using Core.ViewModels.Account;
using Droid.Page.Base;
using Int.Core.Application.Widget.Contract.Table.Adapter;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Droid.Extensions;
using Int.Droid.Factories.Adapter.RecyclerView;
using Int.Droid.Wrappers;
using Int.Droid.Wrappers.Widget.FactoryConcreteProducts;
using static Core.ViewModels.Account.AccountViewModel;

namespace Droid.Page
{
    [Activity(Label = "Account",
        ScreenOrientation = ScreenOrientation.Portrait,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        Theme = "@style/AppTheme")]
    public partial class Account : NavigationBasePage<AccountViewModel>
    {
        protected override int LayoutContentResource => Resource.Layout.account;

        protected override void InitViews()
        {
            base.InitViews();
            Window.SetSoftInputMode(SoftInput.AdjustPan);
            ListViewYour.OnLayout(() =>
            {
                var gapSize = (((ListViewYour.Parent as View)?.MeasuredWidth ?? 0) - ListViewYour.MeasuredWidth) / 2;
                if (gapSize == 0) return;

                Space1.LayoutParameters.Height =
                    Space2.LayoutParameters.Height = Space3.LayoutParameters.Height = gapSize;
                ChangePasswordText.LayoutParameters.Height = gapSize * 2;
            });

            var titleAccountLabel = FindViewById<TextView>(Resource.Id.account_current_header);

            var accountCellViewModel = new AccountCell(ModelView);
            var adapter = ComponentAdapterRecyclerFactory.CreateAdapter((inflater, parent) =>
                new AccountCellViewHolder(inflater, parent, accountCellViewModel));


            adapter.SetFooter(obj =>
            {
                var viewButton = LayoutInflater.Inflate(Resource.Layout.item_list_acount_footer, obj, false);
                var butonArea = viewButton.FindViewById<TextView>(Resource.Id.save_dates_button);
                var buttonCross = new CrossTextWrapper(butonArea);
                accountCellViewModel.BindFooter(buttonCross);
                return viewButton;
            });

            ListViewYour.SetAdapter(adapter);
        }
    }

    public class AccountCellViewHolder : ComponentViewHolder<ItemAccount>
    {
        public AccountCellViewHolder(LayoutInflater inflator, ViewGroup parent,
            ICrossCellViewHolder<ItemAccount> cellModel)
            : base(inflator.Inflate(Resource.Layout.item_list_account, parent, false), cellModel)
        {
        }

        [CrossView(nameof(AccountCell.Name))]
        [InjectView(Resource.Id.label)]
        public TextView Name { get; set; }

        [CrossView(nameof(AccountCell.Value))]
        [InjectView(Resource.Id.value)]
        public EditText Value { get; set; }

        [CrossView(nameof(AccountCell.DashView))]
        [InjectView(Resource.Id.dash)]
        public View DashView { get; set; }

        [CrossView(nameof(AccountCell.CellContentRootView))]
        [InjectView(Resource.Id.cell_content_root_view)]
        public View CellContentRootView { get; set; }

        #region HeaderText

        // This property is not used in Droid version and declared to suppress exception log warning.
        [CrossView(nameof(AccountCell.HeaderText))]
        [InjectView(Resource.Id.label)]
        public TextView HeaderText { get; set; }

        #endregion

        public override void Bind(ItemAccount model)
        {
            base.Bind(model);

            if (model.TypeLabel == LabelName.Phone || model.TypeLabel == LabelName.Mobile)
                Value.InputType = Android.Text.InputTypes.ClassNumber;



        }
    }
}