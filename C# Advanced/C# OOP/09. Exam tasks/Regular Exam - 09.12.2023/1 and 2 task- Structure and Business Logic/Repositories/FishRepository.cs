using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories.Contracts;

namespace NauticalCatchChallenge.Repositories
{
    public class FishRepository : IRepository<IFish>
    {
        private List<IFish> models;

        public FishRepository()
        {
            this.models = new List<IFish>();
        }

        public IReadOnlyCollection<IFish> Models => this.models.AsReadOnly();

        public void AddModel(IFish model)
        {
            this.models.Add(model);
        }

        public IFish GetModel(string name)
        {
            return this.models.FirstOrDefault(x => x.Name == name);
        }
    }
}
