using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace OddCalculators.Pages
{
    public class CrudModel : PageModel
    {
        private readonly OddDbContext _context;

        public CrudModel(OddDbContext context)
        {
            _context = context;
        }

        public IList<Customer> Customers { get; private set; }

        public async Task OnGetAsync()
        {
            Customers = await _context.Customers.AsNoTracking().ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var customer = await _context.Customers.FindAsync(id);

            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage();
        }
    }
}