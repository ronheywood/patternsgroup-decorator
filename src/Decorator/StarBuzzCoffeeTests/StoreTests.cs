using System.Collections.Generic;
using FakeItEasy;
using NUnit.Framework;
using StarBuzz;
using StarBuzz.Beverages;

namespace StarBuzzCoffeeTests
{
    [TestFixture]
    public class StoreTests
    {
        private IStarBuzzConsole _writer = A.Fake<IStarBuzzConsole>();
        
        [Test]
        public void Should_output_welcome_message()
        {
            var menu = new List<Beverage>() {new DarkRoast()};
            var testCoffeeShop = new Store(menu, null,_writer);
            testCoffeeShop.PrintMenu();
            A.CallTo(() => _writer.WriteLine(A<string>.That.Contains("Welcome to StarBuzz coffee!"))).MustHaveHappened();
        }

        [TestCase("A test coffee")]
        [TestCase("A second test")]
        [TestCase("A third test")]
        public void Should_list_all_beverages_in_the_menu(string description)
        {
            var coffeeType = new DarkRoast();
            var testType = new TestCoffee(){ Description = description };
            var menu = new List<Beverage>() { new DarkRoast(), new Espresso(), new HouseBlend(), new Decaf(), testType };
            var testCoffeeShop = new Store(menu, null, _writer);
            testCoffeeShop.PrintMenu();
            A.CallTo(() => _writer.WriteLine(A<string>.That.Contains(coffeeType.GetDescription()))).MustHaveHappened();
            A.CallTo(() => _writer.WriteLine(A<string>.That.Contains(description))).MustHaveHappened();
        }

        [TestCase(0)]
        [TestCase(2.50)]
        [TestCase(999.99)]
        public void Should_use_cost_method_to_calculate_price_for_menu(double cost)
        {
            var testType = new TestCoffee() { Description = "Testable coffee with price", TestableCost = cost };
            var menu = new List<Beverage>() { testType };
            var testCoffeeShop = new Store(menu, null,_writer);
            testCoffeeShop.PrintMenu();
            A.CallTo(() => _writer.WriteLine(A<string>.That.Contains($"£{cost:F2}"))).MustHaveHappened();
        }
        [Test]
        public void ShouldPrintTheOrder()
        {
            var menu = new List<Beverage>() { new DarkRoast(), new Espresso(), new HouseBlend(), new Decaf() };
            var testCoffeeShop = new Store(menu, null, _writer);
            Store.PlaceOrder(new DarkRoast());
            A.CallTo(() => _writer.WriteLine(A<string>.That.Contains("your order"))).MustHaveHappened();
        }
    }

    public class TestCoffee : Beverage
    {
        public override string GetDescription() => Description;
        public string Description { get; set; } = "A test coffee";
        public double TestableCost { get; set; }
        public override double Cost() => TestableCost;
        public override string ToString() => Description;
    }
}
