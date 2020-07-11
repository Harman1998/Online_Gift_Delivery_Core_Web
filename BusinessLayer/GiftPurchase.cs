using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Gift_Delivery_Core_Web.BusinessLayer
{
    //Represensts a gift purchase
    public class GiftPurchase
    {
        //Purchase Id 
        public int Id { get; set; }

        //Sender id reference key
        public int GiftSenderId { get; set; }

        //Gift id reference key
        public int GiftId { get; set; }

        //Shipping method reference key
        public int ShippingMethodId { get; set; }


        //Sender link
        public GiftSender GiftSender { get; set; }

        //Gift link
        public Gift Gift { get; set; }

        //Revceiver name
        public string Reciever { get; set; }

        //Receiver address
        public string RecieverAddress { get; set; }


        //Shipping method reference
        public ShippingMethod ShippingMethod { get; set; }



    }
}
