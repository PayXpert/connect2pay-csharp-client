using System;
using System.Collections.Generic;
using System.Text;

namespace Connect2PayLibrary
{
    class URLRecord
    {
        public String Url { get; set; }
        public String Method { get; set; }

        public URLRecord(RequestType action, String objectId)
        {
            if (action == RequestType.CREATE_PAYMENT)
            {
                Url = "transaction/prepare";
                Method = "POST";
            } else if (action == RequestType.GET_PAYMENT_STATUS)
            {
                Url = "transaction/" + objectId + "/status";
                Method = "GET";
            }
            else if (action == RequestType.GET_TRANSACTION_INFORMATION)
            {
                Url = "transaction/" + objectId + "/info";
                Method = "GET";
            }
            else if (action == RequestType.REFUND_TRANSACTION)
            {
                Url = "transaction/" + objectId + "/refund";
                Method = "POST";
            }
            else if (action == RequestType.REBILL_TRANSACTION)
            {
                Url = "transaction/" + objectId + "/rebill";
                Method = "POST";
            }
            else if (action == RequestType.CANCEL_TRANSACTION)
            {
                Url = "transaction/" + objectId + "/cancel";
                Method = "POST";
            }
            else if (action == RequestType.CANCEL_SUBSCRIPTION)
            {
                Url = "subscription/" + objectId + "/cancel";
                Method = "POST";
            }
            else if (action == RequestType.ACCOUNT_INFO)
            {
                Url = "account";
                Method = "GET";
            }
            else if (action == RequestType.WECHAT_DIRECT)
            {
                Url = "payment/" + objectId + "/process/wechat/direct";
                Method = "POST";
            }
            else if (action == RequestType.ALIPAY_DIRECT)
            {
                Url = "payment/" + objectId + "/process/alipay/direct";
                Method = "POST";
            }
        }

        public void SetInURL(String name, String value)
        {
            String paramToReplace = ":" + name;
            this.Url = this.Url.Replace(paramToReplace, value);
        }
    }
}
