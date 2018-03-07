﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.ViewModels.Base;
using Int.Core.Application.Widget.Contract.Table;
using Int.Core.Wrappers.Widget.CrossViewInjection;

namespace Core.ViewModels.Library
{
    public class CategoryBooksViewModel : ProjectNavigationBaseViewModel
    {
        protected override string HeaderText => "Toate cartile";

        protected override HeaderAreaActionType HeaderAreaAction =>HeaderAreaActionType.LeftBack;

        [CrossView]
        public IListView ListView { get; protected set; }


    }
}
