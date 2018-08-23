using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OddCalculators.Models;

namespace OddCalculators.Pages
{
    public class CalcModel : PageModel
    {
        [BindProperty]
        public CompoundInterest Compound { get; set; }

        [BindProperty]
        public Carbs Carbs { get; set; }

        public async void OnPostCompoundAsync()
        {
            Compound.A = await Task.Run(() => CalculateCompound());
        }

        public async void OnPostCarbs()
        {
            Carbs.CarbsResult = await Task.Run(() => CalculateCarbs());
        }

        public double CalculateCompound()
        {
            Compound.R = Compound.R / 100;
            var rDivN = Compound.R / Compound.N;
            var nByT = Compound.N * Compound.T;
            var brackets = (1 + rDivN);
            var beforePower = nByT * brackets;
            var beforePrincipal = Math.Pow(brackets, nByT);
            return Math.Round(Compound.P * beforePrincipal, 2);
        }

        public double CalculateCarbs()
        {
           return (Carbs.Amount * Carbs.CarbsPer100) / 100;
        }
    }
}