using System.Collections.Generic;
using FakeItEasy;
using NUnit.Framework;
using StarBuzz;
using StarBuzz.Beverages;
using StarBuzz.Condiments;

namespace StarBuzzCoffeeTests
{
    class CondimentsTest
    {
        private IStarBuzzConsole _writer;
        [SetUp]
        public void SetUp()
        {
            _writer = A.Fake<IStarBuzzConsole>();
        }
        [Test]
        public void Should_appear_in_the_store_menu()
        {
            var coffeeMenu = new List<Beverage>() {new DarkRoast(), new HouseBlend(), new Espresso(), new Decaf()};
            var condimentsMenu = new List<Condiment>() { new Whip(), new Mocha(), new Soy(), new SteamedMilk() };
            var testStore = new Store(coffeeMenu, condimentsMenu,_writer);
            testStore.PrintMenu();
            A.CallTo(() => _writer.WriteLine(A<string>.That.Contains("Condiments:"))).MustHaveHappened();

            A.CallTo(() => _writer.WriteLine(A<string>.That.Contains("Whipped Cream -"))).MustHaveHappened();
            A.CallTo(() => _writer.WriteLine(A<string>.That.Contains("Mocha Syrup -"))).MustHaveHappened();
            A.CallTo(() => _writer.WriteLine(A<string>.That.Contains("Soy Milk -"))).MustHaveHappened();
            A.CallTo(() => _writer.WriteLine(A<string>.That.Contains("Steamed Milk -"))).MustHaveHappened();

        }
        [Test]
        public void Should_not_appear_in_menu_if_empty()
        {
            var coffeeMenu = new List<Beverage>() { new DarkRoast(), new HouseBlend(), new Espresso(), new Decaf() };
            var testStore = new Store(coffeeMenu, null, _writer);
            testStore.PrintMenu();
            A.CallTo(() => _writer.WriteLine(A<string>.That.Contains("Condiments:"))).MustNotHaveHappened();
        }
        [Test]
        public void Should_show_cost_in_menu()
        {
            var coffeeMenu = new List<Beverage>() { new DarkRoast(), new HouseBlend(), new Espresso(), new Decaf() };
            var condimentsMenu = new List<Condiment>() { new Whip(), new Mocha(), new Soy(), new SteamedMilk() };
            var testStore = new Store(coffeeMenu, condimentsMenu, _writer);
            testStore.PrintMenu();
            A.CallTo(() => _writer.WriteLine(A<string>.That.Contains("Whipped Cream - £0.25"))).MustHaveHappened();

        }
        [Test]
        public void Should_be_added_to_the_cost_of_a_beverage()
        {
            var condiment = new DarkRoastWithWhip(new TestCoffee(){TestableCost = 3.50});
            Assert.That(condiment.Cost(), Is.EqualTo(3.75));
        }
        [Test]
        public void Should_be_appended_to_the_coffee_description()
        {
            var testCoffee = new TestCoffee() { TestableCost = 3.50, Description = "Test coffee description"};
            var condiment = new DarkRoastWithWhip(testCoffee);
            Assert.That(condiment.GetDescription, Is.EqualTo("Test coffee description with Whipped Cream"));
        }
//        [Test]
//        public void Two_condiments_can_be_added()
//        {
//            var testCoffee = new TestCoffee() { TestableCost = 3.50, Description = "Test coffee description" };
//            var condiment = new DarkRoastWithWhip(testCoffee);
//            var condiment2 = new DaekRoastWithMochaWhip(testCoffee);
//            Assert.That(condiment2, Is.EqualTo("wait... this is going to get messy"));
//        }
    }

    public class DarkRoastWithWhip : Beverage
    {
        private readonly Beverage _beverage;

        public DarkRoastWithWhip(Beverage beverage)
        {
            _beverage = beverage;
        }
        public override string GetDescription() => $"{_beverage.GetDescription()} with Whipped Cream";

        public override double Cost()
        {
            return _beverage.Cost() + 0.25;
        }
    }
}
