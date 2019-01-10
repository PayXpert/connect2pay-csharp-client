using Connect2PayLibrary.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Connect2PayLibrary.Requests
{
    public class RequestRefundRebillCancelObject : BaseRequestObject
    {
        public String apiVersion { get; set; }
        public Int32 amount { get; set; }

        public RequestRefundRebillCancelObject()
        {
            this.apiVersion = "002.51";
        }
    }

    public class RequestRefundRebillCancel : RequestBase
    {
        public RequestRefundRebillCancel(RequestType Type, String OriginatorId, String Password, String BaseURL, String TransactionId) : base(Type, OriginatorId, Password, BaseURL, TransactionId)
        {
            
        }

        public void SetAmount(int amount)
        {
            var requestObject = new RequestCreatePaymentObject();
            requestObject.amount = amount;
            this.requestObject = requestObject;
        }

        public async Task<ResponseRefundRebillCancel> Send()
        {
            return await SendRequestToServer<ResponseRefundRebillCancel>();
        }
    }


}
