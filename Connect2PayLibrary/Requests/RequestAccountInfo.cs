using Connect2PayLibrary.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Connect2PayLibrary.Requests
{
    public class RequestAccountInfo : RequestBase
    {
        public RequestAccountInfo(RequestType Type, String OriginatorId, String Password, String BaseURL) : base(Type, OriginatorId, Password, BaseURL, null)
        {
        }

        public async Task<AccountInfoResponse> Send()
        {
            return await SendRequestToServer<AccountInfoResponse>();
        }
    }
}
