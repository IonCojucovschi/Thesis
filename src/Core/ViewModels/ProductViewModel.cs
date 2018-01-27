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

using System.Collections.Generic;
using System.Threading;
using Core.Helpers;
using Core.Helpers.Manager;
using Core.Models.DAL;
using Core.Resources.Colors;
using Core.Resources.Drawables;
using Core.Resources.Locales.Page;
using Core.ViewModels.Base;
using Int.Core.Application.Widget.Contract;
using Int.Core.Application.Widget.Contract.Table.Adapter;
using Int.Core.Extensions;
using Int.Core.Wrappers.Widget.CrossViewInjection;

namespace Core.ViewModels
{
    public class ProductViewModel : ProjectNavigationBaseViewModel
    {
        protected override string HeaderText => @RDetailItems.ProductHeaderText.ToUpperInvariant();

        protected override HeaderAreaActionType HeaderAreaAction => HeaderAreaActionType.RightSideMenu;

        public IList<IItemProducts> ListData { get; protected set; }

        public virtual ICrossCellViewHolder<IItemProducts> CellModel { get; protected set; }

        public override void UpdateData()
        {
            base.UpdateData();

            CellModel = new ProductCell(this);

            LoadProducts();
        }

        private void LoadProducts()
        {
            Show();
            ThreadPool.QueueUserWorkItem(_ =>
                ContractManager.Instance.GetProductsList(
                    contractList =>
                    {
                        ListData = contractList;
                        OnPropertyChanged(nameof(ListData));
                        Hide();
                    }, errorMessage => ShowError(errorMessage)));
        }


        #region CellBinding

        public class ProductCell : ICrossCellViewHolder<IItemProducts>
        {
            private readonly ProjectNavigationBaseViewModel _baseViewModel;
            private string _filePath;

            public ProductCell(ProjectNavigationBaseViewModel viewModel)
            {
                _baseViewModel = viewModel;
            }

            [CrossView]
            public IView CellContentRootView { get; set; }

            [CrossView]
            public IView ViewiOS { get; set; }

            [CrossView]
            public IText ProductName { get; set; }

            [CrossView]
            public IText ProductCode { get; set; }

            [CrossView]
            public IImage ArrowImage { get; set; }

            [CrossView]
            public IImage ShadowImage { get; set; }

            [CrossView]
            public IView ProductDetailUnderline { get; set; }

            public void OnCreate() { }

            public void Bind(IItemProducts model)
            {
                CellContentRootView?.SetBackgroundColor(ColorConstants.WhiteColor, CornerRadiusBackground);
                ShadowImage?.SetImageFromResource(DrawableConstants.ShadowImage);

                if (ProductName != null)
                {
                    ProductName.SetTextColor(ColorConstants.DarkColor);
                    ProductName.SetFont(FontsConstant.MontserratSemiBold, FontsConstant.Size15);
                    ProductName.Text = model.LabelProduct.UpperCaseWords();
                }

                if (ProductCode != null)
                {
                    ProductCode.SetTextColor(ColorConstants.DarkColor);
                    ProductCode.SetFont(FontsConstant.MontserratRegular, FontsConstant.Size15);
                    ProductCode.Text = model.ValueProduct.UpperCaseWords().Replace(" ", "");
                }

                if (!(model is ItemProducts modelProduct)) return;

                if (modelProduct.Expanded)
                {
                    ArrowImage?.SetImageFromResource(DrawableConstants.ArrowUp);
                    ProductDetailUnderline?.SetBackgroundColor(ColorConstants.LightView);  
                    if(ViewiOS != null)
                        ViewiOS.Visibility = ViewState.Visible;
                }
                else
                {
                    ArrowImage?.SetImageFromResource(DrawableConstants.ArrowDown);
                    ProductDetailUnderline?.SetBackgroundColor(ColorConstants.TransparentColor);
                    CellContentRootView?.SetBackgroundColor(ColorConstants.WhiteColor, CornerRadiusBackground);
                    if(ViewiOS != null)
                        ViewiOS.Visibility = ViewState.Invisible;
                }
            }

            public void BindHeaderProductDetailSubItem(IProduct model, IText productDetailLabel,
                IText productDetailValue)
            {
                if (productDetailLabel != null)
                {
                    productDetailLabel.Text = model?.LabelDescription;
                    productDetailLabel.SetTextColor(ColorConstants.DarkColor);
                    productDetailLabel.SetFont(FontsConstant.MontserratLight, FontsConstant.Size15);
                }

                if (productDetailValue != null)
                {
                    productDetailValue.Text = model?.ValueDescription;
                    productDetailValue.SetTextColor(model?.StatusColor);
                    productDetailValue.SetFont(FontsConstant.MontserratLight, FontsConstant.Size15);
                }
            }

            public void BindHeaderProductDocumentSubItem(IProduct model, IImage productDocumentType,
                IText productDocumentTitle)
            {
                if (productDocumentTitle == null) return;
                productDocumentTitle.Text = model?.FileName;
                productDocumentTitle.SetFont(FontsConstant.MontserratLight, FontsConstant.Size15);
                _filePath = model?.FilePath;

                if (model == null || model.FilePath.IsNullOrWhiteSpace()) return;
                switch (model.FileStatus)
                {
                    case 0:
                        productDocumentType.SetImageFromResource(DrawableConstants.PDF);
                        productDocumentTitle.SetTextColor(ColorConstants.LightView);
                        break;
                    case 1:
                        productDocumentType.SetImageFromResource(DrawableConstants.PdfStatusOk);
                        productDocumentTitle.SetTextColor(ColorConstants.DarkColor);
                        productDocumentType.Click += ProductDocumentTitle_Click;
                        productDocumentTitle.Click += ProductDocumentTitle_Click;
                        break;
                    case 3:
                        productDocumentTitle.SetTextColor(ColorConstants.RedColor);
                        productDocumentType.SetImageFromResource(DrawableConstants.PDF);
                        break;
                }
            }

            private void ProductDocumentTitle_Click(object sender, System.EventArgs e)
            {
                _baseViewModel.OpenLink(_filePath);
            }

            public void BindListSeparator(IView listSeparator)
            {
                listSeparator?.SetBackgroundColor(ColorConstants.LightView);
            }
        }

#endregion
    }
}