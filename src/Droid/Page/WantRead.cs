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

using System.ComponentModel;
using Android.App;
using Android.Content.PM;
using Android.Views;
using Android.Widget;
using Core.Models.DAL.CategoryBooks;
using Core.ViewModels;
using Droid.Page.Base;
using Int.Core.Application.Widget.Contract.Table.Adapter;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Droid.Extensions;
using Int.Droid.Factories.Adapter.RecyclerView;
using Int.Droid.Wrappers;

namespace Droid.Page
{
    [Activity(Label = "Product",
        ScreenOrientation = ScreenOrientation.Portrait,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        Theme = "@style/AppTheme")]
    public partial class WantRead : NavigationBasePage<WantReadViewModel>
    {
        private const float ListHeaderHeight = 21.0f;
        protected override int LayoutContentResource => Resource.Layout.category_books_view;

        protected override void InitViews()
        {
            base.InitViews();

            ListView.SetAdapter(ComponentAdapterRecyclerFactory.CreateAdapter((inflater, parent) =>
                                                                          new BooksCellViewHolder(inflater, parent, ModelView.CellModel)));

            // Create your application here
        }
    }
    public class WishCellViewHolder : ComponentViewHolder<IBooklist>
    {
        public WishCellViewHolder(LayoutInflater inflator, ViewGroup parent,
                                     ICrossCellViewHolder<IBooklist> cellModel)
            : base(inflator.Inflate(Resource.Layout.item_list_book, parent, false), cellModel) { }

        [CrossView(nameof(WantReadViewModel.WishBookCell.TitleText))]
        [InjectView(Resource.Id.title_item)]
        public TextView TitleText { get; set; }

        [CrossView(nameof(WantReadViewModel.WishBookCell.AuthorText))]
        [InjectView(Resource.Id.author_item)]
        public TextView AuthorText { get; set; }

        [CrossView(nameof(WantReadViewModel.WishBookCell.DetailText))]
        [InjectView(Resource.Id.detail_item)]
        public TextView DetailText { get; set; }

        [CrossView(nameof(WantReadViewModel.WishBookCell.BookImage))]
        [InjectView(Resource.Id.image_for_book_item)]
        public FFImageLoading.Views.ImageViewAsync BookImage { get; set; }

        [CrossView(nameof(WantReadViewModel.WishBookCell.CellContentRootView))]
        [InjectView(Resource.Id.cell_content_root_view)]
        public View CellContent { get; set; }
    }
}