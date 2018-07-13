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
///using Com.Bumptech.Glide;
using Core.Services;
namespace Core.ViewModels.Library
{
    public class ReadBookViewModel:ProjectNavigationBaseViewModel
    {
       
        protected override string HeaderText =>"Previzualizare";

        protected override HeaderAreaActionType HeaderAreaAction => HeaderAreaActionType.LeftBack;

        [CrossView]
        public IView WebView { get; set; }

        public override void UpdateData()
        {
            base.UpdateData();
        }
    }
}
