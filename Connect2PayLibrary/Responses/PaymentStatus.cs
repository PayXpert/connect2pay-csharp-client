using System;
using System.Collections.Generic;
using System.Text;

namespace Connect2PayLibrary.Responses
{
    public class PaymentStatusResponse : Connect2PayBaseResponseObject
    {
        public String merchantToken { get; set; }
        public String paymentType { get; set; }

        public PaymentMeanInfo paymentMeanInfo { get; set; }

        public String operation { get; set; }

        public String errorCode { get; set; }
        public String errorMessage { get; set; }

        public String status { get; set; }

        public Int64? transactionID { get; set; }
        public Int64? subscriptionID { get; set; }

        public String ctrlCustomData { get; set; }

        public String orderID { get; set; }
        public String currency { get; set; }
        public Int32? amount { get; set; }

        // Shopper details
        public String shopperName { get; set; }
        public String shopperAddress { get; set; }
        public String shopperZipcode { get; set; }
        public String shopperCity { get; set; }
        public String shopperState { get; set; }
        public String shopperCountryCode { get; set; }
        public String shopperEmail { get; set; }
        public String shopperPhone { get; set; }
        public String shopperBirthDate { get; set; }
        public String shopperIDNumber { get; set; }
        public String shopperIPAddress { get; set; }

        public String cardHolderName { get; set; }

        public String statementDescriptor { get; set; }

        public List<Transaction> transactions { get; set; }

        public override bool IsSuccessfull()
        {
            return (errorCode != null && errorCode == "000");
        }
    }
}
