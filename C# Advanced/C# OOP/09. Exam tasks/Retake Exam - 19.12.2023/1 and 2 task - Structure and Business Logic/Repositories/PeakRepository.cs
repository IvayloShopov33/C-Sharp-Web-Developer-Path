using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;

namespace HighwayToPeak.Repositories
{
    public class PeakRepository : IRepository<IPeak>
    {
        private List<IPeak> all;

        public PeakRepository()
        {
            this.all = new List<IPeak>();
        }

        public IReadOnlyCollection<IPeak> All => this.all.AsReadOnly();

        public void Add(IPeak model)
        {
            this.all.Add(model);
        }

        public IPeak Get(string name)
        {
            return this.all.FirstOrDefault(x => x.Name == name);
        }
    }
}
