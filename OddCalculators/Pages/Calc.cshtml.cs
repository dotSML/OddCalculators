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

        public async void OnPostAsync()
        {
             Compound.Result = Compound.a + Compound.b;
        }
    }
}