using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace HolidaysAPI
{
    public class PublicHolidaysInfoServiceClient : IPublicHolidaysInfoServiceClient
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerSettings _jsonSerializerSettings = new()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver()
        };

        public PublicHolidaysInfoServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<PublicHolidayInfoResponse[]> GetPublicHolidayInfo(string countryCode, int year)
        {
            var url = $"v3/PublicHolidays/{year}/{countryCode}";
            var publicHolidayInfoResult = await GetResponse<PublicHolidayInfoResponse[]>(url, HttpMethod.Get);

            return publicHolidayInfoResult.IsSuccess ? publicHolidayInfoResult.Value : null;
        }

        private async Task<(bool IsSuccess, string FaultMessage, T Value)> GetResponse<T>(string url, HttpMethod method, string content = null)
            where T : class
        {
            var httpRequest = new HttpRequestMessage
            {
                Method = method,
                RequestUri = new Uri($"{_httpClient.BaseAddress}{url}"),
                Content = new StringContent(content ?? string.Empty, Encoding.UTF8, "application/json")
            };

            var response = await _httpClient.SendAsync(httpRequest);
            var json = await response.Content.ReadAsStringAsync();
            if (response.IsSuccessStatusCode)
            {
                return (true, null, JsonConvert.DeserializeObject<T>(json, _jsonSerializerSettings));
            }

            return (false, json, null);
        }
    }
}