using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Online_Gift_Delivery_Core_Web.BusinessLayer;

namespace Online_Gift_Delivery_Core_Web.Models
{
    //Data context class connects the busines layer to the database schema
    public class Online_Gift_Delivery_DataContext : DbContext
    {
        public Online_Gift_Delivery_DataContext (DbContextOptions<Online_Gift_Delivery_DataContext> options)
            : base(options)
        {
        }

        public DbSet<Online_Gift_Delivery_Core_Web.BusinessLayer.Gift> Gift { get; set; }

        public DbSet<Online_Gift_Delivery_Core_Web.BusinessLayer.GiftPurchase> GiftPurchase { get; set; }

        public DbSet<Online_Gift_Delivery_Core_Web.BusinessLayer.GiftSender> GiftSender { get; set; }

        public DbSet<Online_Gift_Delivery_Core_Web.BusinessLayer.ShippingMethod> ShippingMethod { get; set; }
    }
}
