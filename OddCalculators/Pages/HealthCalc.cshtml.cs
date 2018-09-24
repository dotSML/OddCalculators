using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace OddCalculators.Pages
{
    public class HealthCalcModel : PageModel
    {
        public ActionResult OnPostCarbCalc()
        {
            double carbAmountPost = 0;
            double carbsPer100Post = 0;
            {
                MemoryStream stream = new MemoryStream();
                Request.Body.CopyTo(stream);
                stream.Position = 0;
                using (StreamReader reader = new StreamReader(stream))
                {
                    string requestBody = reader.ReadToEnd();
                    if (requestBody.Length > 0)
                    {
                        var obj = JsonConvert.DeserializeObject<CarbData>(requestBody);
                        if (obj != null)
                        {
                            carbAmountPost = obj.CarbAmount;
                            carbsPer100Post = obj.CarbsPer100;
                        }
                    }
                }
            }

            var carbResult = (carbsPer100Post * carbAmountPost) / 100;
            return new JsonResult(carbResult);
        }
    }

    public class CarbData
    {
        public double CarbAmount { get; set; }
        public double CarbsPer100 { get; set; }
    }
}