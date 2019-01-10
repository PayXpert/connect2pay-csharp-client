using Connect2PayLibrary.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Connect2PayLibrary.Requests
{
    public class RequestSubscriptionCancelObject : BaseRequestObject
    {
        public String apiVersion { get; set; }
        public String cancelReason { get; set; }

        public RequestSubscriptionCancelObject()
        {
            this.apiVersion = "002.50";
        }
    }

    public class RequestSubscriptionCancel : RequestBase
    {
        public RequestSubscriptionCancel(RequestType Type, String OriginatorId, String Password, String BaseURL, String SubscriptionID) : base(Type, OriginatorId, Password, BaseURL, SubscriptionID)
        {

        }

        public void SetReason(String subscriptionCancelReason)
        {
            var requestObject = new RequestSubscriptionCancelObject();
            requestObject.cancelReason = subscriptionCancelReason;
            this.requestObject = requestObject;
        }

        public async Task<ResponseSubscriptionCancel> Send()
        {
            return await SendRequestToServer<ResponseSubscriptionCancel>();
        }
    }

}
