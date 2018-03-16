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
using static Core.ViewModels.WantReadViewModel;
using Object = Java.Lang.Object;

namespace Droid.Adapters
{
   
    public partial class ProductsAdapter : ComponentAdapterFactory<IItemProducts>, ICrossCell
    {
       
    }
}