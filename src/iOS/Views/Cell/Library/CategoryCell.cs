using Core.Models.DAL.CategoryBooks;
using Core.ViewModels.Library;
using Foundation;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.iOS.Factories.Adapter.CellView;
using System;
using UIKit;

namespace iOS
{
    public partial class CategoryCell : ComponentTableViewCell<ICategoryContent>
    {
        public CategoryCell (IntPtr handle) : base (handle){}


        [CrossView(nameof(LibraryViewModel.LibraryCell.CellContentRootView))]
        UIView prrop0 => Root;

        [CrossView(nameof(LibraryViewModel.LibraryCell.CategoryImage))]
        UIImageView prop1 => categoryImage;

        [CrossView(nameof(LibraryViewModel.LibraryCell.CategoryText))]
        UILabel prop2 => categoryName;

        [CrossView(nameof(LibraryViewModel.LibraryCell.QuantityText))]
        UILabel prop3 => categoryQantity;


    }
}