using System;
using System.Collections.Generic;
using System.Text;
using Core.ViewModels.Base;
using Core.Models.DAL.CategoryBooks;
using Core.Helpers.Manager;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Core.Application.Widget.Contract;

namespace Core.ViewModels.Library
{
    public class BookDetailsViewModel : ProjectNavigationBaseViewModel
    {
        protected override string HeaderText => "Detalii carte";
        protected override HeaderAreaActionType HeaderAreaAction => HeaderAreaActionType.LeftBack;
        public IBooklist curenBook;

        public override void UpdateData()
        {
            base.UpdateData();
            curenBook = BooksManager.Instance._curentBook;

        }

        [CrossView]
        public IImage BookImage { get; set; }

        [CrossView]
        public IText DownloadText { get; set; }

        [CrossView]
        public IText ReadText { get; set; }

        [CrossView]
        public IText TitleText { get; set; }

        [CrossView]
        public IText AuthorText { get; set; }

        [CrossView]
        public IText CategoryText { get; set; }

        [CrossView]
        public IText RatingText { get; set; }

        [CrossView]
        public IText NmbDownloadText { get; set; }

        [CrossView]
        public IText DescriptionText { get; set; }


    }
}
