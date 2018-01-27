using System;
using System.Collections.Generic;
using Core.Models.DAL.Contracts.Documents;
using Core.Services.MockServices.Interfaces;
using Core.Services.Response;
using Int.Core.Network.Response;

namespace Core.Services.MockServices.RealServices
{
    public class DocumentService : Service, IDocumentService
    {
        public void GetDocuments(Action<IList<BeItemDocument>> success, Action<string> error)
        {
            var response =
                RequestFactory.ExecuteRequest<MResponse<IList<BeItemDocument>>>(RestCalls.Instance.GetDocuments());

            response.OnResponse(() => { success?.Invoke(response.Data); },
                exception => error?.Invoke(exception.Message));
        }
    }
}