using VendingMachineCore;
using FluentAssertions;
using System.Globalization;

namespace VendingMachineTests
{
    public class MakeChange
    {
        private readonly VendingMachine _vendingMachine = new VendingMachine();


        //When a product is selected that costs less than the amount of money in the machine, then the
        //remaining amount is placed in the coin return.
        [Fact]
        public void PlaceCoinsInCoinReturnIfProductCostLessThanAmountInMachine()
        {
            _vendingMachine.AcceptCoins(Coin.Coins.pound1);
            _vendingMachine.AcceptCoins(Coin.Coins.pence2);

            //Cola for £1.00
            _vendingMachine.SelectProduct(1);

            //Total amount in machine £3.00
            //Calling make change to place coins in coin return
            _vendingMachine.MakeChange();

            _vendingMachine.CoinsReturn.Should().NotBeEmpty();
            _vendingMachine.CoinsReturn.Should().Contain("2p");
        }

    }
}

