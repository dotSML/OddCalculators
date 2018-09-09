using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using OddCalculators.Services;

namespace OddCalculators.Pages
{
    public class CreateModel : PageModel
    {
        private readonly IGlobalizationService _globalizationService;


        [BindProperty]
        public Customer Customer { get; set; }

        private readonly OddDbContext _context;


        public CreateModel(OddDbContext context, IGlobalizationService globalizationService)
        {
            _context = context;
            _globalizationService = globalizationService;
        }

        public void OnGet()
        {
            _globalizationService.PopulateCountriesDropdown();

        }

        

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