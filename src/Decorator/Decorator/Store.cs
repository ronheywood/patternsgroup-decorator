using System;
using System.Collections.Generic;
using System.Linq;
using StarBuzz.Beverages;
using StarBuzz.Condiments;

namespace StarBuzz
{
    public class Store
    {
        private readonly List<Beverage> _coffeeMenu;
        private readonly IStarBuzzConsole _writer;
        private List<Condiment> _condimentsMenu;

        public Store(List<Beverage> coffeeMenu, List<Condiment> condimentsMenu = null, IStarBuzzConsole writer = null)
        {
            _condimentsMenu = condimentsMenu ?? new List<Condiment>();
            _coffeeMenu = coffeeMenu;
            _writer = writer ?? new StarBuzzConsole();
        }

        public void PrintMenu()
        {
            _writer.WriteLine("Welcome to StarBuzz coffee!\r\n\r\nMenu:");
            foreach (var beverage in _coffeeMenu)
            {
                _writer.WriteLine($"{beverage} - £{beverage.Cost():F2}");
            }

            if (_condimentsMenu.Any())
            {
                _writer.WriteLine("\r\nCondiments:");
                foreach (var condiment in _condimentsMenu)
                {
                    //{ beverage.Cost():F2}
                    _writer.WriteLine($"{condiment.GetDescription()} - £0.25");
                }
            }
            _writer.ReadKey();
        }
    }

    public class StarBuzzConsole : IStarBuzzConsole
    {
        public void WriteLine(string str)
        {
            Console.WriteLine(str);
        }

        public string ReadKey()
        {
            return Console.ReadKey().ToString();
        }
    }

    public interface IStarBuzzConsole
    {
        void WriteLine(string str);
        string ReadKey();
    }
}
