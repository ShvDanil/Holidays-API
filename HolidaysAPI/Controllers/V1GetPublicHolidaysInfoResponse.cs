namespace HolidaysAPI.Controllers
{
    public class V1GetPublicHolidaysInfoResponse
    {
        public string Date { get; set; }
        public string LocalName { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public bool Fixed { get; set; }
        public bool Global { get; set; }
        public string[] Continues { get; set; }
        public uint? LaunchYear { get; set; }
        public string[] Types { get; set; }
    }
}