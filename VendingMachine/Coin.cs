using System.Globalization;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("VendingMachineTests")]
namespace VendingMachineCore;
public class Coin
{


    public Coin()
    {

    }

    public List<Coin.Coins> InvalidCoins = new List<Coins> { Coins.penny, Coins.pence2 };


    public bool IsInvalidCoin(Coins coin) => InvalidCoins.Contains(coin);


    public enum Coins
    {
        penny = 1,
        pence2 = 2,
        pence5 = 5,
        pence10 = 10,
        pence20 = 20,
        pence50 = 50,
        pound1 = 100,
        pound2 = 200

    }

    public string GetName(Coins coin)
    {
        string name = string.Empty;
        switch (coin)
        {
            case Coins.penny:
                name = "1p";
                break;
            case Coins.pence2:
                name = "2p";
                break;
            case Coins.pence5:
                name = "5p";
                break;
            case Coins.pence10:
                name = "10p";
                break;
            case Coins.pence20:
                name = "20p";
                break;
            case Coins.pence50:
                name = "50p";
                break;
            case Coins.pound1:
                name = "£1";
                break;
            case Coins.pound2:
                name = "£2";
                break;
            default:
                break;

        }
        return name;
    }



}

