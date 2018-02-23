using System;
using System.Collections.Generic;
using Core.Models.DAL;
using Core.Models.DAL.CategoryBooks;
using Core.Services.MockServices.Interfaces;
using Core.Services.Response;
using Int.Core.Network.Response;

namespace Core.Services.MockServices.RealServices
{
    public class BooksService : Service,IBooksService
    {
        public void GetCategoryes(Action<IList<ICategoryContent>> success, Action<string> error)
        {
            var response =
                RequestFactory.ExecuteRequest<MResponse<IList<ICategoryContent>>>(RestCalls.Instance
                                                                                  .GetCategoryBooks());

            response.OnResponse(() => { success?.Invoke(response.Data); },
                exception => error?.Invoke(exception.Message));
        }


    }
}
