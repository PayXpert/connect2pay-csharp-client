using Connect2PayLibrary.Responses;
using System;
using System.Threading.Tasks;

namespace Connect2PayLibrary.Requests
{
    public class RequestWeChatDirectObject : BaseRequestObject
    {
        public String apiVersion { get; set; }
        public String mode { get; set; }
        public String quickPayCode { get; set; }
        public String notificationLang { get; set; }
        public String notificationTimeZone { get; set; }

        public RequestWeChatDirectObject()
        {
            this.apiVersion = "002.60";
            this.mode = WeChatDirectMode.NATIVE;
        }
    }

    public class RequestWeChatDirect : RequestBase
    {
        public RequestWeChatDirectObject Data
        {
            get { return (RequestWeChatDirectObject)this.requestObject; }
        }

        public RequestWeChatDirect(RequestType Type, String OriginatorId, String Password, String BaseURL, String CustomerToken) : base(Type, OriginatorId, Password, BaseURL, CustomerToken)
        {
            this.requestObject = new RequestWeChatDirectObject();            
        }

        public async Task<ResponseAliPayWeChatDirect> Send()
        {
            return await SendRequestToServer<ResponseAliPayWeChatDirect>();
        }

    }
}
