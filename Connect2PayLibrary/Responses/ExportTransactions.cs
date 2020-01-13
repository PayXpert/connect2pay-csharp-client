using System;
using System.Collections.Generic;

namespace Connect2PayLibrary.Responses
{
    public class ResponseExportTransactions
    {
        public String apiVersion { get; set; }
        public List<Transaction> transactions { get; set; }
    }
}
