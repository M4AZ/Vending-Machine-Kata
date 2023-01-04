namespace VendingMacihineApp
{
    using System.Globalization;
    using VendingMachineCore;


    public class Program
    {

        public static void Main(string[] args)
        {
            VendingMachine vendingMachine = new VendingMachine();
            Menu menu = new Menu();

            while (true)
            {


                menu.Display(vendingMachine.Display, vendingMachine.CoinsValueInMachine, vendingMachine.CoinsReturn);

                string input = Console.ReadLine();


                if (input == "1")
                {
                    Console.WriteLine("1] Insert 1p");
                    Console.WriteLine("2] Insert 2p");
                    Console.WriteLine("3] Insert 5p");
                    Console.WriteLine("4] Insert 10p");
                    Console.WriteLine("5] Insert 20p");
                    Console.WriteLine("6] Insert 50p");
                    Console.WriteLine("7] Insert £1");
                    Console.WriteLine("8] Insert £2");

                    string coinInserted = Console.ReadLine();

                    switch (coinInserted)
                    {
                        case "1":
                            vendingMachine.AcceptCoins(Coin.Coins.penny);
                            break;
                        case "2":
                            vendingMachine.AcceptCoins(Coin.Coins.pence2);
                            break;
                        case "3":
                            vendingMachine.AcceptCoins(Coin.Coins.pence5);
                            break;
                        case "4":
                            vendingMachine.AcceptCoins(Coin.Coins.pence10);
                            break;
                        case "5":
                            vendingMachine.AcceptCoins(Coin.Coins.pence20);
                            break;
                        case "6":
                            vendingMachine.AcceptCoins(Coin.Coins.pence50);
                            break;
                        case "7":
                            vendingMachine.AcceptCoins(Coin.Coins.pound1);
                            break;
                        case "8":
                            vendingMachine.AcceptCoins(Coin.Coins.pound2);
                            break;
                        default:
                            Console.WriteLine("Invalid selection");
                            break;

                    }

                    Console.WriteLine($"Amount in Machine: {(vendingMachine.CoinsValueInMachine / 100).ToString("C", new CultureInfo("en-GB"))}");

                    if (vendingMachine.CoinsReturn.Count > 0)
                    {

                        Console.WriteLine($"Coins in Return Box: {String.Join(",", vendingMachine.CoinsReturn)} ");

                    }
                    else
                    {
                        Console.WriteLine($"Coins in Return Box: EMPTY ");
                    }


                }
                else if (input == "2")
                {

                    Console.Write("> What item do you want? ");
                    string selection = Console.ReadLine();

                    bool result = vendingMachine.SelectProduct(int.Parse(selection));
                    vendingMachine.MakeChange();

                    Console.WriteLine(vendingMachine.Display);

                    if (result)
                        vendingMachine.clear();


                }
                else if (input == "3")
                {
                    vendingMachine.collectCoinsReturn();

                }
                else
                {
                    Console.WriteLine("Invalid selection, Please try again..");
                }

                Console.ReadLine();
            }

        }

    }


}
