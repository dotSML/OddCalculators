using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OddCalculators.Pages
{
    public class JsTestModel : PageModel
    {
        public JsonResult OnGetAjax()
        {
            return new JsonResult("HELLO!");
        }
    }
}