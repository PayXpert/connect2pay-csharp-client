using System;
using System.Collections.Generic;
using System.Text;

namespace Connect2PayLibrary.Responses
{
    public class ResponseSubscriptionCancel : Connect2PayBaseResponseObject
    {
        public String code { get; set; }
        public String message { get; set; }

        public override bool IsSuccessfull()
        {
            return (code != null && code == "200");
        }
    }
}
