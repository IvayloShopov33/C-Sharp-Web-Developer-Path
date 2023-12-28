namespace Handball.Models.Players
{
    public class Goalkeeper : Player
    {
        private const double InitialRating = 2.5;

        public Goalkeeper(string name)
            : base(name, InitialRating)
        {

        }

        public override void DecreaseRating()
        {
            this.Rating -= 1.25;

            if (this.Rating < 1)
            {
                this.Rating = 1;
            }
        }

        public override void IncreaseRating()
        {
            this.Rating += 0.75;

            if (this.Rating > 10)
            {
                this.Rating = 10;
            }
        }
    }
}
