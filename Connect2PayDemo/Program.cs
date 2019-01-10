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

                Console.WriteLine("1: Create payment");

                Console.WriteLine("\nType 0 to exit\n");
                Console.WriteLine("Please type relevant number and press ENTER key\n");

                String key = Console.ReadLine();

                if (key == "1")
                {
                    TestCreatePayment();
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
