using System;
using System.Collections.Generic;
using Android.Content;
using Android.Views;
using Android.Widget;
using Core;
using Core.Models.DAL;
using Core.ViewModels;
using Int.Core.Application.Widget.Contract.Table.Adapter;
using Int.Core.Data.MVVM.Contract;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Droid.Factories.Adapter;
using Int.Droid.Wrappers;
using Int.Droid.Wrappers.Widget.CrossViewInjection;
using Int.Droid.Wrappers.Widget.FactoryConcreteProducts;
using static Core.ViewModels.ProductViewModel;
using Object = Java.Lang.Object;

namespace Droid.Adapters
{
    partial class ProductsAdapter
    {
        [CrossView(nameof(ProductCell.CellContentRootView))]
        [InjectView(Resource.Id.product_item_part)]
        public View CellContent { get; set; }

        [CrossView(nameof(ProductCell.ProductName))]
        [InjectView(Resource.Id.product_name)]
        public TextView ProductName { get; set; }

        [CrossView(nameof(ProductCell.ProductCode))]
        [InjectView(Resource.Id.product_code)]
        public TextView ProductCode { get; set; }

        [CrossView(nameof(ProductCell.ArrowImage))]
        [InjectView(Resource.Id.arrow_image)]
        public ImageView ArrowImage { get; set; }

        [CrossView(nameof(ProductCell.ShadowImage))]
        [InjectView(Resource.Id.shadow_image_view)]
        public ImageView ShadowImage { get; set; }

        [CrossView(nameof(ProductCell.ProductDetailUnderline))]
        [InjectView(Resource.Id.product_detail_underline)]
        public View ProductDetailUnderline { get; set; }
    }

    public partial class ProductsAdapter : ComponentAdapterFactory<IItemProducts>, ICrossCell
    {
        public ProductsAdapter(Context context = null) : base(context, new List<IItemProducts>())
        {
        }

        private IBaseViewModel ModelView => App.Instance.GetView(typeof(ProductViewModel));

        private ICrossCellViewHolder<IItemProducts> CellModelBinder => (ModelView as ProductViewModel)?.CellModel;

        public ICrossCellViewHolder CrossCellModel => CellModelBinder;

        protected override View GetItemView(IItemProducts model, View convertView, ViewGroup parent)
        {
            var resultView = convertView ?? LayoutInflater.Inflate(Resource.Layout.product, parent, false);
            var containerView = resultView.FindViewById<ViewGroup>(Resource.Id.product_expanded_part);

            containerView?.RemoveAllViews();

            var productModel = model as ItemProducts;
            if (productModel?.Products == null || productModel.Products.Count <= 0) return resultView;

            Cheeseknife.Inject(this, resultView);

            var injector = new CrossViewInjector(this);
            CellModelBinder?.OnCreate();
            CellModelBinder?.Bind(model);

            resultView.SetOnClickListener(new ItemClickListener(() =>
            {
                productModel.Expanded = !productModel.Expanded;
                NotifyDataSetChanged();
            }));

            if (!productModel.Expanded) return resultView;

            foreach (var item in model.Products)
            {
                var productDetailView = LayoutInflater.Inflate(Resource.Layout.item_product_detail_list, null);
                var productDetailLabel = productDetailView.FindViewById<TextView>(Resource.Id.product_detail_label);
                var productDetailValue = productDetailView.FindViewById<TextView>(Resource.Id.product_detail_value);

                if (item.LabelDescription == null && item.ValueDescription == null) continue;

                (CellModelBinder as ProductCell)?.BindHeaderProductDetailSubItem(item,
                    new CrossTextWrapper(productDetailLabel), new CrossTextWrapper(productDetailValue));
                containerView?.AddView(productDetailView);
            }

            var productSeparatorView = LayoutInflater.Inflate(Resource.Layout.item_product_underline, null);
            var productLineSeparator = productSeparatorView.FindViewById<View>(Resource.Id.product_list_separator);

            (CellModelBinder as ProductCell)?.BindListSeparator(new CrossViewWrapper(productLineSeparator));
            containerView?.AddView(productSeparatorView);

            foreach (var item in model.Products)
            {
                var productDocumentView = LayoutInflater.Inflate(Resource.Layout.item_product_document_list, null);
                var productDocumentTitle =
                    productDocumentView.FindViewById<TextView>(Resource.Id.product_document_title);
                var productDocumentImage =
                    productDocumentView.FindViewById<ImageView>(Resource.Id.product_document_type_image);

                if (item?.FileName == null) continue;

                (CellModelBinder as ProductCell)?.BindHeaderProductDocumentSubItem(item,
                    new CrossImageWrapper(productDocumentImage), new CrossTextWrapper(productDocumentTitle));
                containerView?.AddView(productDocumentView);
            }

            return resultView;
        }

        private class ItemClickListener : Object, View.IOnClickListener
        {
            private readonly Action _action;

            public ItemClickListener(Action action)
            {
                _action = action;
            }

            public void OnClick(View v)
            {
                _action?.Invoke();
            }
        }
    }
}