using FakeItEasy;
using NUnit.Framework;
using StarBuzz;

namespace StarBuzzCoffeeTests
{
    [TestFixture]
    public class OrderTests
    {
        private IStarBuzzConsole _writer;
        private Order _order;

        [SetUp]
        public void SetUp()
        {
            _writer = A.Fake<IStarBuzzConsole>();
            _order = new Order(_writer);
        }
        [Test]
        public void Should_be_able_to_add_a_beverage()
        {
            var order = new Order();
            order.AddBeverage(new TestCoffee());
            Assert.That(order.Items.Count, Is.EqualTo(1));
        }
        [Test]
        public void Should_be_able_to_print_order()
        {
            SetUp();
            _order.Print();
            A.CallTo(() => _writer.WriteLine(A<string>.That.Contains("You have 0 items in your order."))).MustHaveHappened();

            _order.AddBeverage(new TestCoffee());

            _order.Print();
            A.CallTo(() => _writer.WriteLine(A<string>.That.Contains("You have 1 items in your order."))).MustHaveHappened();

        }

        [Test]
        public void Should_print_order_total()
        {
            _order.AddBeverage(new TestCoffee(){TestableCost = 0.90});
            _order.Print();
            A.CallTo(() => _writer.WriteLine(A<string>.That.Contains("Total: £0.90"))).MustHaveHappened();

        }
    }
}
