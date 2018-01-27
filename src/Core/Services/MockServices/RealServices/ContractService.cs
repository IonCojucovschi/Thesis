using System;
using System.Collections.Generic;
using Core.Models.DAL;
using Core.Services.MockServices.Interfaces;
using Core.Services.Response;
using Int.Core.Network.Response;

namespace Core.Services.MockServices.RealServices
{
    public class ContractService : Service, IContractService
    {
        public void GetContracts(Action<IList<Datum>> success, Action<string> error)
        {
            var response =
                RequestFactory.ExecuteRequest<MResponse<IList<Datum>>>(RestCalls.Instance
                    .GetContractsInProgress());

            response.OnResponse(() => { success?.Invoke(response.Data); },
                exception => error?.Invoke(exception.Message));
        }
    }
}