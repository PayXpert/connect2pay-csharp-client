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
                Console.WriteLine("|                (c) 2019, PayXpert Ltd                     |");
                Console.WriteLine("|               https://www.payxpert.com                    |");
                Console.WriteLine("=============================================================");
                Console.WriteLine("\n");
                Console.WriteLine("Please choose test to perform:\n");

                Console.WriteLine("1: Create payment and check payment status");
                Console.WriteLine("2: Request transaction info");
                Console.WriteLine("3: Request account information from API");

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
