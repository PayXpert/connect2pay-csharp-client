using System;
using System.Collections.Generic;
using System.Text;

namespace Connect2PayLibrary.Responses
{
    public class ResponseRefundRebillCancel : Connect2PayBaseResponseObject
    {
        public String code { get; set; }
        public String message { get; set; }
        public String transactionID { get; set; }
        public String operation { get; set; }

        public override bool IsSuccessfull()
        {
            return (code != null && code == "000");
        }
    }
}
