namespace HolidaysAPI.Controllers
{
    public class V1GetPublicHolidaysInfoRequest
    {
        public string CountryCode { get; set; }
        public int Year { get; set; }
    }
}