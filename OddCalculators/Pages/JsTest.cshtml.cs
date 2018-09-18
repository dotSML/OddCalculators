using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace OddCalculators.Pages
{
    public class JsTestModel : PageModel
    {
        public ActionResult OnGet()
        {
            return Page();
        }

    }
}

    
