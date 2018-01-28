//
//  UserManager.cs
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

using System;
using System.Collections.Generic;
using System.Linq;
using Core.Models.DAL;
using Core.Models.DAL.Account;
using Core.Models.DTO;
using Core.Resources.Locales.Page;
using Core.Services;
using Int.Core.Application.Contract;
using Int.Core.Application.Login.Contract;
using Int.Core.Data.Repository.Akavache.Contract;
using Int.Core.Extensions;
using Int.Core.Network.Singleton;
using Splat;

namespace Core.Helpers.Manager
{
    public class UserManager : Singleton<UserManager>
    {
        private readonly IRepositoryWithId<UserModel> _userAccountRep =
            Service.Instance.ServiceRepository.UnitOfWork.GetFeedRepository<UserModel>();

        private ChangeUserDataModel _changeUserModel;
        private string FullName => RUserManager.FullName;
        private string Adress => RUserManager.Address;
        private string Phone => RUserManager.Phone;
        private string Mobile => RUserManager.Mobile;
        private string Email => RUserManager.Email;
        private string NoPhone => RUserManager.NoPhone;
        private string NoEmail => RUserManager.NoEmail;

        public ChangeUserDataModel ChangeUserModel
        {
            get
            {
                _changeUserModel = _changeUserModel ?? new ChangeUserDataModel();
                return _changeUserModel;
            }
            set => _changeUserModel = value;
        }

        private static ILogin GetService =>
            Locator.Current.GetService<ILogin>(App.Instance.IsMock ? App.ServiceContractMock : App.ServiceContract);

        public IUser CurrentUser()
        {
            return _userAccountRep.GetAll()?.FirstOrDefault();
        }

        public bool IsRememberMe()
        {
            return !CurrentUser().IsNull() &&
                   ((UserModel)CurrentUser()).Remember;
        }

        private List<ItemAccount> _account;

        public IList<ItemAccount> GetAccount()
        {
            var user = CurrentUser() as UserModel;
            if (user.IsNull()) return default(IList<ItemAccount>);

            if (user != null)
            {
                if (_account.IsNull())
                {
                    _account = new List<ItemAccount>
                    {
                        new ItemAccount
                        {
                            LabelName = FullName,
                            LabelValue = user.FullName,
                            TypeLabel = LabelName.FullName
                        },
                        new ItemAccount
                        {
                            LabelName = Adress,
                            LabelValue = user.Name,
                            TypeLabel = LabelName.Address
                        },

                        new ItemAccount
                        {
                            LabelName = Phone,
                            LabelValue = user.Profile.Mobile.IsNullOrWhiteSpace()
                                ? NoPhone
                                : user.Profile.Mobile,
                            TypeLabel = LabelName.Phone
                        },
                        new ItemAccount
                        {
                            LabelName = Mobile,
                            LabelValue = user.Mobile.IsNullOrWhiteSpace()
                                ?NoPhone
                                :user.Profile.Mobile,
                            TypeLabel = LabelName.Mobile
                        },

                        new ItemAccount
                        {
                            LabelName = Email,
                            LabelValue = user.Profile.Email.IsNullOrWhiteSpace() ? NoEmail : user.Profile.Email,
                            TypeLabel = LabelName.Email
                        }
                    };
                }
            }

            return _account;
        }

        public void ToogleRememberMe(bool? value = null)
        {
            var user = CurrentUser() as UserModel ?? new UserModel
            {
                Remember = true
            };

            if (value.HasValue)
                user.Remember = value.Value;
            else
                user.Remember = !user.Remember;

            UpdateUser(user);
        }

        public void UpdateUser(IUser user)
        {
            var userCurrent = _userAccountRep.GetAll().FirstOrDefault(x => x.Id == 0);
            _userAccountRep.RemoveAll();

            if (userCurrent.IsNull())
                userCurrent = new UserModel();

            userCurrent.UpdateObject(user);

            if (userCurrent == null) return;
            userCurrent.Id = 0;
            _userAccountRep.Add(userCurrent);
        }

        private void Clear()
        {
            _userAccountRep.RemoveAll();
        }

        #region serivce

        public void RecoverPassword(Action<string> success, Action<string> error)
        {
            GetService.OnRecoveryPassword(success, error);
        }

        public void Logout(Action<string> success, Action<string> error)
        {
            GetService.OnLogout(message =>
            {
                if (!IsRememberMe())
                    Clear();
                success?.Invoke(message);
            }, error);
        }

        public void Login(Action<string> success, Action<string> error)
        {
            GetService.OnLogin(success, error);
        }

        public void ChangePassword(Action<string> success, Action<string> error)
        {
            GetService.OnChangePassword(success, error);
        }

        public void ChangeUserData(Action<string> success, Action<string> error)
        {
            GetService.OnChangeUserData(success, error);
        }

        #endregion
    }
}