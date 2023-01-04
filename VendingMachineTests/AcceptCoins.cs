using VendingMachineCore;
using FluentAssertions;
using System.Globalization;

namespace VendingMachineTests;

public class AcceptCoins
{
    private readonly VendingMachine _vendingMachine = new VendingMachine();



    //Reference: The vending machine will accept valid coins (5p, 10p, 20p, 50p, £1.00, £2.00) and reject invalid
    //ones(1p, 2p).
    [Theory]
    [InlineData(Coin.Coins.penny)]
    [InlineData(Coin.Coins.pence2)]
    [InlineData(Coin.Coins.pence10)]
    [InlineData(Coin.Coins.pound1)]
    public void AcceptValidCoinsAndRejectInvalidCoins(Coin.Coins coin)
    {
        bool result = _vendingMachine.AcceptCoins(coin);

        if (coin == Coin.Coins.penny || coin == Coin.Coins.pence2)
        {
            result.Should().Be(false);
            _vendingMachine.CoinsReturn.Should().NotBeEmpty();
            _vendingMachine.CoinsValueInMachine.Should().Be(0);
            _vendingMachine.Display.Should().Be("INSERT COIN");

        }
        else
        {
            result.Should().Be(true);
            _vendingMachine.CoinsReturn.Should().BeEmpty();
            _vendingMachine.CoinsValueInMachine.Should().NotBe(0);
            _vendingMachine.Display.Should().NotBe("INSERT COIN");
        }
    }



    //Reference: When a valid coin is inserted the amount of the coin will be added to the current amount and the
    //display will be updated.
    [Theory]
    [InlineData(10, Coin.Coins.pence10)]
    [InlineData(200, Coin.Coins.pound2)]
    public void IncreaseTotalValueInMachine(decimal expected, Coin.Coins coin)
    {
        _vendingMachine.AcceptCoins(coin);

        _vendingMachine.CoinsValueInMachine.Should().Be(expected);
        _vendingMachine.Display.Should().Be((expected / 100).ToString("C", new CultureInfo("en-GB")));

    }

    [Theory]
    [InlineData(100, Coin.Coins.pence50, Coin.Coins.pence50)]
    [InlineData(110, Coin.Coins.pence10, Coin.Coins.pound1)]
    [InlineData(350, Coin.Coins.pound2, Coin.Coins.pound1, Coin.Coins.pence50)]
    public void IncreaseTotalValueInMachineMultipleCoins(decimal expected, params Coin.Coins[] coins)
    {
        foreach (var coin in coins)
        {
            _vendingMachine.AcceptCoins(coin);
        }
        _vendingMachine.CoinsValueInMachine.Should().Be(expected);
        _vendingMachine.Display.Should().Be((expected / 100).ToString("C", new CultureInfo("en-GB")));
    }
    //End 



    //Reference: When there are no coins inserted, the machine displays INSERT COIN.
    [Fact]
    public void NoCoinsInserted()
    {
        _vendingMachine.Display.Should().Be("INSERT COIN");

    }



    //Reference: Rejected coins are placed in the coin return.
    [Theory]
    [InlineData(Coin.Coins.penny)]
    [InlineData(Coin.Coins.pence2)]
    public void RejectInvalidCoins(Coin.Coins coin)
    {
        bool result = _vendingMachine.AcceptCoins(coin);

        result.Should().Be(false);
        _vendingMachine.CoinsReturn.Should().NotBeEmpty();
    }



}
