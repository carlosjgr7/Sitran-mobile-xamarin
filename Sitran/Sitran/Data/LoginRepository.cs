using System;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Refit;
using Sitran.Data.Network.Interface;
using Sitran.Data.Network.Responses;
using Sitran.Model;
using Sitran.Utils;

namespace Sitran.Data
{
	public class LoginRepository
	{
		public LoginRepository()
		{
		}

        public async Task<Token> DoLogin(User userData, int agregador)
        {
            var api = RestService.For<ILogin>(StaticValues.baseUrl);
            try
            {
                using (var jsonresult = await api.DoLogin(userData))
                {
                    if (jsonresult.IsSuccessStatusCode)
                        return JsonConvert
                            .DeserializeObject<Token>(await jsonresult
                            .Content
                            .ReadAsStringAsync());
                }
            } catch (Exception e) {
                return null;
            }
            

            return null;

        }
    }
}

