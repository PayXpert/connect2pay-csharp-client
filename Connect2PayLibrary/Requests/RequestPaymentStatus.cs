using Connect2PayLibrary.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Connect2PayLibrary.Requests
{
    public class RequestPaymentStatus : RequestBase
    {
        public RequestPaymentStatus(RequestType Type, String OriginatorId, String Password, String BaseURL, String MerchantToken) : base(Type, OriginatorId, Password, BaseURL, MerchantToken)
        {
        }

        public async Task<PaymentStatusResponse> Send()
        {
            return await SendRequestToServer<PaymentStatusResponse>();
        }
    }
}
