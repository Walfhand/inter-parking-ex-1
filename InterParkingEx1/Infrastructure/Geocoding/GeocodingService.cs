using Application.Common.Configs;
using Application.Common.Interfaces;
using Application.Common.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace Infrastructure.Geocoding
{
    public class GeocodingService : IGeocodingService
    {
        private readonly string _searchBaseUrl;
        private readonly string _drivingBaseUrl;
        private readonly string _apiKey;

        public GeocodingService(IOptions<GeocodingOptions> options)
        {
            _apiKey = options.Value.ApiKey;
            _searchBaseUrl = $"https://us1.locationiq.com/v1/search.php?key={_apiKey}&format=json&q=";
            _drivingBaseUrl = $"https://us1.locationiq.com/v1/directions/driving/";
        }

        public async Task<GeocodingResult> CalculateCoordinates(string address)
        {
            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync($"{_searchBaseUrl}{address}");
            if (!response.IsSuccessStatusCode)
            {
                return new GeocodingResult();
            }

            string json = await response.Content.ReadAsStringAsync();
            List<GeocodingResult> geocodingResults = JsonConvert.DeserializeObject<List<GeocodingResult>>(json);
            return geocodingResults.First();
        }

        public async Task<double> CalculateDistanceBeetween2Points(double latPoint1, double lonPoint1, double latPoint2, double lonPoint2)
        {
            string url = $"{_drivingBaseUrl}{lonPoint1.ToString().Replace(",",".")}," +
                $"{latPoint1.ToString().Replace(",", ".")};{lonPoint2.ToString().Replace(",", ".")}," +
                $"{latPoint2.ToString().Replace(",", ".")}?key={_apiKey}&steps=false&alternatives=false&overview=full";

            using HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return 0;
            }

            string json = await response.Content.ReadAsStringAsync();

            double? distance = DeserializeFragmentJson<List<GeocodingDistanceResult>>(json, "routes").FirstOrDefault()?.Distance;

            return distance.Value / 1000;
        }

        private TResult DeserializeFragmentJson<TResult>(string json, string targetFragment)
        {
            JObject datas = JObject.Parse(json);
            return datas[targetFragment].ToObject<TResult>();
        }
    }
}
