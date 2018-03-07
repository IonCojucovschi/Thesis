using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using Core.Helpers;
using Core.Helpers.Manager;
using Core.Models.DAL.CategoryBooks;
using Core.Resources.Colors;
using Core.Resources.Drawables;
using Core.Resources.Locales.Page;
using Core.ViewModels.Base;
using Int.Core.Application.Widget.Contract;
using Int.Core.Application.Widget.Contract.Table;
using Int.Core.Application.Widget.Contract.Table.Adapter;
using Int.Core.Wrappers.Widget.CrossViewInjection;

namespace Core.ViewModels.Library
{
    public class LibraryViewModel : ProjectNavigationBaseViewModel
    {
        protected override string HeaderText => "Categorii".ToUpperInvariant();////RDetailItems.ComunicationHeaderText.ToUpperInvariant();///must cchange this code 

        protected override HeaderAreaActionType HeaderAreaAction => HeaderAreaActionType.RightSideMenu;

        private IList<ICategoryContent> ListData;

        [CrossView]
        public IListView ListView { get; protected set; }

        public virtual ICrossCellViewHolder<ICategoryContent> CellModel { get; protected set; }

        public override void UpdateData()
        {
            base.UpdateData();

            CellModel = new LibraryCell(this);
            LoadCategory();
        }



        private void LoadCategory()
        {
            Show();
            ThreadPool.QueueUserWorkItem(_ =>
                BooksManager.Instance.GetCategoryes(
                    comunicatesList =>
                    {
                        ListData = comunicatesList;
                        OnPropertyChanged(nameof(ListData));
                        ListView?.UpdateDataSource(ListData);
                        Hide();
                    }, errorMessage => ShowError(errorMessage)));



        }



        #region cell binding

        public class LibraryCell : ICrossCellViewHolder<ICategoryContent>
        {
            private readonly ProjectNavigationBaseViewModel _baseViewModel;

            public LibraryCell(ProjectNavigationBaseViewModel viewModel)
            {
                _baseViewModel = viewModel;
            }

            [CrossView]
            public IView CellContentRootView { get; set; }

            [CrossView]
            public IText CategoryText { get; set; }

            [CrossView]
            public IText QuantityText { get; set; }

            [CrossView]
            public IImage ShadowImage { get; set; }

            public void OnCreate() { }

            public void Bind(ICategoryContent model)
            {
                InitViews();

                if (CategoryText!=null)
                {
                    CategoryText.SetTextColor(ColorConstants.DarkColor);
                    CategoryText.SetFont(FontsConstant.MontserratSemiBold, FontsConstant.Size15);
                    CategoryText.Text = model.category;
                }

                if (QuantityText!=null)
                {
                    QuantityText.SetTextColor(ColorConstants.BlueColor);
                    QuantityText.SetFont(FontsConstant.MontserratLight, FontsConstant.Size15);
                    QuantityText.Text = model.quantity;
                }
            }

            private void InitViews()
            {
               CellContentRootView?.SetBackgroundColor(ColorConstants.WhiteColor, CornerRadiusBackground);
               ShadowImage?.SetImageFromResource(DrawableConstants.ShadowImage);
            }
        }




        #endregion


    }
}
