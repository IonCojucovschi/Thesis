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
using Newtonsoft.Json;
using Plugin.Connectivity;

namespace Core.Services.RealServices
{
    //todo dumati nado 
    public class AuthenticateService : Service, ILogin
    {
        public void OnLogin(Action<string> success, Action<string> error)
        {
            if (GetValue(error, out var myUser)) return;
            var response = RequestFactory.ExecuteRequest<MResponse<UserModel>>(RestCalls.Instance.Login(
                new LoginModelServer
                {
                    Username = myUser.Username,
                    Password = myUser.Password,
                    Language = "it"
                }));
            response.OnResponse(() =>
            {
                var tmp = response.Data;
                tmp.Remember = UserManager.Instance.IsRememberMe();
               UserManager.Instance.UpdateUser(tmp);
                ///SetToken();
                success?.Invoke("Success!");
            }, exception => {
                if (CrossConnectivity.Current.IsConnected)
                    error?.Invoke("Credentiale invalide!");
                else
                    error?.Invoke(exception.Message);
            } );
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
                        Email = UserManager.Instance.ChangeUserModel.Email,
                        Mobile = UserManager.Instance.ChangeUserModel.Mobile,
                        Username = currentUser.Username,
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