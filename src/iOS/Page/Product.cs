// This file has been autogenerated from a class added in the UI designer.

using System;
using iOS.Page.BasePage;
using Core.ViewModels;
using iOS.CellView.Document;
using Core.Models.DAL;
using Int.iOS.Factories.Adapter.V2.ExpandableSource;
using System.Collections.Generic;

namespace iOS.Storyboard
{
    public partial class Product : BasePageSideMenu<WantReadViewModel>
    {
        private ProductSource _source;

        public Product(IntPtr handle) : base(handle) { }

        protected override void BindViews()
        {
            base.BindViews();

            _source = new ProductSource(TableView, new List<IItemProducts>());
            TableView.Source = _source;
        }

        protected override void HandlerViews()
        {
            base.HandlerViews();

            ModelView.PropertyChanged -= ModelView_PropertyChanged;
            ModelView.PropertyChanged += ModelView_PropertyChanged;

            _source.ParentRowClicked -= _source_ParentRowClicked;
            _source.ParentRowClicked += _source_ParentRowClicked;
        }

        private void _source_ParentRowClicked(object sender, RowParentClickEventArgs<IItemProducts> e)
        {
            ((ItemProducts)e.Model).Expanded = true;
            TableView.ReloadData();
        }

        private void SetAdapterData()
        {
            _source.UpdateDataSource(ModelView.ListData);
        }

        private void ModelView_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ModelView.ListData))
                SetAdapterData();
        }
    }
}
