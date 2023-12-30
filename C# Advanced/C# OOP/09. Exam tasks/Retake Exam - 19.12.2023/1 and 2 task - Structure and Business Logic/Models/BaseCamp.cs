using HighwayToPeak.Models.Contracts;

namespace HighwayToPeak.Models
{
    public class BaseCamp : IBaseCamp
    {
        private List<string> residents;

        public BaseCamp() 
        {
            this.residents = new List<string>();
        }

        public IReadOnlyCollection<string> Residents => residents.OrderBy(x => x).ToList().AsReadOnly();

        public void ArriveAtCamp(string climberName)
        {
            residents.Add(climberName);
        }

        public void LeaveCamp(string climberName)
        {
            residents.Remove(climberName);
        }
    }
}
