using System.Collections.Generic;
using System.Linq;
using StarBuzz.Beverages;

namespace StarBuzz
{
    public class Order
    {
        private readonly IStarBuzzConsole _writer;

        public Order(IStarBuzzConsole writer = null)
        {
            _writer = writer ?? new StarBuzzConsole();
            Items = new List<Beverage>();
        }

        public void AddBeverage(Beverage beverage)
        {
            Items.Add(beverage);
        }

        public List<Beverage> Items { get; }

        public void Print()
        {
            _writer.WriteLine($"You have {Items.Count} items in your order.");
            if (Items.Any())
            {
                _writer.WriteLine($"Total: £{Items.Sum(i => i.Cost()):F2}");
            }
        }
    }
}