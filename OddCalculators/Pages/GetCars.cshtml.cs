using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OddCalculators.Services;

namespace OddCalculators.Pages
{
    public class GetCarsModel : PageModel
    {
        private readonly ICarService _carService;

        public GetCarsModel(ICarService carService)
        {
            _carService = carService;
        }

        public JsonResult OnGet()
        {
            return new JsonResult(_carService.ReadAll());
        }
    }
}