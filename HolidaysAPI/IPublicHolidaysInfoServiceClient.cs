using System.Threading.Tasks;

namespace HolidaysAPI
{
    public interface IPublicHolidaysInfoServiceClient
    {
        Task<PublicHolidayInfoResponse[]> GetPublicHolidayInfo(string countryCode, int year);
    }
}