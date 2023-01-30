using System;
using Refit;
using Sitran.Model;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sitran.Data.Network.Interface
{
	public interface IGetGraphics
	{
        [Post("/api/auth/sitran/metricas")]
        Task<HttpResponseMessage> GetMetrics([Header("token")] string token,InitDate date);
    }
}

