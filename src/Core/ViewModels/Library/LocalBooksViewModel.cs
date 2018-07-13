using System;
using System.Collections.Generic;
using Core.Extensions;
using Core.Helpers;
using Core.Helpers.Manager;
using Core.Models.DAL.LocalBooks;
using Core.Resources.Colors;
using Core.Resources.Drawables;
using Core.ViewModels.Base;
using Int.Core.Application.Widget.Contract;
using Int.Core.Application.Widget.Contract.Table;
using Int.Core.Application.Widget.Contract.Table.Adapter;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Java.IO;

namespace Core.ViewModels.Library
{
    public class LocalBooksViewModel: ProjectNavigationBaseViewModel
    {
        protected override string HeaderText => "Carti Descarcate";
        protected override HeaderAreaActionType HeaderAreaAction => HeaderAreaActionType.RightSideMenu;
        public List<LocalBook> localBooksList;

        public virtual ICrossCellViewHolder<LocalBook> CellModel { get; protected set; }

         
        string pathDIR = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;//Android.App.Application.Context.FilesDir.AbsolutePath.ToString();


        public override void UpdateData()
        {
            base.UpdateData();
            List<LocalBook> books;
            if(LocalBooksManager.Instance.GetAllBookcsFromDB().Count == 0)
            {
                 books = LocalBooksManager.Instance.GetAllBooksListFromDevidce(new File(pathDIR), pathDIR);
                books = LocalBooksManager.Instance.GetAllBookcsFromDB();
            }else
            {
                books = LocalBooksManager.Instance.GetAllBookcsFromDB();
            }
            CellModel = new LocalBooksCell(this);

            ListView?.UpdateDataSource(books); 
            InitializeView();
        }

        [CrossView]
        public IListView ListView { get; protected set; }

        [CrossView]
        public IText RefreshButton { get; set; }

        [CrossView]
        public IText DeleteButton { get; set; }


        private void InitializeView()
        {
            if(RefreshButton!=null)
            {
                RefreshButton.Text = "Improspateaza"; 
                RefreshButton.SetTextColor(ColorConstants.WhiteColor);
                RefreshButton.SetFont(FontsConstant.MontserratMedium, FontsConstant.Size15);
                RefreshButton.SetBackgroundColor(ColorConstants.BlueColor, type: RadiusType.Aspect);

                RefreshButton.Click -= RefreshClicked;
                RefreshButton.Click += RefreshClicked;
            }

            if(DeleteButton!=null)
            {
                DeleteButton.Text = "Sterge";
                DeleteButton.SetTextColor(ColorConstants.WhiteColor);
                DeleteButton.SetFont(FontsConstant.MontserratMedium, FontsConstant.Size15);
                DeleteButton.SetBackgroundColor(ColorConstants.BlueColor, type: RadiusType.Aspect);

                DeleteButton.Click -= DeleteClicked;
                DeleteButton.Click += DeleteClicked;
            }




        }

        private void RefreshClicked(object o,EventArgs e)
        {
            LocalBooksManager.Instance.RefreshBookDB();
        }

        private void DeleteClicked(object o, EventArgs e)
        {
            LocalBooksManager.Instance.ClearAllLocalBooks();
        }

        #region cell binding

        public class LocalBooksCell : ICrossCellViewHolder<LocalBook>
        {
            private readonly ProjectNavigationBaseViewModel _baseViewModel;

            public LocalBooksCell(ProjectNavigationBaseViewModel viewModel)
            {
                _baseViewModel = viewModel;
            }

            [CrossView]
            public IView CellContentRootView { get; set; }

            [CrossView]
            public IText BookName { get; set; }

            [CrossView]
            public IText PageNumber { get; set; }

            public void OnCreate() { }

           
            public void Bind(LocalBook model)
            {
                InitViews();

                if (BookName != null)
                {
                    BookName.SetTextColor(ColorConstants.DarkColor);
                    BookName.SetFont(FontsConstant.MontserratSemiBold, FontsConstant.Size15);
                    BookName.Text = model.Name;
                }

                if (PageNumber != null)
                {
                    PageNumber.SetTextColor(ColorConstants.BlueColor);
                    PageNumber.SetFont(FontsConstant.MontserratLight, FontsConstant.Size15);
                    PageNumber.Text = ""+model.LastPage;
                }
                CellContentRootView.Tag = model.Id;//CategoryText.Text;
            }
            private void InitViews()
            {
                CellContentRootView?.SetBackgroundColor(ColorConstants.WhiteColor, CornerRadiusBackground);

                CellContentRootView.Click -= CellContentIsClicked;
                CellContentRootView.Click += CellContentIsClicked;
            }
            private void CellContentIsClicked(object sender, EventArgs e)
            {
                if (!((sender as IView)?.Tag is int bookCurentID)) return;
                LocalBooksManager.Instance.GetCurentBook(bookCurentID);

                _baseViewModel.GoPage(PageConstants.ReadContentBook);
            }

        }
         #endregion

    }
}
