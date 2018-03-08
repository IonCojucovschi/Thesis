using System;
using System.Collections.Generic;
using Core.Helpers.Manager;
using Core.Models.DAL;
using Core.Models.DAL.CategoryBooks;
using Core.Services.MockServices.Interfaces;
using Core.Services.Response;
using Int.Core.Network.Response;
using Newtonsoft.Json;

namespace Core.Services.MockServices.RealServices
{
    public class BooksService : Service,IBooksService
    {
        

        public void GetCategoryes(Action<IList<CategoryContent>> success, Action<string> error)
        {
            var response =
                RequestFactory.ExecuteRequest<MResponse<IList<CategoryContent>>>(RestCalls.Instance
                                                                                  .GetCategoryBooks());
            response.OnResponse(() => { success?.Invoke(response.Data); },
                exception => error?.Invoke(exception.Message));
        }


        public void GetBooksFromCategory(Action<IList<Booklist>> success, Action<string> error)
        {
            ICategoryContent somevalue = BooksManager.Instance._curentCategory;

            var response =
                RequestFactory.ExecuteRequest<MResponse<IList<Booklist>>>(RestCalls.Instance.GetBooksFromCategory(somevalue));
            
            response.OnResponse(() => { success?.Invoke(response.Data); },
                exception => error?.Invoke(exception.Message));
        }

    }
}
