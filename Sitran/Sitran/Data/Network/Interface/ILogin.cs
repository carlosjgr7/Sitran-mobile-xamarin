using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sitran.Model;
using Refit;
using Sitran.Data.Network.Responses;
using System.Net.Http;
using System.Threading;

namespace Sitran.Data.Network.Interface
{
    public interface ILogin
    {
        [Post("/api/auth/sitran/login")]
        Task<HttpResponseMessage> DoLogin([Body] User user);
    }
}

