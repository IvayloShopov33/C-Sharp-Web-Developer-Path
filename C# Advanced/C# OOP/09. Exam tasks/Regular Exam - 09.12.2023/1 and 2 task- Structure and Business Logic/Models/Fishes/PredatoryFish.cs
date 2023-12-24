namespace NauticalCatchChallenge.Models.Fishes
{
    public class PredatoryFish : Fish
    {
        private const int DefaultTimeToCatch = 60;

        public PredatoryFish(string name, double points)
            : base(name, points, DefaultTimeToCatch)
        {

        }
    }
}
