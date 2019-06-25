using System;
using System.Collections.Generic;
using StarBuzz.Beverages;

namespace StarBuzz
{
    class Program
    {
        private static readonly List<Beverage> Menu = new List<Beverage>() { new DarkRoast(), new Espresso(), new HouseBlend(), new Decaf()};
        static void Main(string[] args)
        {
            var storeInstance = new Store(Menu,null);
            storeInstance.PrintMenu();
        }
    }
}
