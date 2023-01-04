using System;
using System.Globalization;

namespace VendingMachineCore
{
    public class VendingMachine
    {
        public Coin _coin { get; }


        public VendingMachine()
        {
            _coin = new Coin();

        }


        public List<string> CoinsReturn = new List<string>();

        public decimal CoinsValueInMachine { get; private set; }

        public string Display { get; private set; } = "INSERT COIN";

        public string DespensedProductName = "";
        public decimal DespensedProductPrice = 0M;

        public decimal TotalChange = 0M;

        public bool AcceptCoins(Coin.Coins coin)
        {

            if (_coin.IsInvalidCoin(coin))
            {
                CoinsReturn.Add(_coin.GetName(coin));

                return false;
            }

            CoinsValueInMachine += (decimal)coin;

            Display = (CoinsValueInMachine / 100).ToString("C", new CultureInfo("en-GB"));

            return true;
        }

        public bool SelectProduct(int item)
        {
            decimal price;
            string product = string.Empty;
            bool result = false;

            switch (item)
            {
                case 1:
                    product = "Cola";
                    price = 100M;
                    break;
                case 2:
                    product = "Crisps";
                    price = 50M;
                    break;
                case 3:
                    product = "Chocolate";
                    price = 65M;
                    break;
                default:
                    price = 0M;
                    Display = "Invalid Selection";
                    break;

            }

            //Check if enough coins are inserted
            if (CoinsValueInMachine < price)
            {
                Display = $"PRICE: {(price / 100).ToString("C", new CultureInfo("en-GB"))}";
            }
            else
            {

                Display = "THANK YOU";
                // CoinsValueInMachine = 0;
                DespensedProductName = product;
                DespensedProductPrice = price;
                result = true;
            }

            return result;

        }

        public decimal MakeChange()
        {
            decimal change = 0M;

            if (CoinsValueInMachine > 0 && CoinsValueInMachine > DespensedProductPrice)
            {
                change = CoinsValueInMachine - DespensedProductPrice;

                while (change > 0)
                {
                    if (change >= (decimal)Coin.Coins.pound2)
                    {
                        change -= (decimal)Coin.Coins.pound2;
                        CoinsReturn.Add(_coin.GetName(Coin.Coins.pound2));
                    }
                    else if (change >= (decimal)Coin.Coins.pound1)
                    {
                        change -= (decimal)Coin.Coins.pound1;
                        CoinsReturn.Add(_coin.GetName(Coin.Coins.pound1));

                    }
                    else if (change >= (decimal)Coin.Coins.pence50)
                    {
                        change -= (decimal)Coin.Coins.pence50;
                        CoinsReturn.Add(_coin.GetName(Coin.Coins.pence50));

                    }
                    else if (change >= (decimal)Coin.Coins.pence20)
                    {
                        change -= (decimal)Coin.Coins.pence20;
                        CoinsReturn.Add(_coin.GetName(Coin.Coins.pence20));

                    }
                    else if (change >= (decimal)Coin.Coins.pence10)
                    {
                        change -= (decimal)Coin.Coins.pence10;
                        CoinsReturn.Add(_coin.GetName(Coin.Coins.pence10));

                    }
                    else if (change >= (decimal)Coin.Coins.pence5)
                    {
                        change -= (decimal)Coin.Coins.pence5;
                        CoinsReturn.Add(_coin.GetName(Coin.Coins.pence5));

                    }
                    else if (change >= (decimal)Coin.Coins.pence2)
                    {
                        change -= (decimal)Coin.Coins.pence2;
                        CoinsReturn.Add(_coin.GetName(Coin.Coins.pence2));

                    }
                    else
                    {
                        change -= (decimal)Coin.Coins.penny;
                        CoinsReturn.Add(_coin.GetName(Coin.Coins.penny));
                    }

                }
            }

            TotalChange = change;

            return change;
        }

        public void clear()
        {
            Display = "INSERT COIN";
            DespensedProductName = "";
            DespensedProductPrice = 0M;
            TotalChange = 0M;
            CoinsValueInMachine = 0M;


        }

        public void collectCoinsReturn()
        {

            CoinsReturn = new List<string>();

        }

    }
}

