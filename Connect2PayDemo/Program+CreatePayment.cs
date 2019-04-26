using Connect2PayLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using SDKTest;

namespace Connect2PayDemo
{
    partial class Program
    {
        private static void TestCreatePayment()
        {
            var client = new Connect2PayClient(OriginatorConfig.ORIGINATOR_ID, OriginatorConfig.ORIGINATOR_PASSWORD);
            var request = client.NewRequestCreatePayment();

            request.Data.orderID = "ABC-123456";
            request.Data.paymentMethod = PaymentMethod.CREDIT_CARD;
            request.Data.paymentMode = PaymentMode.SINGLE;
            request.Data.shopperID = "RICH_SHOPPER";
            request.Data.shippingType = ShippingType.VIRTUAL;

            request.Data.amount = 2500;  // 25 EUR
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
                    Console.WriteLine("After you finish please press any key. Payment status will be requested");
                    Console.ReadKey();

                    var requestPaymentStatus = client.NewRequestPaymentStatus(response.merchantToken);
                    var responsePaymentStatus = requestPaymentStatus.Send().Result;

                    Console.WriteLine("Payment status response received: " + responsePaymentStatus.status);
                }
                else
                {
                    Console.WriteLine("Request failure: " + response.code + ": " + response.message);
                }
            }
        } 
    }
}
