﻿using Connect2PayLibrary.Requests;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Connect2PayLibrary.Responses;
using Microsoft.AspNetCore.WebUtilities;
using Newtonsoft.Json;

namespace Connect2PayLibrary
{
    public class Connect2PayClient
    {
        private String url;
        private String originatorId;
        private String password;

        #region Constructors

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

        #endregion

        #region Transactions

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

        public RequestExportTransactions NewExportTransactionsRequest(String StartDate, String EndDate)
        {
            return new RequestExportTransactions(RequestType.EXPORT_TRANSACTIONS, originatorId, password, url, StartDate, EndDate);
        }

        public RequestExportTransactions NewExportTransactionsRequest(DateTime StartDate, DateTime EndDate)
        {
            var timestampStart = (Int32)(StartDate.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            var timestampEnd = (Int32)(EndDate.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;

            return NewExportTransactionsRequest(timestampStart.ToString(), timestampEnd.ToString());
        }

        #endregion

        #region Refund, rebill, cancel

        public RequestRefund NewRequestRefund(String TransactionID)
        {
            return new RequestRefund(RequestType.REFUND_TRANSACTION, originatorId, password, url, TransactionID);
        }

        public RequestRebill NewRequestRebill(String TransactionID)
        {
            return new RequestRebill(RequestType.REBILL_TRANSACTION, originatorId, password, url, TransactionID);
        }

        public RequestCancel NewRequestTransactionCancel(String TransactionID)
        {
            return new RequestCancel(RequestType.CANCEL_TRANSACTION, originatorId, password, url, TransactionID);
        }
        
        public RequestCapture NewRequestCapture(String TransactionID)
        {
            return new RequestCapture(RequestType.CAPTURE_TRANSACTION, originatorId, password, url, TransactionID);
        }

        #endregion

        #region Subscriptions

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

        #endregion

        #region Encryption utils

        public static PaymentStatusResponse HandleRedirectStatus(String encryptedData, String merchantToken)
        {
            try
            {
                var encryptedBytes = EncryptionHelper.ConvertFromBase64String(encryptedData);
                var merchantTokenBytes = EncryptionHelper.ConvertFromBase64String(merchantToken);

                var decryptedResponseData =
                    EncryptionHelper.DecryptStringFromBytes_Aes(encryptedBytes, merchantTokenBytes, null);

                var responseObject =
                    JsonConvert.DeserializeObject<PaymentStatusResponse>(decryptedResponseData);
                return responseObject;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        #endregion
    }
}
