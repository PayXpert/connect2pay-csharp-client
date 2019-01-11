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

        #region Refund, rebill, cancel

        public RequestRefundRebillCancel NewRequestRefund(String TransactionID)
        {
            return new RequestRefundRebillCancel(RequestType.REFUND_TRANSACTION, originatorId, password, url, TransactionID);
        }

        public RequestRefundRebillCancel NewRequestRebill(String TransactionID)
        {
            return new RequestRefundRebillCancel(RequestType.REBILL_TRANSACTION, originatorId, password, url, TransactionID);
        }

        public RequestRefundRebillCancel NewRequestTransactionCancel(String TransactionID)
        {
            return new RequestRefundRebillCancel(RequestType.CANCEL_TRANSACTION, originatorId, password, url, TransactionID);
        }

        #endregion

        public RequestSubscriptionCancel NewRequestSubscriptionCancel(String SubscriptionID)
        {
            return new RequestSubscriptionCancel(RequestType.CANCEL_SUBSCRIPTION, originatorId, password, url, SubscriptionID);
        }

        public RequestWeChatDirect NewRequestWeChatDirect(String CustomerToken)
        {
            return new RequestWeChatDirect(RequestType.WECHAT_DIRECT, originatorId, password, url, CustomerToken);
        }

        public RequestAliPayDirect NewRequestAliPayDirect(String CustomerToken)
        {
            return new RequestAliPayDirect(RequestType.ALIPAY_DIRECT, originatorId, password, url, CustomerToken);
        }
    }
}
