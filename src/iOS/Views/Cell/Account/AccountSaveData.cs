//
//  AccountSaveData.cs
//
//  Author:
//       Songurov <songurov@gmail.com>
//
//  Copyright (c) 2017 Songurov
//
//  This library is free software; you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as
//  published by the Free Software Foundation; either version 2.1 of the
//  License, or (at your option) any later version.
//
//  This library is distributed in the hope that it will be useful, but
//  WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU
//  Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public
//  License along with this library; if not, write to the Free Software
//  Foundation, Inc., 59 Temple Place, Suite 330, Boston, MA 02111-1307 USA

using Core.ViewModels.Account;
using Core.ViewModels.Base;
using Int.Core.Extensions;
using Int.iOS.Wrappers.Widget.CrossViewInjection;
using Int.iOS.Wrappers.Widget.FactoryConcreteProducts;
using iOS.Views.Window.Base;

namespace iOS.Views.Cell.Account
{
    public class AccountSaveData
        : ProjectBaseWindow<AccountViewModel>
    {
        private readonly AccountSaveDataView _view;

        public AccountSaveData()
            : base(typeof(AccountSaveDataView))
        {
            _view = CreateObject<AccountSaveDataView>();

            if (!ModelView.IsNull())
                new CrossViewInjector(this);

            var modelConcret = ModelView as ProjectBaseViewModel;

            new AccountViewModel.AccountCell(modelConcret)?.BindFooter(new CrossTextWrapper(_view.ButtonSave));

            modelConcret?.UpdateData();
        }
    }
}
