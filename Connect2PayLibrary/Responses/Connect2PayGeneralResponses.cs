using System;
using System.Collections.Generic;
using System.Text;

namespace Connect2PayLibrary.Responses
{
    public abstract class Connect2PayBaseResponseObject
    {
        public abstract Boolean IsSuccessfull();
    }

    public class CreatePaymentResponse : Connect2PayBaseResponseObject
    {
        public String code { get; set; }
        public String message { get; set; }
        public String customerToken { get; set; }
        public String merchantToken { get; set; }

        public override bool IsSuccessfull()
        {
            return (code != null && code == "200");
        }

    }
}
