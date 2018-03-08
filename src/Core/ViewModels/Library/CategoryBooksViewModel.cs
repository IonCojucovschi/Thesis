using System;
using System.Collections.Generic;
using System.Text;
using Core.Helpers.Manager;
using Core.ViewModels.Base;
using Int.Core.Application.Widget.Contract.Table;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Core.Application.Widget.Contract.Table.Adapter;
using Core.Models.DAL.CategoryBooks;
using Int.Core.Application.Widget.Contract;
using Core.Resources.Colors;
using Core.Helpers;
using Core.Resources.Drawables;
using Core.Extensions;
using System.Threading;

namespace Core.ViewModels.Library
{
    public class CategoryBooksViewModel : ProjectNavigationBaseViewModel
    {
        protected override string HeaderText => "Toate cartile";

        protected override HeaderAreaActionType HeaderAreaAction =>HeaderAreaActionType.LeftBack;

        public virtual ICrossCellViewHolder<IBooklist> CellModel { get; protected set; }

        private IList<IBooklist> ListData;


        [CrossView]
        public IListView ListView { get; protected set; }

        public override void UpdateData()
        {
            base.UpdateData();
            CellModel = new CategoryBookCell(this);
            var curentCategory = BooksManager.Instance._curentCategory;
            LoadBooks();


        }


        private void LoadBooks()
        {
            Show();
            ThreadPool.QueueUserWorkItem(_ =>
                BooksManager.Instance.GetBooks(
                    comunicatesList =>
                    {
                        ListData = comunicatesList;
                        OnPropertyChanged(nameof(ListData));
                        ListView?.UpdateDataSource(ListData);
                        Hide();
                    }, errorMessage => ShowError(errorMessage)));
        }






        #region cell binding

        public class CategoryBookCell : ICrossCellViewHolder<IBooklist>
        {
            private readonly ProjectNavigationBaseViewModel _baseViewModel;

            public CategoryBookCell(ProjectNavigationBaseViewModel viewModel)
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
