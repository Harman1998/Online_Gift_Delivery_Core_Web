using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Online_Gift_Delivery_Core_Web.BusinessLayer;
using Online_Gift_Delivery_Core_Web.Models;

namespace Online_Gift_Delivery_Core_Web.Pages.GiftPurchases
{
    public class IndexModel : PageModel
    {
        private readonly Online_Gift_Delivery_Core_Web.Models.Online_Gift_Delivery_DataContext _context;

        public IndexModel(Online_Gift_Delivery_Core_Web.Models.Online_Gift_Delivery_DataContext context)
        {
            _context = context;
        }

        public IList<GiftPurchase> GiftPurchase { get;set; }

        public async Task OnGetAsync()
        {
            GiftPurchase = await _context.GiftPurchase
                .Include(g => g.Gift)
                .Include(g => g.GiftSender)
                .Include(g => g.ShippingMethod).ToListAsync();
        }
    }
}
