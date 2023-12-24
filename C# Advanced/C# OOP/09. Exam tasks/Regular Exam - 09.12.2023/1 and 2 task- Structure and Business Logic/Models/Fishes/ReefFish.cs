namespace NauticalCatchChallenge.Models.Fishes
{
    public class ReefFish : Fish
    {
        private const int DefaultTimeToCatch = 30;

        public ReefFish(string name, double points)
            : base(name, points, DefaultTimeToCatch)
        {

        }
    }
}
