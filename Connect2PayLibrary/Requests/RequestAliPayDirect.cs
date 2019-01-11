using Connect2PayLibrary.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Connect2PayLibrary.Requests
{
    public class RequestAliPayDirectObject : BaseRequestObject
    {
        public String apiVersion { get; set; }
        public String mode { get; set; }
        public String buyerIdentityCode { get; set; }
        public String identityCodeType { get; set; }
        public String notificationLang { get; set; }
        public String notificationTimeZone { get; set; }

        public RequestAliPayDirectObject()
        {
            this.apiVersion = "002.60";
            this.mode = AliPayDirectMode.POS;
        }
    }

    public class RequestAliPayDirect : RequestBase
    {
        public RequestAliPayDirectObject Data
        {
            get { return (RequestAliPayDirectObject)this.requestObject; }
        }

        public RequestAliPayDirect(RequestType Type, String OriginatorId, String Password, String BaseURL, String CustomerToken) : base(Type, OriginatorId, Password, BaseURL, CustomerToken)
        {
            this.requestObject = new RequestAliPayDirectObject();
        }

        public async Task<ResponseAliPayWeChatDirect> Send()
        {
            return await SendRequestToServer<ResponseAliPayWeChatDirect>();
        }

    }

}
