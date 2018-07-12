//
// Service.cs
//
// Author:
//       Sogurov Fiodor <f.songurov@software-dep.net>
//
// Copyright (c) 2016 Songurov
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

using Core.Models.DAL;
using Core.Models.DAL.LocalBooks;
using Core.Services.Repository.Book;
using Core.Services.Repository.User;
using Core.ViewModels;
using Core.ViewModels.Account;
using Core.ViewModels.Library;
using Core.ViewModels.Window;
using Int.Core.Data.Repository.Akavache.Contract;
using Int.Core.Data.Service;

namespace Core.Services
{
    public class Service : BaseService<Service>
    {
        #region Repository

        private readonly IRepository<UserModel> _userData = new UserRepository();
        private readonly IRepository<LocalBook> _localBook = new LocalBookRepository();

        #endregion

        public override void Start()
        {
            base.Start();

            AddRepository();
            RegisterViewModel();
        }

        private void AddRepository()
        {
            ServiceRepository.UnitOfWork.Add(typeof(UserModel), _userData);
            ServiceRepository.UnitOfWork.Add(typeof(LocalBook), _localBook);
        }

        private void RegisterViewModel()
        {
            ServiceViewModel.RegisterViewModel(new SplashViewModel());
            ServiceViewModel.RegisterViewModel(new LoginViewModel());

            ServiceViewModel.RegisterViewModel(new DashboardViewModel());
            ServiceViewModel.RegisterViewModel(new LogoutViewModel());
            ServiceViewModel.RegisterViewModel(new ForgotPasswordViewModel());

            ServiceViewModel.RegisterViewModel(new AccountViewModel());
            ServiceViewModel.RegisterViewModel(new AccountDescriptionsViewModel());

            ServiceViewModel.RegisterViewModel(new ContactViewModel());
            ServiceViewModel.RegisterViewModel(new UserAddedBooksViewModel());
            ServiceViewModel.RegisterViewModel(new WantReadViewModel());

            ServiceViewModel.RegisterViewModel(new LibraryViewModel());
            ServiceViewModel.RegisterViewModel(new CategoryBooksViewModel());
            ServiceViewModel.RegisterViewModel(new BookDetailsViewModel());
            ServiceViewModel.RegisterViewModel(new LocalBooksViewModel());
        }
    }
}