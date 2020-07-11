using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Gift_Delivery_Core_Web.BusinessLayer
{
    //Sender information
    public class GiftSender
    {
        //Sender id 
        public int Id { get; set; }

        //Name of th sender
        public string SenderName { get; set; }

        //Mobile contact number
        public string MobileNumber { get; set; }

    }
}
