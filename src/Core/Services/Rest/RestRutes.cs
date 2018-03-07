//
// RestRutes.cs
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

namespace Core.Services
{
    public static partial class RestConstants
    {
        public const string PostLogin = "api/login/login/";///"api/client/auth/login";
        public const string PostSetTokenDevice = "api/client/auth/set_token";
        public const string PostLogout = "api/client/auth/logout";
        public const string PostRestorePassword = "api/client/auth/reset_password";
        public const string PostChangePassword = "api/client/auth/change_password";
        public const string PostChangeInfoClient = "api/client/auth/save_info_client";

        ///
        public const string GetBooksCategory= "api/allcategory";
        public const string GetBooksForCategory = "api/books/category";




        ///

        public const string GetProfile = "api/client/auth/info_client";
        public const string GetContractsInProgress = "api/client/contracts";
        public const string GetDocuments = "api/client/contracts/document";
        public const string GetCommunication = "api/client/contracts/communication";
    }
}