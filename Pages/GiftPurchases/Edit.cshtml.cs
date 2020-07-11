using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Online_Gift_Delivery_Core_Web.BusinessLayer;
using Online_Gift_Delivery_Core_Web.Models;

namespace Online_Gift_Delivery_Core_Web.Pages.GiftPurchases
{
    public class EditModel : PageModel
    {
        private readonly Online_Gift_Delivery_Core_Web.Models.Online_Gift_Delivery_DataContext _context;

        public EditModel(Online_Gift_Delivery_Core_Web.Models.Online_Gift_Delivery_DataContext context)
        {
            _context = context;
        }

        [BindProperty]
        public GiftPurchase GiftPurchase { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GiftPurchase = await _context.GiftPurchase
                .Include(g => g.Gift)
                .Include(g => g.GiftSender)
                .Include(g => g.ShippingMethod).FirstOrDefaultAsync(m => m.Id == id);

            if (GiftPurchase == null)
            {
                return NotFound();
            }
           ViewData["GiftId"] = new SelectList(_context.Gift, "Id", "ItemName");
           ViewData["GiftSenderId"] = new SelectList(_context.Set<GiftSender>(), "Id", "SenderName");
           ViewData["ShippingMethodId"] = new SelectList(_context.Set<ShippingMethod>(), "Id", "Name");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(GiftPurchase).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GiftPurchaseExists(GiftPurchase.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool GiftPurchaseExists(int id)
        {
            return _context.GiftPurchase.Any(e => e.Id == id);
        }
    }
}
