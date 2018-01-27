//
// Splash.cs
//
// Author:
//       Songurov Fiodor <songurov@gmail.com>
//
// Copyright (c) 2017 Songurov Fiodor
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System.ComponentModel;
using Android.App;
using Android.Content.PM;
using Android.Views;
using Android.Widget;
using Core.ViewModels;
using Droid.Adapters;
using Droid.Page.Base;
using Int.Droid.Extensions;

namespace Droid.Page
{
    [Activity(Label = "Product",
        ScreenOrientation = ScreenOrientation.Portrait,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        Theme = "@style/AppTheme")]
    public partial class Product : NavigationBasePage<ProductViewModel>
    {
        private const float ListHeaderHeight = 21.0f;
        private ProductsAdapter _adapter;
        protected override int LayoutContentResource => Resource.Layout.list_view;

        protected override void InitViews()
        {
            base.InitViews();

            _adapter = new ProductsAdapter(this);
            ListView.Adapter = _adapter;

            var header = new View(this);
            _adapter.SetHeader(new View(this)
            {
                LayoutParameters = new AbsListView.LayoutParams(ViewGroup.LayoutParams.MatchParent,
                    ListHeaderHeight.Iphone6PointsToDevicePixels())
            });
        }

        private void SetAdapterData()
        {
            _adapter.UpdateDataSource(ModelView.ListData);
        }

        protected override void HandlerViews()
        {
            base.HandlerViews();
            ModelView.PropertyChanged -= ModelView_PropertyChanged;
            ModelView.PropertyChanged += ModelView_PropertyChanged;
        }

        private void ModelView_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(ModelView.ListData))
                SetAdapterData();
        }
    }
}