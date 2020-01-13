using System;

namespace Connect2PayDemo
{
    partial class Program
    {
        private static String customerIP = "8.8.9.9";

        private static void DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine("\n");
                Console.WriteLine("=============================================================");
                Console.WriteLine("|           PayXpert Connect2Pay C# SDK demo                |");
                Console.WriteLine("|                (c) 2020, PayXpert Ltd                     |");
                Console.WriteLine("|               https://www.payxpert.com                    |");
                Console.WriteLine("=============================================================");
                Console.WriteLine("\n");
                Console.WriteLine("Please choose test to perform:\n");

                Console.WriteLine("1: Create payment and check payment status");
                Console.WriteLine("2: Request transaction info");
                Console.WriteLine("3: Request account information from API");
                Console.WriteLine("4: Authorize + Cancel");
                Console.WriteLine("5: Authorize + Capture");
                Console.WriteLine("6: Sale + rebill + refund");
                Console.WriteLine("7: Sale with subscription + cancel subscription");
                Console.WriteLine("8: WeChat direct payment");
                Console.WriteLine("9: AliPay direct payment");
                Console.WriteLine("10: Redirect status");
                Console.WriteLine("11: Export transactions");

                Console.WriteLine("\nType 0 to exit\n");
                Console.WriteLine("Please type relevant number and press ENTER key\n");

                String key = Console.ReadLine();

                if (key == "1")
                {
                    TestCreatePayment();
                }
                else if (key == "2")
                {
                    TestTransactionInfo();
                }
                else if (key == "3")
                {
                    TestAccountInfo();
                }
                else if (key == "4")
                {
                    TestAuthorizeCancel();
                }
                else if (key == "5")
                {
                    TestAuthorizeCapture();
                }
                else if (key == "6")
                {
                    TestSaleRebillRefund();
                }
                else if (key == "7")
                {
                    TestSaleSubscription();
                }
                else if (key == "8")
                {
                    TestWeChatDirect();
                }
                else if (key == "9")
                {
                    TestAliPayDirect();
                }
                else if (key == "10")
                {
                    TestRedirectEncryption();
                }
                else if (key == "11")
                {
                    TestTransactionsExport();
                }
                else if (key == "0")
                {
                    return;
                }
                else
                {
                    Console.WriteLine("Unknown command");
                }
            }
        }

        static void Main(string[] args)
        {
            DisplayMenu();
        }
    }
}
