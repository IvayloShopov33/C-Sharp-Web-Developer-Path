namespace Handball.Models.Players
{
    public class CenterBack : Player
    {
        private const double InitialRating = 4;

        public CenterBack(string name)
            : base(name, InitialRating)
        {

        }

        public override void DecreaseRating()
        {
            this.Rating--;

            if (this.Rating < 1)
            {
                this.Rating = 1;
            }
        }

        public override void IncreaseRating()
        {
            this.Rating++;

            if (this.Rating > 10)
            {
                this.Rating = 10;
            }
        }
    }
}
