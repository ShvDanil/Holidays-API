using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace HolidaysAPI.Controllers
{
    [ApiController]
    [Route("public-holidays-info")]
    public class PublicHolidaysController : ControllerBase
    {
        private readonly IPublicHolidaysInfoServiceClient _publicHolidaysInfoServiceClient;

        public PublicHolidaysController(IPublicHolidaysInfoServiceClient publicHolidaysInfoServiceClient)
        {
            _publicHolidaysInfoServiceClient = publicHolidaysInfoServiceClient;
        }

        [HttpPost("")]
        public async Task<V1GetPublicHolidaysInfoResponse[]> GetPublicHolidayInfo([FromBody] V1GetPublicHolidaysInfoRequest request)
        {
            var result = await _publicHolidaysInfoServiceClient.GetPublicHolidayInfo(request.CountryCode, request.Year);
            return result?.Select(c => new V1GetPublicHolidaysInfoResponse
            {
                Name = c.Name,
                Types = c.Types.Select(x => x.ToString()).ToArray()
            }).ToArray();
        }
    }
}