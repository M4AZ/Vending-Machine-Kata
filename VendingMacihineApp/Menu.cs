using System;
using System.Globalization;

namespace VendingMachineCore
{
    public class Menu
    {

        public void Display(string vendingMachinedisplay, decimal coinsValue, List<string> returnedCoins)
        {
            Console.Clear();
            Console.WriteLine();


            Console.WriteLine($"Display Screen] {vendingMachinedisplay}");

            Console.WriteLine("");

            Console.WriteLine("1] Cola for £1.00");
            Console.WriteLine("2] Crisps for 50p");
            Console.WriteLine("3] Chocolate for 65p");
            Console.WriteLine("");

            Console.WriteLine($"Amount in Machine: {(coinsValue / 100).ToString("C", new CultureInfo("en-GB"))}");

            if (returnedCoins.Count > 0)
            {

                Console.WriteLine($"Coins in Return Box: {String.Join(",", returnedCoins)} ");

            }
            else
            {
                Console.WriteLine($"Coins in Return Box: EMPTY ");
            }

            Console.WriteLine("");

            Console.WriteLine("Please choose from the following options:");
            Console.WriteLine("1] >> Insert Coins");
            Console.WriteLine("2] >> Select Product");
            Console.WriteLine("3] >> Collect Coins from coin retun");

            Console.Write("Option >");



        }



    }
}

