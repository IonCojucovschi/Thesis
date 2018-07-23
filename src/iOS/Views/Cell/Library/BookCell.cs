using Core.Models.DAL.CategoryBooks;
using Core.ViewModels.Library;
using Foundation;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.iOS.Factories.Adapter.CellView;
using System;
using UIKit;
using Int.Core.Wrappers.Widget.Exceptions;

namespace iOS
{
    public partial class BookCell : ComponentTableViewCell<IBooklist>
    {
        public BookCell(IntPtr handle) : base(handle) { }


        [CrossView(nameof(CategoryBooksViewModel.CategoryBookCell.CellContentRootView))]
        UIView prrop0 => Root;

        [CrossView(nameof(CategoryBooksViewModel.CategoryBookCell.AuthorText))]
        UILabel prrop1 => authorName;

        [CrossView(nameof(CategoryBooksViewModel.CategoryBookCell.DetailText))]
        UILabel prrop2 => detailsButton;

        [CrossView(nameof(CategoryBooksViewModel.CategoryBookCell.TitleText))]
        UILabel prrop3 => bookName;

        [CrossView(nameof(CategoryBooksViewModel.CategoryBookCell.BookImage))]
        UIImageView prrop4 => bookImage;

    }
}