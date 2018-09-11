using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace OddCalculators.Pages
{
    public class EditModel : PageModel
    {
        private readonly OddDbContext _context;

        public EditModel(OddDbContext context)
        {
            _context = context;
        }

        public List<string> Countries { get; set; }

        [BindProperty]
        public Customer Customer { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            Customer = await _context.Customers.FindAsync(id);
            if (Customer == null)
            {
                return RedirectToPage("/Crud");
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                
                throw new Exception($"Customer {Customer.Id} not found", e);
            }

            return RedirectToPage("/Crud");
        }
    }
}