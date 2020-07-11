using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Gift_Delivery_Core_Web.BusinessLayer
{
    //Represents a shipping method
    public class ShippingMethod
    {
        //Method id
        public int Id { get; set; }

        //Method name
        public string Name { get; set; }

        //Charge for method
        public decimal Charge { get; set; }

    }
}
