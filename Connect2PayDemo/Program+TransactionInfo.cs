using Connect2PayLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using SDKTest;

namespace Connect2PayDemo
{
    partial class Program
    {
        private static String TransactionID = "";

        private static void TestTransactionInfo()
        {
            if (TransactionID == "")
            {
                Console.WriteLine("To perform this test please set TransactionID field in Program+TransactionInfo.cs and recompile project");
                Console.WriteLine("Press any key to continue");
                Console.ReadKey();
                return;
            }

            var client = new Connect2PayClient(OriginatorConfig.ORIGINATOR_ID, OriginatorConfig.ORIGINATOR_PASSWORD);
            var request = client.NewRequestTransactionInfo(TransactionID);
            var response = request.Send().Result;
     
            if (response == null)
            {
                Console.WriteLine("Failure");
            } else
            {
                Console.WriteLine("Transaction operation: " + response.operation);
            }
        }
    }
}
