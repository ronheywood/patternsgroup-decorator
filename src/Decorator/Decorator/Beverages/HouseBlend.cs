namespace StarBuzz.Beverages
{
    public class HouseBlend : Beverage
    {
        public override string GetDescription()
        {
            return
                "House Blend: We're not saying we swept these beans off the floor, but they do have a rich earthy taste.";
        }

        public override double Cost()
        {
            return 1.95;
        }
    }
}