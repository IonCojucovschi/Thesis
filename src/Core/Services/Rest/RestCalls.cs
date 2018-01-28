//
// RestCalls.cs
//
// Author:
//       Songurov Fiodor <songurov@gmail.com>
//
// Copyright (c) 2016 Songurov Fiodor
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

using System;
using System.Net;
using Core.Helpers.Manager;
using Core.Models.DAL;
using Core.Models.DTO;
using Int.Core.Network;
using Int.Core.Network.Contract;
using Int.Core.Wrappers.Callback;
using Newtonsoft.Json;
using RestSharp;

namespace Core.Services
{
    internal sealed class RestCalls : ApiBase<RestCalls>
    {
        public IRestCallbackClient Login(LoginModelServer model)
        {
            string postlogin = RestConstants.PostLogin + model.Username + "/password/" + model.Password;
            return Request(postlogin, Method.POST,
                JsonConvert.SerializeObject(model),
                RestConstants.MediaTypeJson);
        }

        public IRestCallbackClient Logout(LogouDeviceModel model)
        {
            return Request(RestConstants.PostLogout, Method.POST,
                JsonConvert.SerializeObject(model),
                RestConstants.MediaTypeJson, requestTo: RequestTo.Key);
        }

        public IRestCallbackClient RestorePassword(RestoreEmailModel model)
        {
            return Request(RestConstants.PostRestorePassword, Method.POST,
                JsonConvert.SerializeObject(model),
                RestConstants.MediaTypeJson);
        }

        public IRestCallbackClient ChangePassword(ChangePasswordModel model)
        {
            return Request(RestConstants.PostChangePassword, Method.POST,
                JsonConvert.SerializeObject(model),
                RestConstants.MediaTypeJson, requestTo: RequestTo.Key);
        }

        /// RestConstants must be for change user data
        public IRestCallbackClient ChangeUserData(ChangeUserDataModel model)
        {
            var sendObj = JsonConvert.SerializeObject(model);

            return Request(RestConstants.PostChangeInfoClient, Method.POST, sendObj,
                RestConstants.MediaTypeJson, requestTo: RequestTo.Key);
        }

        public IRestCallbackClient InsertDeviceToken(LogouDeviceModel model)
        {
            return Request(RestConstants.PostSetTokenDevice, Method.POST,
                JsonConvert.SerializeObject(model),
                RestConstants.MediaTypeJson, requestTo: RequestTo.Key);
        }

        public IRestCallbackClient GetProfile()
        {
            return Request(RestConstants.GetProfile, Method.GET, RestConstants.MediaTypeJson);
        }

        public IRestCallbackClient GetContractsInProgress()
        {
            return Request(RestConstants.GetContractsInProgress, Method.GET,
                RestConstants.MediaTypeJson, requestTo: RequestTo.Key);
        }

        public IRestCallbackClient GetDocuments()
        {
            return Request(RestConstants.GetDocuments, Method.GET, RestConstants.MediaTypeJson,
                requestTo: RequestTo.Key);
        }

        public IRestCallbackClient GetCommunication()
        {
            return Request(RestConstants.GetCommunication, Method.GET, RestConstants.MediaTypeJson,
                requestTo: RequestTo.Key);
        }

        private static IRestCallbackClient Request(string url, Method method = Method.GET,
            string content = "", string typeMedia = "",
            ParameterType typePar = ParameterType.RequestBody,
            RequestTo requestTo = RequestTo.NoKey,
            string additionalFilePath = null)

        {
            var client = new RestClient(Uri.EscapeUriString(RestConstants.BaseUrl + url));

            if (requestTo == RequestTo.Key)
                client.AddDefaultHeader("X-API-KEY", (UserManager.Instance.CurrentUser() as UserModel)?.Token);

            var request = new RestRequest(method);

            request.AddHeader("cache-control", "no-cache");

            if (!string.IsNullOrEmpty(typeMedia))
                request.AddHeader("Content-Type", typeMedia);

            if (requestTo == RequestTo.Key)
                request.AddHeader("X-API-KEY", (UserManager.Instance.CurrentUser() as UserModel)?.Token);

            if (!string.IsNullOrEmpty(content))
                if (typeMedia != RestConstants.MediaTypeFormData)
                    request.AddParameter(typeMedia, content, typePar);

            if (!string.IsNullOrWhiteSpace(additionalFilePath))
            {
                const string fileName = "file";
                request.AddFile(fileName, additionalFilePath);
            }

            IRestCallbackClient refetchedRequestCallback = null;
            var response = client.Execute(request);

            if (url != RestConstants.PostLogin && response.StatusCode == HttpStatusCode.Forbidden)
                UserManager.Instance.Login(
                    obj =>
                    {
                        refetchedRequestCallback = Request(url, method, content, typeMedia, typePar, requestTo,
                            additionalFilePath);
                    },
                    message => { message.ToString(); });

            return refetchedRequestCallback ?? GetCallBack(response);
        }

        private static IRestCallbackClient GetCallBack(IRestResponse concretClient)
        {
            return new HttpClientWrapper(concretClient.Content, concretClient.ErrorMessage,
                (int)concretClient.StatusCode);
        }
    }
}