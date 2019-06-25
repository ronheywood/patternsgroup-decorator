namespace StarBuzz.Beverages
{
    public class DarkRoast : Beverage
    {
        public override string GetDescription() => "Most Excellent Dark Roast";

        public override double Cost()
        {
            return 3.50;
        }
    }
}
