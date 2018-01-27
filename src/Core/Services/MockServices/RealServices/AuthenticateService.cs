//
//  AuthenticateServiceMock.cs
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
using System.Diagnostics;
using System.Linq;
using Com.OneSignal;
using Core.Helpers.Manager;
using Core.Models.DAL;
using Core.Models.DTO;
using Core.Services.Response;
using Int.Core.Application.Login.Contract;
using Int.Core.Extensions;
using Int.Core.Network.Response;

namespace Core.Services.RealServices
{
    //todo dumati nado 
    public class AuthenticateService : Service, ILogin
    {
        public void OnLogin(Action<string> success, Action<string> error)
        {
            if (GetValue(error, out var myUser)) return;

            var response = RequestFactory.ExecuteRequest<MResponse<string>>(RestCalls.Instance.Login(
                new LoginModelServer
                {
                    Username = myUser.Username,
                    Password = myUser.Password,
                    Language = "it"
                }));

            response.OnResponse(() =>
            {
                var token = response.Data;

                UserManager.Instance.UpdateUser(new UserModel
                {
                    Username = myUser.Username,
                    Password = myUser.Password,
                    Remember = myUser.Remember,

                    Token = token,
                    Profile = response.Profile
                });

                SetToken();
                success?.Invoke("Success!");
            }, exception => error?.Invoke(exception.Message));
        }

        public void OnLogout(Action<string> success, Action<string> error)
        {
            if (GetValue(error, out var myUser)) return;

            var response = RequestFactory.ExecuteRequest<MResponse<List<string>>>(RestCalls.Instance.Logout(
                new LogouDeviceModel
                {
                    DeviceToken = myUser.TokenDevice.IsNullOrWhiteSpace() ? "0000" : myUser.TokenDevice
                }));

            response.OnResponse(() => { success?.Invoke(response.Data.FirstOrDefault()); }, exception => error?.Invoke(exception.Message));
        }

        public void OnRecoveryPassword(Action<string> success, Action<string> error)
        {
            if (GetValue(error, out var myUser)) return;

            var response = RequestFactory.ExecuteRequest<MResponse<List<string>>>(RestCalls.Instance.RestorePassword(
                new RestoreEmailModel
                {
                    Email = myUser.Username
                }));

            response.OnResponse(() =>
            {
                var data = response.Data.FirstOrDefault();
                success?.Invoke(data);
            },
                                exception => error?.Invoke(exception.Message));
        }

        public void OnChangeUserData(Action<string> success, Action<string> error)
        {
            if (UserManager.Instance.ChangeUserModel == null)
            {
                error?.Invoke($"{nameof(UserManager.Instance.ChangeUserModel)} is null");
                return;
            }
            var response =
                RequestFactory.ExecuteRequest<MResponse<List<string>>>(
                    RestCalls.Instance.ChangeUserData(UserManager.Instance.ChangeUserModel));

            response.OnResponse(() =>
            {
                if (UserManager.Instance.CurrentUser() is UserModel currentUser)
                {
                    currentUser.Profile = new ProfileModel
                    {
                        Name = UserManager.Instance.ChangeUserModel.Name,
                        Surname = UserManager.Instance.ChangeUserModel.Lastname,
                        Address = UserManager.Instance.ChangeUserModel.Address,
                        Email = UserManager.Instance.ChangeUserModel.Email,
                        Mobile = UserManager.Instance.ChangeUserModel.Mobile,
                        Phone = UserManager.Instance.ChangeUserModel.Phone,
                        Language = currentUser.Language,
                        Username = currentUser.Username,
                        VatNumber = currentUser.VatNumber
                    };

                    UserManager.Instance.UpdateUser(currentUser);
                }

                success?.Invoke(response.Data.FirstOrDefault());

            }, exception => error?.Invoke(exception.Message));
        }

        public void OnChangePassword(Action<string> success, Action<string> error)
        {
            if (GetValue(error, out var myUser)) return;

            var response = RequestFactory.ExecuteRequest<MResponse<List<string>>>(RestCalls.Instance.ChangePassword(
                new ChangePasswordModel
                {
                    NewPassword = myUser.NewPassword,
                    Password = myUser.Password
                }));

            response.OnResponse(() => { success?.Invoke(response.Data.FirstOrDefault()); }, exception => error?.Invoke(exception.Message));
        }

        public void GetProfile()
        {
            var response = RequestFactory.ExecuteRequest<MResponse<List<UserModel>>>(RestCalls.Instance.GetProfile());

            response.OnResponse(() => { UserManager.Instance.UpdateUser(response.Data.FirstOrDefault()); });
        }

        private static void SetToken()
        {
            OneSignal.Current.IdsAvailable((playerId, pushToken) =>
            {
                SetTokenDevice(obj => { Debug.WriteLine("Code => " + obj.Code); }, playerId);
            });
        }

        private static void SetTokenDevice(Action<IResponseWithMeta> callback, string tokenDevice)
        {
            var response = RequestFactory.ExecuteRequest<MResponse<List<UserModel>>>(
                RestCalls.Instance.InsertDeviceToken(new LogouDeviceModel
                {
                    DeviceToken = tokenDevice
                }));

            response.OnResponse(() => { UserManager.Instance.UpdateUser(new UserModel { TokenDevice = tokenDevice }); });

            callback?.Invoke(response);
        }

        private static bool GetValue(Action<string> error, out UserModel myUser)
        {
            myUser = UserManager.Instance.CurrentUser() as UserModel;

            if (!myUser.IsNull()) return false;
            error?.Invoke("Null User repository");
            return true;
        }
    }
}