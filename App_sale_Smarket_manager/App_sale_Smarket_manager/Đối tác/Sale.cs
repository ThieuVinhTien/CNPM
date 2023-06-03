using System;

namespace App_sale_manager
{
    public class Sale
    {
        public string saleName = "";
        public string saleMethod = "";
        public string saleCondition = "";
        public string condition = "";
        public DateTime startDate;
        public DateTime endDate;
        public string gift = "";
        public string gift_note = "";
        public string priceMethod = "";
        public decimal priceReduced = 0;
        public decimal conditionPrice = 0;
        public decimal conditionQuantity = 0;
        public bool is_autoDelete = false;
        public bool is_conditioned = false;
    }
}