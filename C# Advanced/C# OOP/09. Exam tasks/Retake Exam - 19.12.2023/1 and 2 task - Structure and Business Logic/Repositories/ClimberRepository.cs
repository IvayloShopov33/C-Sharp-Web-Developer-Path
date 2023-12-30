using HighwayToPeak.Models.Contracts;
using HighwayToPeak.Repositories.Contracts;

namespace HighwayToPeak.Repositories
{
    public class ClimberRepository : IRepository<IClimber>
    {
        private List<IClimber> all;

        public ClimberRepository()
        {
            this.all = new List<IClimber>();
        }

        public IReadOnlyCollection<IClimber> All => this.all.AsReadOnly();

        public void Add(IClimber model)
        {
            this.all.Add(model);
        }

        public IClimber Get(string name)
        {
            return this.all.FirstOrDefault(x => x.Name == name);
        }
    }
}
