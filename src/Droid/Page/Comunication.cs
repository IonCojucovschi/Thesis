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

using Android.App;
using Android.Content.PM;
using Android.Views;
using Android.Widget;
using Core.Models.DAL;
using Core.ViewModels;
using Droid.Page.Base;
using Int.Core.Application.Widget.Contract.Table.Adapter;
using Int.Core.Wrappers.Widget.CrossViewInjection;
using Int.Droid.Factories.Adapter.RecyclerView;
using Int.Droid.Wrappers;

namespace Droid.Page
{
    [Activity(Label = "Comunication",
        ScreenOrientation = ScreenOrientation.Portrait,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation,
        Theme = "@style/AppTheme")]
    public partial class Comunication : NavigationBasePage<ComunicationViewModel>
    {
        protected override int LayoutContentResource => Resource.Layout.comunication;

        protected override void InitViews()
        {
            base.InitViews();

            ListView.SetAdapter(ComponentAdapterRecyclerFactory.CreateAdapter((inflater, parent) =>
                                new ComunicationCellViewHolder(inflater,
                                               parent,
                                               ModelView.CellModel)));
        }

        public override void OnBackPressed() { }
    }

    public class ComunicationCellViewHolder : ComponentViewHolder<IItemComunication>
    {
        public ComunicationCellViewHolder(LayoutInflater inflator, ViewGroup parent,
            ICrossCellViewHolder<IItemComunication> cellModel)
            : base(inflator.Inflate(Resource.Layout.item_comunication, parent, false), cellModel) { }

        [CrossView(nameof(ComunicationViewModel.ComunicationCell.ComunicationText))]
        [InjectView(Resource.Id.comunication_text)]
        public TextView ComunicationText { get; set; }

        [CrossView(nameof(ComunicationViewModel.ComunicationCell.ComunicationDate))]
        [InjectView(Resource.Id.comunication_date)]
        public TextView ComunicationDate { get; set; }

        [CrossView(nameof(ComunicationViewModel.ComunicationCell.CellContentRootView))]
        [InjectView(Resource.Id.cell_content_root_view)]
        public View CellContent { get; set; }
    }
}