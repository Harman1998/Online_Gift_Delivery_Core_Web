using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Gift_Delivery_Core_Web.BusinessLayer
{
    //Gift information
    public class Gift
    {
        //Gift internal id
        public int Id { get; set; }

        //Name of the gift
        public string ItemName { get; set; }

        //Price of the gift
        public decimal ItemPrice { get; set; }

        
    }
}
