using System;
using Sitran.Data;
using Sitran.Data.Network.Responses;
using Sitran.Model;
using System.Threading.Tasks;

namespace Sitran.Domain
{
	public class GetGraphicsByDate
	{
		public GetGraphicsByDate()
		{
		}
        public async Task<ResponseGraphics> GetInfoGraphics(InitDate date)
        {
            var result = await new GraphicsRepository().GetInfoGraphics(date);
            return result;
        }
    }
}

