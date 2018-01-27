using System;
using System.Collections.Generic;
using Core.Models.DAL;

namespace Core.Services.MockServices.Interfaces
{
    public interface IContractService
    {
        void GetContracts(Action<IList<Datum>> success, Action<string> error);
    }
}