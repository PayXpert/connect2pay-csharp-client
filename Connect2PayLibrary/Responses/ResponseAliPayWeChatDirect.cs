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

        // region For SDK and  Mini Program payments

        public String appId { get; set; }
        public String partnerId { get; set; }
        public String prepayId { get; set; }
        public String packageStr { get; set; }
        public String nonceStr { get; set; }
        public String timestamp { get; set; }
        public String sign { get; set; }
        public String paySign { get; set; }
        public String signType { get; set; }

        // endregion

        public override bool IsSuccessfull()
        {
            return (code != null && code == "200");
        }
    }
}
