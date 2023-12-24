namespace NauticalCatchChallenge.Models.Divers
{
    public class FreeDiver : Diver
    {
        private const int DefaultOxygenLevel = 120;

        public FreeDiver(string name)
            : base(name, DefaultOxygenLevel)
        {

        }

        public override void Miss(int TimeToCatch)
        {
            this.OxygenLevel -= (int)Math.Round(0.6 * TimeToCatch, MidpointRounding.AwayFromZero);
        }

        public override void RenewOxy()
        {
            this.OxygenLevel = DefaultOxygenLevel;
        }
    }
}
