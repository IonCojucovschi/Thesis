using Core.Models.DAL.CategoryBooks;
using Core.ViewModels.Library;
using Foundation;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.iOS.Factories.Adapter;
using iOS.Page.BasePage;
using System;
using System.Collections.Generic;
using UIKit;

namespace iOS.Storyboard
{
    public partial class Library : BasePageSideMenu<LibraryViewModel>
    {
        public Library (IntPtr handle) : base (handle){}

        protected override void BindViews()
        {
            base.BindViews();
            var sourceYour = ComponentViewSourceFactory.CreateForTable(nameof(CategoryCell),
                                                                       new List<ICategoryContent>(),
                                                                       tableLibrary,
                                                                       crossCellModel: new LibraryViewModel.LibraryCell(ModelView));

            tableLibrary.Source = sourceYour;
        }
    }

    public  partial class Library
    {
        [CrossView(nameof(LibraryViewModel.ListView))]
        UITableView prop1 => tableLibrary;

    } 
}