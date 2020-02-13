using System;
using System.Collections.Generic;

public class CoffeeMachine
{
    public CoffeeMachine()
    {
        this.InsertedCoins = 0;
        this.CoffeesSold = new List<CoffeeType>();
    }

    public int InsertedCoins { get; private set; }

    public IList<CoffeeType> CoffeesSold { get; }

    public void BuyCoffee(string size, string type)
    {
        var coffeeType = (CoffeeType)Enum.Parse(typeof(CoffeeType), type);

        switch (size)
        {
            case "Small":
                CheckPriceAndPurchase(coffeeType, CoffeePrice.Small);
                break;

            case "Normal":
                CheckPriceAndPurchase(coffeeType, CoffeePrice.Normal);
                break;

            case "Double":
                CheckPriceAndPurchase(coffeeType, CoffeePrice.Double);
                break;
        }
    }

    private void CheckPriceAndPurchase(CoffeeType coffeeType, CoffeePrice price)
    {
        if (this.InsertedCoins >= (int)price)
        {
            this.CoffeesSold.Add(coffeeType);
            this.InsertedCoins = 0;
        }
    }

    public void InsertCoin(string coin)
    {
        var currentCoin = Enum.Parse(typeof(Coin), coin);
        this.InsertedCoins += (int)currentCoin;
    }
}
