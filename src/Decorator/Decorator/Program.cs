using System;
using System.Collections.Generic;
using StarBuzz.Beverages;
using StarBuzz.Condiments;

namespace StarBuzz
{
    class Program
    {
        private static readonly List<Beverage> CoffeeMenu = new List<Beverage>() { new DarkRoast(), new Espresso(), new HouseBlend(), new Decaf()};
        private static readonly List<Condiment> CondimentsMenu = new List<Condiment>() { new Whip(), new Soy(), new Mocha(), new SteamedMilk() };
        static void Main(string[] args)
        {
            var storeInstance = new Store(CoffeeMenu, CondimentsMenu);
            storeInstance.PrintMenu();
            var waitingForUserToChooseBeverage = true;
            var chosenBeverageIndex = 0;
            Console.WriteLine($"\r\nPlease choose an item from the menu [1 - {CoffeeMenu.Count}]");
            while (waitingForUserToChooseBeverage) { 
                var keyPress = Console.ReadKey(true);
                if(keyPress.Key == ConsoleKey.Escape) return;

                if (!int.TryParse(keyPress.KeyChar.ToString(), out chosenBeverageIndex)) continue;
                if(chosenBeverageIndex > 0 && chosenBeverageIndex <= CoffeeMenu.Count)
                    waitingForUserToChooseBeverage = false;
            }
            Store.PlaceOrder(CoffeeMenu[chosenBeverageIndex-1]);
            Console.ReadKey();
        }
    }
}
