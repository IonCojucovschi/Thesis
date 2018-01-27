using Core.Models.DAL;
using Core.Services.MockServices.Interfaces;
using Core.Services.Response;
using Int.Core.Network.Response;
using System;
using System.Collections.Generic;

namespace Core.Services.MockServices.RealServices
{
    public class ComunicationService : Service, IComunicationService
    {

        public void GetCommunication(Action<IList<BeComunicationModel>> success, Action<string> error)
        {
            var response =
                RequestFactory.ExecuteRequest<MResponse<IList<BeComunicationModel>>>(RestCalls.Instance.GetCommunication());

            response.OnResponse(() => { success?.Invoke(response.Data); },
                exception => error?.Invoke(exception.Message));
        }
    }
}
