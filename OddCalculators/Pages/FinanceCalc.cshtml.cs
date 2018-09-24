using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using OddCalculators.Models;

namespace OddCalculators.Pages
{
    public class FinanceCalcModel : PageModel
    {
        public ActionResult OnPostCalcCompound()
        {
            decimal compoundR = 0;
            decimal compoundN = 0;
            decimal compoundP = 0;
            decimal compoundT = 0;
            {
                MemoryStream stream = new MemoryStream();
                Request.Body.CopyTo(stream);
                stream.Position = 0;
                using (StreamReader reader = new StreamReader(stream))
                {
                    string requestBody = reader.ReadToEnd();
                    if (requestBody.Length > 0)
                    {
                        var obj = JsonConvert.DeserializeObject<CompoundData>(requestBody);
                        if (obj != null)
                        {
                            compoundR = obj.CompoundR;
                            compoundN = obj.CompoundN;
                            compoundT = obj.CompoundT;
                            compoundP = obj.CompoundP;
                        }
                    }
                }
            }

            var compoundRby100 = compoundR / 100;
            compoundR = compoundR / 100;
            var rDivN = compoundR / compoundN;
            var nByT = compoundN * compoundT;
            var brackets = (1 + rDivN);
            var beforePower = nByT * brackets;
            decimal beforePrincipal = (decimal)Math.Pow((double)brackets, (double)nByT);
            decimal compoundResult = Math.Round(compoundP * beforePrincipal, 2);
            return new JsonResult(compoundResult);
        }
    }

    public class CompoundData
    {
        [Required]
        public decimal CompoundN { get; set; }
        [Required]
        public decimal CompoundR { get; set; }
        [Required]
        public decimal CompoundT { get; set; }
        [Required]
        public decimal CompoundP { get; set; }
    }


    

}