using Connect2PayLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using SDKTest;

namespace Connect2PayDemo
{
    partial class Program
    {
        private static void TestAccountInfo()
        {
            var client = new Connect2PayClient(OriginatorConfig.ORIGINATOR_ID, OriginatorConfig.ORIGINATOR_PASSWORD);
            var request = client.NewRequestAccountInfo();
            var response = request.Send().Result;

            if (response == null)
            {
                Console.WriteLine("Failure");
            }
            else
            {
                Console.WriteLine("Account info retrieved. Merchant name: " + response.name);
            }

        }
    }
}
