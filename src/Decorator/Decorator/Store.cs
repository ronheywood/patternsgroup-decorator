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
        private static Order _order;

        public Store(List<Beverage> coffeeMenu, List<Condiment> condimentsMenu = null, IStarBuzzConsole writer = null)
        {
            _condimentsMenu = condimentsMenu ?? new List<Condiment>();
            _coffeeMenu = coffeeMenu;
            _writer = writer ?? new StarBuzzConsole();
            _order = new Order(_writer);
        }

        public void PrintMenu()
        {
            _writer.WriteLine("Welcome to StarBuzz coffee!\r\n\r\nCoffee Menu:");
            var i = 1;
            foreach (var beverage in _coffeeMenu)
            {
                _writer.WriteLine($"[{i}] : {beverage} - £{beverage.Cost():F2}");
                i++;
            }

            if (_condimentsMenu.Any())
            {
                _writer.WriteLine("\r\nCondiments:");
                foreach (var condiment in _condimentsMenu)
                {
                    _writer.WriteLine($"{condiment.GetDescription()} - £0.25");
                }
            }

        }

        public static void PlaceOrder(Beverage beverage)
        {
            _order.AddBeverage(beverage);
            _order.Print();
        }
    }
}
