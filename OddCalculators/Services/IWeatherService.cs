using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OddCalculators.Models;
using OddCalculators.Pages;

namespace OddCalculators.Services
{
    public interface IWeatherService
    {
        Task<OpenWeatherResponse> GetWeather();
        List<OpenWeatherResponse> ReadWeather();
    }

    public class WeatherService : IWeatherService
    {
        public OpenWeatherResponse Weather { get; set; }

        public async Task<OpenWeatherResponse> GetWeather()
        {
            var client = new WebClient();
            var weatherJson = client.DownloadString("http://api.openweathermap.org/data/2.5/weather?q=Tallinn&appid=8478be516a1315ab6d07fa84f4666b54&units=metric");
            var weather = JsonConvert.DeserializeObject<OpenWeatherResponse>(weatherJson);

            var nameTest = weather.Name;
            var tempTest = weather.Main.Temp;



            Weather = new OpenWeatherResponse()
            {
                Name = nameTest,
                Temperature = tempTest
            };

            return Weather;

        }

        public List<OpenWeatherResponse> ReadWeather()
        {
            GetWeather();

            List<OpenWeatherResponse> openWeatherList = new List<OpenWeatherResponse>
            {
                Weather

            };
            return openWeatherList;
        }
    }

}
