using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace OddCalculators.Pages
{
    public class CreateModel : PageModel
    {
        private readonly OddDbContext _context;

        public CreateModel(OddDbContext context)
        {
            _context = context;
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