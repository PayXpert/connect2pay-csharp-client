using System;
using System.Collections.Generic;
using System.Text;

namespace Connect2PayLibrary.Responses
{
    public class Transaction
    {
        public Int64 date { get; set; }
        public int amount { get; set; }

        public String paymentType { get; set; }
        public String provider { get; set; }
        public String paymentMethod { get; set; }
        public String paymentNetwork { get; set; }

        public PaymentMeanInfo paymentMeanInfo { get; set; }
        public Shopper shopper { get; set; }

        public String operation { get; set; }

        public String resultCode { get; set; }
        public String resultMessage { get; set; }

        public String status { get; set; }

        public String transactionID { get; set; }
        public String refTransactionID { get; set; }
        public String providerTransactionID { get; set; }
        public String subscriptionID { get; set; }
    }
}
