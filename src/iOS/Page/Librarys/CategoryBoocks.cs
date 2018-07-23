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
    public partial class CategoryBoocks : BasePageSideMenu<CategoryBooksViewModel>
    {
        public CategoryBoocks(IntPtr handle) : base(handle) { }

        protected override void BindViews()
        {
            base.BindViews();
            var sourceYour = ComponentViewSourceFactory.CreateForTable(nameof(BookCell),
                                                                       new List<IBooklist>(),
                                                                       tableCategory,
                                                                       crossCellModel: new CategoryBooksViewModel.CategoryBookCell(ModelView));

            tableCategory.Source = sourceYour;
        }


    }



    public partial class CategoryBoocks
    {
        [CrossView(nameof(CategoryBooksViewModel.ListView))]
        UITableView prop1 => tableCategory;
    }



}