namespace StarBuzz.Beverages
{
    public abstract class Beverage
    {
        public abstract string GetDescription();
        public abstract double Cost();

        public override string ToString()
        {
            return (GetDescription() == string.Empty) ? GetType().Name : GetDescription();
        }
    }
}
