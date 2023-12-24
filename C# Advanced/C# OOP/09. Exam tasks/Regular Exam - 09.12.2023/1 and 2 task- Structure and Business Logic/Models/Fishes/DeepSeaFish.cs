namespace NauticalCatchChallenge.Models.Fishes
{
    public class DeepSeaFish : Fish
    {
        private const int DefaultTimeToCatch = 180;

        public DeepSeaFish(string name, double points) 
            : base(name, points, DefaultTimeToCatch)
        {

        }
    }
}
