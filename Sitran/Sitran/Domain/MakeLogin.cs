using System;
using System.Threading.Tasks;
using Sitran.Data;
using Sitran.Data.Network.Responses;
using Sitran.Model;

namespace Sitran.Domain
{
	public class MakeLogin
	{
		public MakeLogin()
		{
		}

		public async Task<Token> DoLogin(String user, String pass, int agregador)
		{
			var userData = new User() { user = user, password = pass };
			var result = await new LoginRepository().DoLogin(userData, agregador);
			return result ;
        }
	}
}

