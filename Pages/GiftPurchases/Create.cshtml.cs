using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Online_Gift_Delivery_Core_Web.BusinessLayer;
using Online_Gift_Delivery_Core_Web.Models;

namespace Online_Gift_Delivery_Core_Web.Pages.GiftPurchases
{
    public class CreateModel : PageModel
    {
        private readonly Online_Gift_Delivery_Core_Web.Models.Online_Gift_Delivery_DataContext _context;

        public CreateModel(Online_Gift_Delivery_Core_Web.Models.Online_Gift_Delivery_DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int? id )
        {
        ViewData["GiftId"] = new SelectList(_context.Gift, "Id", "ItemName", id);
        ViewData["GiftSenderId"] = new SelectList(_context.Set<GiftSender>(), "Id", "SenderName");
        ViewData["ShippingMethodId"] = new SelectList(_context.Set<ShippingMethod>(), "Id", "Name");
            return Page();
        }

        [BindProperty]
        public GiftPurchase GiftPurchase { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.GiftPurchase.Add(GiftPurchase);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
