using Connect2PayLibrary.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Connect2PayLibrary.Requests
{
    public class RequestTransactionInfo : RequestBase
    {
        public RequestTransactionInfo(RequestType Type, String OriginatorId, String Password, String BaseURL, String TransactionID) : base(Type, OriginatorId, Password, BaseURL, TransactionID)
        {
        }

        public async Task<Transaction> Send()
        {
            return await SendRequestToServer<Transaction>();
        }
    }
}
