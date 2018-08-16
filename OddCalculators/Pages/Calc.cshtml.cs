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

        public async void OnPostCompoundAsync()
        {
            Compound.R = Compound.R / 100;
            var rDivN = Compound.R / Compound.N;
            var nByT = Compound.N * Compound.T;
            var brackets = (1 + rDivN);
            var beforePower = nByT * brackets;
            var beforePrincipal = Math.Pow(brackets, nByT);
            Compound.A = Math.Round(Compound.P * beforePrincipal,2);

        }
    }
}