using System;
using System.Threading.Tasks;
using Connect2PayLibrary.Responses;

namespace Connect2PayLibrary.Requests
{
    public class RequestExportTransactions : RequestBase
    {
        private readonly String StartDate;
        private readonly String EndDate;

        private String Operation = null;
        private String PaymentMethod = null;
        private String PaymentNetwork = null;
        private Nullable<Int32> TransactionResultCode = null;

        public RequestExportTransactions(RequestType Type, String OriginatorId, String Password, String BaseURL, String StartDate, String EndDate) : base(Type, OriginatorId, Password, BaseURL, null)
        {
            this.StartDate = StartDate;
            this.EndDate = EndDate;
        }

        public void SetOperation(String Operation)
        {
            this.Operation = Operation;
        }

        public void SetPaymentMethod(String PaymentMethod)
        {
            this.PaymentMethod = PaymentMethod;
        }

        public void SetPaymentNetworkd(String PaymentNetwork)
        {
            this.PaymentNetwork = PaymentNetwork;
        }

        public void SetTransactionResultCode(Int32 TransactionResultCode)
        {
            this.TransactionResultCode = TransactionResultCode;
        }

        public async Task<ResponseExportTransactions> Send()
        {
            this.getParams = "startTime=" + StartDate + "&endTime=" + EndDate;

            if (this.Operation != null)
            {
                this.getParams = this.getParams + "&operation" + this.Operation;
            }

            if (this.PaymentMethod != null)
            {
                this.getParams = this.getParams + "&paymentMethod" + this.PaymentMethod;
            }

            if (this.PaymentNetwork != null)
            {
                this.getParams = this.getParams + "&paymentNetwork" + this.PaymentNetwork;
            }

            if (this.TransactionResultCode != null)
            {
                this.getParams = this.getParams + "&transactionResultCode" + this.TransactionResultCode.Value.ToString();
            }

            return await SendRequestToServer<ResponseExportTransactions>();
        }
    }
}
