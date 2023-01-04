using VendingMachineCore;
using FluentAssertions;
using System.Globalization;

namespace VendingMachineTests
{
    public class SelectProduct
    {
        private readonly VendingMachine _vendingMachine = new VendingMachine();



        //When the respective button is pressed and enough money has been inserted, the product is
        //dispensed and the machine displays THANK YOU.
        [Fact]
        public void DispenseProductOnEnoughMoney()
        {
            _vendingMachine.AcceptCoins(Coin.Coins.pence50);
            _vendingMachine.AcceptCoins(Coin.Coins.pence50);

            //Cola for £1.00
            _vendingMachine.SelectProduct(1);

            //100p = £1
            _vendingMachine.CoinsValueInMachine.Should().BeGreaterThanOrEqualTo(100);
            _vendingMachine.Display.Should().Be("THANK YOU");
            _vendingMachine.DespensedProductName.Should().NotBeEmpty();
        }


        //If the display is checked again, it will display INSERT COIN and the current amount will be set to
        //£0.00.
        [Fact]
        public void ResetDisplayOnSuccessfulPurchase()
        {
            _vendingMachine.AcceptCoins(Coin.Coins.pence50);
            _vendingMachine.AcceptCoins(Coin.Coins.pence50);

            //Cola for £1.00
            _vendingMachine.SelectProduct(1);

            //100p = £1
            _vendingMachine.CoinsValueInMachine.Should().BeGreaterThanOrEqualTo(100);

            _vendingMachine.Display.Should().Be("THANK YOU");
            _vendingMachine.DespensedProductName.Should().NotBeEmpty();

            _vendingMachine.clear();
            _vendingMachine.Display.Should().Be("INSERT COIN");
            _vendingMachine.CoinsValueInMachine.Should().Be(0M);

        }



        //If there is not enough money inserted then the machine displays PRICE and the price of the item
        [Fact]
        public void DispenseProductOnNotEnoughMoney()
        {
            decimal price = 100;
            string expectedDisplayText = $"PRICE: { (price / 100).ToString("C", new CultureInfo("en-GB"))}";

            _vendingMachine.AcceptCoins(Coin.Coins.pence20);
            _vendingMachine.AcceptCoins(Coin.Coins.pence50);

            //Cola for £1.00
            _vendingMachine.SelectProduct(1);

            //Total amount in machine £0.70
            _vendingMachine.CoinsValueInMachine.Should().BeLessThan(price);
            _vendingMachine.Display.Should().Be(expectedDisplayText);
            _vendingMachine.DespensedProductName.Should().BeEmpty();
        }

    }
}

