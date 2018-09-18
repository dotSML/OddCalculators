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
        public JsonResult OnGetList()
        {
            List<string> lstString = new List<string>
        {
            "Val 1",
            "Val 2",
            "Val 3"
        };
            return new JsonResult(lstString);
        }
    }
}