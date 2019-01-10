using Connect2PayLibrary.Requests;
using System;
using System.Collections.Generic;
using System.Text;

namespace Connect2PayLibrary
{
    public class Connect2PayClient
    {
        private String url;
        private String originatorId;
        private String password;

        public Connect2PayClient(String Url, String OriginatorId, String Password)
        {
            this.url = Url;
            this.originatorId = OriginatorId;
            this.password = Password;
        }

        public Connect2PayClient(String OriginatorId, String Password)
        {
            this.url = "https://connect2.payxpert.com";
            this.originatorId = OriginatorId;
            this.password = Password;
        }

        public RequestCreatePayment NewRequestCreatePayment()
        {
            return new RequestCreatePayment(RequestType.CREATE_PAYMENT, originatorId, password, url, null);
        }

        public RequestPaymentStatus NewRequestPaymentStatus(String MerchantToken)
        {
            return new RequestPaymentStatus(RequestType.GET_PAYMENT_STATUS, originatorId, password, url, MerchantToken);
        }

        public RequestTransactionInfo NewRequestTransactionInfo(String TransactionID)
        {
            return new RequestTransactionInfo(RequestType.GET_TRANSACTION_INFORMATION, originatorId, password, url, TransactionID);
        }

        public RequestAccountInfo NewRequestAccountInfo()
        {
            return new RequestAccountInfo(RequestType.ACCOUNT_INFO, originatorId, password, url);
        }
    }
}
