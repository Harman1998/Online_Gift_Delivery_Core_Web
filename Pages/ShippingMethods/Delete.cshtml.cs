using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Online_Gift_Delivery_Core_Web.BusinessLayer;
using Online_Gift_Delivery_Core_Web.Models;

namespace Online_Gift_Delivery_Core_Web.Pages.ShippingMethods
{
    public class DeleteModel : PageModel
    {
        private readonly Online_Gift_Delivery_Core_Web.Models.Online_Gift_Delivery_DataContext _context;

        public DeleteModel(Online_Gift_Delivery_Core_Web.Models.Online_Gift_Delivery_DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public ShippingMethod ShippingMethod { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ShippingMethod = await _context.ShippingMethod.FirstOrDefaultAsync(m => m.Id == id);

            if (ShippingMethod == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ShippingMethod = await _context.ShippingMethod.FindAsync(id);

            if (ShippingMethod != null)
            {
                _context.ShippingMethod.Remove(ShippingMethod);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
