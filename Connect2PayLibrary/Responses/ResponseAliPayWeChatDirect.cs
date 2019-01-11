using System;
using System.Collections.Generic;
using System.Text;

namespace Connect2PayLibrary.Responses
{
    public class ResponseAliPayWeChatDirect : Connect2PayBaseResponseObject
    {
        public String code { get; set; }
        public String message { get; set; }
        public String apiVersion { get; set; }
        public Double? exchangeRate { get; set; }
        public String qrCode { get; set; }
        public String qrCodeUrl { get; set; }
        public String webSocketUrl { get; set; }
        public String transactionID { get; set; }

        public Transaction transaction { get; set; }

        public override bool IsSuccessfull()
        {
            return (code != null && code == "200");
        }
    }
}
