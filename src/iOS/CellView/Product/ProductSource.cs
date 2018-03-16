//
//  DocumentSource.cs
//
//  Author:
//       Songurov <songurov@gmail.com>
//
//  Copyright (c) 2017 Songurov
//
//  This library is free software; you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as
//  published by the Free Software Foundation; either version 2.1 of the
//  License, or (at your option) any later version.
//
//  This library is distributed in the hope that it will be useful, but
//  WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
//  Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public
//  License along with this library; if not, write to the Free Software
//  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA
using System;
using System.Collections.Generic;
using System.Threading;
using Core;
using Core.Models.DAL;
using Core.ViewModels;
using Int.Core.Application.Widget.Contract.Table.Adapter;
using Int.Core.Data.MVVM.Contract;
using Int.Core.Extensions;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.iOS;
using Int.iOS.Extensions;
using Int.iOS.Factories.Adapter.V2;
using Int.iOS.Wrappers.Widget.CrossViewInjection;
using Int.iOS.Wrappers.Widget.FactoryConcreteProducts;
using iOS.Storyboard;
using UIKit;

namespace iOS.CellView.Document
{
    public class ProductSource : ComponentViewSourceExpandable<IItemProducts, IProduct, ProductHeaderCell, ProductChildCell>, ICrossCell
    {
        private IBaseViewModel ModelView => App.Instance.GetView(typeof(WantReadViewModel));
        public ICrossCellViewHolder CrossCellModel => (ModelView as WantReadViewModel)?.CellModel;
        private WantReadViewModel ConcretViewModel => (ModelView as WantReadViewModel);

        public bool FirstLocal { get; set; }

        public UILabel ProductName { get; set; }
        public UILabel ProducCode { get; set; }
        public UIImageView ImageArrow { get; set; }

        public UIView ViewCellHeader { get; set; }
        public UIView ViewCellHeaderLine { get; set; }
        public UIView ViewCellHeaderFooter { get; set; }

        public ProductSource(UITableView tableView, IList<IItemProducts> items, bool singleExpandable = true, bool ignorTableStyle = false)
            : base(tableView, items, singleExpandable, ignorTableStyle) { }

        protected override void OnBindHeader(ProductHeaderCell viewHeader, IItemProducts model, bool expanded, int position)
        {
            ProductName = viewHeader.ProductName;
            ProducCode = viewHeader.ProductCode;
            ImageArrow = viewHeader.ImageArrow;
            ViewCellHeader = viewHeader.ViewCell;
            ViewCellHeaderLine = viewHeader.ViewLineCell;
            ViewCellHeaderFooter = viewHeader.FooterView;

            if (!ModelView.IsNull())
                new CrossViewInjector(this);

            ConcretViewModel.CellModel.Bind(model);
        }

        protected override void OnCollapseCell(int collapsePosition)
        {
            ((ItemProducts)Items[collapsePosition]).Expanded = !((ItemProducts)Items[collapsePosition]).Expanded;
            TableView.ReloadData();
        }


        protected override void OnBindCell(ProductChildCell viewCell, ProductHeaderCell viewHeader, IProduct model, int position, int positionParent)
        {
            (CrossCellModel as WantReadViewModel.ProductCell)?
              .BindHeaderProductDetailSubItem(model, new CrossTextWrapper(viewCell.ProducDocName), new CrossTextWrapper(viewCell.ProductDocValue));

            (CrossCellModel as WantReadViewModel.ProductCell)?
                .BindHeaderProductDocumentSubItem(model, new CrossImageWrapper(viewCell.ImagePdf), new CrossTextWrapper(viewCell.PdfValue));

            if (!model.FilePath.IsNullOrWhiteSpace() && !FirstLocal)
            {
                FirstLocal = true;

                (CrossCellModel as WantReadViewModel.ProductCell)?
                    .BindListSeparator(new CrossViewWrapper(viewCell.ViewLineCell));
            }

            ThreadPool.QueueUserWorkItem(_ =>
            {
                AppTools.InvokeOnMainThread(() =>
                {
                    viewCell.ViewCell.SetCornerRadius(new CoreGraphics.CGSize(0, 0), UIRectCorner.BottomLeft | UIRectCorner.BottomRight);

                    if (Items[positionParent].SubExpandItems.Count - 1 == position)
                    {
                        viewHeader.ViewCell.SetCornerRadius(new CoreGraphics.CGSize(5, 5), UIRectCorner.TopLeft | UIRectCorner.TopRight);
                        viewCell.ViewCell.SetCornerRadius(new CoreGraphics.CGSize(5, 5), UIRectCorner.BottomLeft | UIRectCorner.BottomRight);
                    }
                });
            });
        }

        protected override nfloat HeightHeader
        {
            get
            {
                return 75f;
            }
            set
            {
                base.HeightHeader = value;
            }
        }

        protected override nfloat HeightRow
        {
            get
            {
                return 50f;
            }
            set
            {
                base.HeightRow = value;
            }
        }

        [CrossView(nameof(WantReadViewModel.ProductCell.ProductName))]
        UILabel propName1 => ProductName;

        [CrossView(nameof(WantReadViewModel.ProductCell.ProductCode))]
        UILabel propName2 => ProducCode;

        [CrossView(nameof(WantReadViewModel.ProductCell.ArrowImage))]
        UIImageView propName3 => ImageArrow;

        [CrossView(nameof(WantReadViewModel.ProductCell.CellContentRootView))]
        UIView propName4 => ViewCellHeader;

        [CrossView(nameof(WantReadViewModel.ProductCell.ProductDetailUnderline))]
        UIView propName5 => ViewCellHeaderLine;

        [CrossView(nameof(WantReadViewModel.ProductCell.ViewiOS))]
        UIView propName6 => ViewCellHeaderFooter;
    }
}
