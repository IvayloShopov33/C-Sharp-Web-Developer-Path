using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories.Contracts;

namespace NauticalCatchChallenge.Repositories
{
    public class DiverRepository : IRepository<IDiver>
    {
        private List<IDiver> models;

        public DiverRepository()
        {
            this.models = new List<IDiver>();
        }

        public IReadOnlyCollection<IDiver> Models => this.models.AsReadOnly();

        public void AddModel(IDiver model)
        {
            this.models.Add(model);
        }

        public IDiver GetModel(string name)
        {
            return this.models.FirstOrDefault(x => x.Name == name);
        }
    }
}
