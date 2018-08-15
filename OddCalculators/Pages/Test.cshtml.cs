using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OddCalculators.Models;
using OddCalculators.Services;

namespace OddCalculators.Pages
{
    public class TestModel : PageModel
    {
        private readonly IWeatherService _weatherService;

        public OpenWeatherResponse WeatherResponse { get; set; }

        public TestModel(IWeatherService weatherService)
        {
            _weatherService = weatherService;
        }


        public void OnGet()
        {

        }
    }
}