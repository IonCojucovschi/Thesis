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
using System.Threading;
using Core.Extensions;
using Core.Helpers;
using Core.Helpers.Manager;
using Core.Models.DAL;
using Core.Models.DAL.CategoryBooks;
using Core.Resources.Colors;
using Core.Resources.Drawables;
using Core.Resources.Locales.Page;
using Core.Services;
using Core.ViewModels.Base;
using Int.Core.Application.Widget.Contract;
using Int.Core.Application.Widget.Contract.Table;
using Int.Core.Application.Widget.Contract.Table.Adapter;
using Int.Core.Extensions;
using Int.Core.Wrappers.Widget.CrossViewInjection;

namespace Core.ViewModels
{
    public class WantReadViewModel : ProjectNavigationBaseViewModel
    {
        protected override string HeaderText => "Vreau sa Citesc";///@RDetailItems.ProductHeaderText.ToUpperInvariant();

        protected override HeaderAreaActionType HeaderAreaAction => HeaderAreaActionType.RightSideMenu;


        public virtual ICrossCellViewHolder<IBooklist> CellModel { get; protected set; }

        private IList<IBooklist> ListData;


        [CrossView]
        public IListView ListView { get; protected set; }

        public override void UpdateData()
        {
            base.UpdateData();
            CellModel = new WishBookCell(this);
            var curentCategory = BooksManager.Instance._curentCategory;
            LoadBooks();


        }


        private void LoadBooks()
        {
            Show();
            ThreadPool.QueueUserWorkItem(_ =>
                                         BooksManager.Instance.GetWishedBooksForUser(
                    comunicatesList =>
                    {
                        ListData = comunicatesList;
                        OnPropertyChanged(nameof(ListData));
                        ListView?.UpdateDataSource(ListData);
                        Hide();
                    }, errorMessage => ShowError(errorMessage)));
        }






        #region cell binding

        public class WishBookCell : ICrossCellViewHolder<IBooklist>
        {
            private readonly ProjectNavigationBaseViewModel _baseViewModel;

            public WishBookCell(ProjectNavigationBaseViewModel viewModel)
            {
                _baseViewModel = viewModel;
            }

            [CrossView]
            public IView CellContentRootView { get; set; }

            [CrossView]
            public IText TitleText { get; set; }

            [CrossView]
            public IText AuthorText { get; set; }

            [CrossView]
            public IText DetailText { get; set; }

            [CrossView]
            public IImage ShadowImage { get; set; }

            [CrossView]
            public IImage BookImage { get; set; }

            public void OnCreate() { }

            public void Bind(IBooklist model)
            {
                InitViews();

                if (TitleText != null)
                {
                    TitleText.SetTextColor(ColorConstants.DarkColor);
                    TitleText.SetFont(FontsConstant.MontserratSemiBold, FontsConstant.Size15);
                    TitleText.Text = model.title;
                }

                if (AuthorText != null)
                {
                    AuthorText.SetTextColor(ColorConstants.BlueColor);
                    AuthorText.SetFont(FontsConstant.MontserratLight, FontsConstant.Size15);
                    AuthorText.Text = model.author;
                }


                if (BookImage != null)
                {
                    string download_imageurl = RestConstants.BaseUrl + model.image_linq;

                    BookImage?.SetImageFromUrl(download_imageurl);
                }


                DetailText.Tag = model.id;
            }
            private void InitViews()
            {



                CellContentRootView?.SetBackgroundColor(ColorConstants.WhiteColor, CornerRadiusBackground);
                ShadowImage?.SetImageFromResource(DrawableConstants.ShadowImage);

                DetailText.SetTextColor(ColorConstants.WhiteColor);
                DetailText.SetFont(FontsConstant.MontserratMedium, FontsConstant.Size15);
                DetailText.SetBackgroundColor(ColorConstants.BlueColor, type: RadiusType.Aspect);
                DetailText.Click -= cellContentIsClicked;
                DetailText.Click += cellContentIsClicked;
            }

            private void cellContentIsClicked(object sender, EventArgs e)
            {
                if (!((sender as IView)?.Tag is int BookID)) return;

                var categ = BooksManager.Instance.GetOneBook(BookID);
                _baseViewModel.GoPage(PageConstants.DetailBook);
            }
        }




        #endregion



    }
}