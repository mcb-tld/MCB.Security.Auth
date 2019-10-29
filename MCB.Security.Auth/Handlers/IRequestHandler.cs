using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MCB.Security.Auth.Handlers
{
    public interface IRequestHandler<in TRequest> where TRequest: IRequest
    {
        Task<Response> HandleAsync(TRequest request);
    }
}