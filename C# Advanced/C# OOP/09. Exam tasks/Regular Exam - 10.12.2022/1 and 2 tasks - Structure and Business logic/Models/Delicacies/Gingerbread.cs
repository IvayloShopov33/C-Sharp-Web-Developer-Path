namespace ChristmasPastryShop.Models.Delicacies
{
    public class Gingerbread : Delicacy
    {
        private const double GingerBreadPrice = 4.00;

        public Gingerbread(string name)
            : base(name, GingerBreadPrice)
        {

        }
    }
}
