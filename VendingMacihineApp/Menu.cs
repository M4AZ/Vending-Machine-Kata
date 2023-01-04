using System;
namespace VendingMachineCore
{
    public class Menu
    {
        private decimal _coinsValue { get; set; }

        internal Menu(decimal coinsValue)
        {
            _coinsValue = coinsValue;
        }

        public void Display()
        {
            VendingMachine vm = new VendingMachine();

            PrintHeader();
            while (true)
            {
                Console.WriteLine();
                Console.WriteLine("1] Cola for £1.00");
                Console.WriteLine("2] Crisps for 50p");
                Console.WriteLine("3] Chocolate for 65p");


                Console.ReadLine();
                Console.Clear();
            }
        }

        private static void PrintHeader()
        {
            Console.WriteLine("WELCOME TO THE BEST VENDING MACHINE EVER!!!! (Distant crowd roar)");
        }

    }
}

