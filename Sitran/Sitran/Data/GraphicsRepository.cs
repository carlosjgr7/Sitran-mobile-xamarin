using System;
using Newtonsoft.Json;
using Refit;
using Sitran.Data.Network.Interface;
using Sitran.Data.Network.Responses;
using Sitran.Model;
using Sitran.Utils;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace Sitran.Data
{
    public class GraphicsRepository
    {
        public GraphicsRepository()
        {
        }

        public async Task<ResponseGraphics> GetInfoGraphics(InitDate date)
        {
            var api = RestService.For<IGetGraphics>(StaticValues.baseUrl);

            using (var jsonresult = await api.GetMetrics(Preferences.Get(Prefer.Token, ""), date))
            {
                if (jsonresult.IsSuccessStatusCode)
                {
                    return JsonConvert
                        .DeserializeObject<ResponseGraphics>(await jsonresult
                        .Content
                        .ReadAsStringAsync());
                }
            }

            return null;

        }
    }
}

