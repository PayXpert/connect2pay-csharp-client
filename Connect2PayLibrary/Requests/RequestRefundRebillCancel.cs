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
    
    public class RequestTransactionOperation : RequestBase
    {
        protected RequestTransactionOperation(RequestType Type, String OriginatorId, String Password, String BaseURL, String TransactionId) : base(Type, OriginatorId, Password, BaseURL, TransactionId)
        {
            
        }

        public void SetAmount(int amount)
        {
            this.requestObject = new RequestCreatePaymentObject {amount = amount};
        }

        public async Task<ResponseRefundRebillCancel> Send()
        {
            return await SendRequestToServer<ResponseRefundRebillCancel>();
        }
    }

    [Obsolete("Class is deprecated. Suggested to use relevant classes: RequestRefund, RequestRebill, RequestCancel, RequestCapture")]
    public class RequestRefundRebillCancel : RequestTransactionOperation
    {
        public RequestRefundRebillCancel(RequestType Type, String OriginatorId, String Password, String BaseURL, String TransactionId) : base(Type, OriginatorId, Password, BaseURL, TransactionId)
        {
            
        }
    }

    public class RequestCapture : RequestTransactionOperation
    {
        public RequestCapture(RequestType Type, string OriginatorId, string Password, string BaseURL, string TransactionId) : base(Type, OriginatorId, Password, BaseURL, TransactionId)
        {
            
        }
    }
    
    public class RequestRefund : RequestTransactionOperation
    {
        public RequestRefund(RequestType Type, string OriginatorId, string Password, string BaseURL, string TransactionId) : base(Type, OriginatorId, Password, BaseURL, TransactionId)
        {
            
        }
    }
    
    public class RequestRebill : RequestTransactionOperation
    {
        public RequestRebill(RequestType Type, string OriginatorId, string Password, string BaseURL, string TransactionId) : base(Type, OriginatorId, Password, BaseURL, TransactionId)
        {
            
        }
    }
    
    public class RequestCancel : RequestTransactionOperation
    {
        public RequestCancel(RequestType Type, string OriginatorId, string Password, string BaseURL, string TransactionId) : base(Type, OriginatorId, Password, BaseURL, TransactionId)
        {
            
        }
    }

}
