using Connect2PayLibrary;
using System;
using System.Collections.Generic;
using System.Text;
using SDKTest;

namespace Connect2PayDemo
{
    partial class Program
    {
        private static void TestWeChatDirect()
        {
            var client = new Connect2PayClient(OriginatorConfig.ORIGINATOR_ID, OriginatorConfig.ORIGINATOR_PASSWORD);
            var request = client.NewRequestCreatePayment();

            request.Data.orderID = "ABC-123456";
            request.Data.paymentMethod = PaymentMethod.CREDIT_CARD;
            request.Data.paymentMode = PaymentMode.SINGLE;
            request.Data.shopperID = "RICH_SHOPPER";
            request.Data.shippingType = ShippingType.VIRTUAL;
            request.Data.operation = Operation.SALE;

            request.Data.paymentMethod = PaymentMethod.WECHAT;
            request.Data.paymentMode = PaymentMode.SINGLE;

            request.Data.amount = 1500;  // 15 EUR
            request.Data.currency = "EUR";

            request.Data.orderDescription = "Payment of €15.00";

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

                    Console.WriteLine("Preparing WeChat direct payment...");

                    var requestWeChatDirect = client.NewRequestWeChatDirect(response.customerToken);

                    requestWeChatDirect.Data.mode = WeChatDirectMode.NATIVE;

                    var responseWeChatDirect = requestWeChatDirect.Send().Result;

                    if (responseWeChatDirect.IsSuccessfull())
                    {
                        Console.WriteLine("WeChat direct request prepared successfully");
                        Console.WriteLine("WeChat QR code URL: " + responseWeChatDirect.qrCodeUrl);
                        Console.WriteLine("Please press any key to continue");
                        Console.ReadKey();
                    }
                    else
                    {
                        Console.WriteLine("WeChat direct request failure: " + responseWeChatDirect.code + ": " + responseWeChatDirect.message);
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
