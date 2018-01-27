//
// MResponse.cs
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

using System;
using System.Collections.Generic;
using System.Linq;
using Core.Models.DAL;
using Int.Core.Application.Exception;
using Int.Core.Extensions;
using Int.Core.Network.Response;
using Newtonsoft.Json;

namespace Core.Services.Response
{
    public sealed class MResponse<TResponse> : BaseMResponse<TResponse>, IResponseWithMeta
    {
        [JsonProperty("result")]
        public bool Result { get; set; }

        [JsonProperty("status")]
        public bool Status { get; set; }

        [JsonProperty("profile")]
        public ProfileModel Profile { get; set; }

        private string Error { get; set; }

        public IList<string> Errors { get; set; }

        public override void OnResponse(Action success, Action<ExceptionApp> responseString = null)
        {
            Errors?.ToList().ForEach(x => Message += Environment.NewLine + x);

            //super api rest
            if (!Result && !Status)
            {
                Message = Data as string;
                if (Message.IsNullOrWhiteSpace())
                    (Data as List<string>)?.ToList().ForEach(x =>
                                                              Message += Environment.NewLine + x);
            }

            if (!Error.IsNullOrWhiteSpace())
                Message = Error;

            base.OnResponse(success, responseString);
        }
    }
}