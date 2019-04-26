using Connect2PayLibrary;
using System;
using SDKTest;

namespace Connect2PayDemo
{
    partial class Program
    {
        private static void TestAuthorizeCancel()
        {
            var client = new Connect2PayClient(OriginatorConfig.ORIGINATOR_ID, OriginatorConfig.ORIGINATOR_PASSWORD);
            var request = client.NewRequestCreatePayment();

            request.Data.orderID = "ABC-123456";
            request.Data.paymentMethod = PaymentMethod.CREDIT_CARD;
            request.Data.paymentMode = PaymentMode.SINGLE;
            request.Data.shopperID = "RICH_SHOPPER";
            request.Data.shippingType = ShippingType.VIRTUAL;
            request.Data.operation = Operation.AUTHORIZE;

            request.Data.amount = 1500;  // 15 EUR
            request.Data.currency = "EUR";

            request.Data.orderDescription = "Payment of €25.00";

            request.Data.shopperFirstName = "RICH";
            request.Data.shopperLastName = "SHOPPER";
            request.Data.shopperAddress = "NA";
            request.Data.shopperZipcode = "999111";
            request.Data.shopperCity = "NA";
            request.Data.shopperCountryCode = "GB";
            request.Data.shopperPhone = "123-456";
            request.Data.shopperEmail = "test@test.test";

            request.Data.ctrlCustomData = "Give that back to me please !!";
            request.Data.ctrlRedirectURL = "https://merchant.example.com/payment/redirect";
            request.Data.ctrlCallbackURL = "https://merchant.example.com/payment/callback";

            if (request.Data.Validate())
            {
                var response = request.Send().Result;

                if (response.IsSuccessfull())
                {
                    Console.WriteLine("Request executed successfully");
                    Console.WriteLine("Merchant token: " + response.merchantToken);
                    Console.WriteLine("Customer redirect URL: " + request.getCustomerRedirectURL());

                    Console.WriteLine("You can copy this URL to browser and make a test payment");
                    Console.WriteLine("After you finish please press any key. Payment status will be requested and cancellation will be performed");
                    Console.ReadKey();

                    var requestPaymentStatus = client.NewRequestPaymentStatus(response.merchantToken);
                    var responsePaymentStatus = requestPaymentStatus.Send().Result;

                    String transactionID = null;

                    if (responsePaymentStatus.transactions.Count > 0)
                    {
                        transactionID = responsePaymentStatus.transactions[0].transactionID;
                    }

                    if (transactionID == null)
                    {
                        Console.WriteLine("Unknown error: transaction ID not retrieved");
                        return;
                    }

                    Console.WriteLine("Received transaction ID: " + transactionID);

                    var requestCancel = client.NewRequestTransactionCancel(transactionID);
                    requestCancel.SetAmount(1500);
                    var responseCancel = requestCancel.Send().Result;

                    if (responseCancel.IsSuccessfull())
                    {
                        Console.WriteLine("Cancellation transaction ID: " + responseCancel.transactionID);
                        Console.WriteLine("Please press any key to continue");
                        Console.ReadKey();
                    } else
                    {
                        Console.WriteLine("Cancellation request failure: " + responseCancel.code + ": " + responseCancel.message);
                    }
                }
                else
                {
                    Console.WriteLine("Request failure: " + response.code + ": " + response.message);
                }
            }
        }

    }
}
