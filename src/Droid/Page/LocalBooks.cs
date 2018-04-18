
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Core.ViewModels.Library;
using Droid.Page.Base;
using Core.Helpers.Manager;
using Java.IO;
using Int.Droid.Factories.Adapter.RecyclerView;
using Int.Core.Application.Widget.Contract.Table.Adapter;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Droid.Wrappers;
using Core.Models.DAL.LocalBooks;

namespace Droid.Page
{
    [Activity(Label = "LocalBooks",
              ScreenOrientation = ScreenOrientation.Portrait, MainLauncher = false,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        Theme = "@style/AppTheme")]
    public partial class LocalBooks : NavigationBasePage<LocalBooksViewModel>
    {
        protected override int LayoutContentResource =>Resource.Layout.category_books_view;

        protected override void InitViews()
        {
            base.InitViews();

            LoadLocalBooks();
            // Create your application here
        }
        //LocalBooksManager bookManger=new LocalBooksManager();
        string pathDIR = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath.ToString();//Android.App.Application.Context.FilesDir.AbsolutePath.ToString();
        private void LoadLocalBooks()
        {
           // var books = bookManger.GetAllBooksListFromDevidce(new File(pathDIR), pathDIR);
            //var booksFromDB = bookManger.GetAllBookcsFromDB();
            ListView.SetAdapter(ComponentAdapterRecyclerFactory.CreateAdapter((inflater, parent) =>
                                                                              new LocalBooksCellViewHolder(inflater,
                                              parent,
                                              ModelView.CellModel)));

        }



    }
    public class LocalBooksCellViewHolder : ComponentViewHolder<LocalBook>
    {
        public LocalBooksCellViewHolder(LayoutInflater inflator, ViewGroup parent,
                                        ICrossCellViewHolder<LocalBook> cellModel)
            : base(inflator.Inflate(Resource.Layout.local_book_item_list, parent, false), cellModel) { }

        [CrossView(nameof(LocalBooksViewModel.LocalBooksCell.BookName))]
        [InjectView(Resource.Id.nameBook_file)]
        public TextView BookName { get; set; }

        [CrossView(nameof(LocalBooksViewModel.LocalBooksCell.PageNumber))]
        [InjectView(Resource.Id.last_readed_page)]
        public TextView PageNumber { get; set; }

        [CrossView(nameof(LocalBooksViewModel.LocalBooksCell.CellContentRootView))]
        [InjectView(Resource.Id.cell_root_view)]
        public LinearLayout CellContentRootView { get; set; }


    }
}
