using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace OddCalculators.Pages
{
    public class CreateModel : PageModel
    {
        private readonly OddDbContext _context;

        public CreateModel(OddDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Dictionary<string, string> CountryList()
            {
                Dictionary<string, string> cultureList = new Dictionary<string, string>();

                CultureInfo[] getCultureInfo = CultureInfo.GetCultures(CultureTypes.SpecificCultures);

                foreach (CultureInfo getCulture in getCultureInfo)
                {
                    RegionInfo getRegionInfo = new RegionInfo(getCulture.LCID);

                    if (!(cultureList.ContainsKey(getRegionInfo.Name)))
                    {
                        cultureList.Add(getRegionInfo.Name, getRegionInfo.EnglishName);
                    }
                }
                return cultureList;
            }

            

        }

        [BindProperty]
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Customers.Add(Customer);
            await _context.SaveChangesAsync();
            return RedirectToPage("/Crud");
        }
    }
}