namespace NauticalCatchChallenge.Models.Divers
{
    public class ScubaDiver : Diver
    {
        private const int DefaultOxygenLevel = 540;

        public ScubaDiver(string name)
            : base(name, DefaultOxygenLevel)
        {

        }

        public override void Miss(int TimeToCatch)
        {
            this.OxygenLevel -= (int)Math.Round(0.3 * TimeToCatch, MidpointRounding.AwayFromZero);
        }

        public override void RenewOxy()
        {
            this.OxygenLevel = DefaultOxygenLevel;
        }
    }
}
