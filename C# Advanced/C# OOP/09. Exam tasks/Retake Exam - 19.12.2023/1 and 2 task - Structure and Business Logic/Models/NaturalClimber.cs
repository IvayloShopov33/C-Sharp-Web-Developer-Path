namespace HighwayToPeak.Models
{
    public class NaturalClimber : Climber
    {
        private const int InitialStamina = 6;

        public NaturalClimber(string name)
            : base(name, InitialStamina)
        {

        }

        public override void Rest(int daysCount)
        {
            int recovery = 2 * daysCount;
            Stamina += recovery;

            if (Stamina > 10)
            {
                Stamina = 10;
            }
        }
    }
}
