using System.Collections.Generic;
using Int.Core.Network;

namespace Core.Services.Response
{
    public interface IResponseWithMeta : IResponseService
    {
        IList<string> Errors { get; set; }
    }
}