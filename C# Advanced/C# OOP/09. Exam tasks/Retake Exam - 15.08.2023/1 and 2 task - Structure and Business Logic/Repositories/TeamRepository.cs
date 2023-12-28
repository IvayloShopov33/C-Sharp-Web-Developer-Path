using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Handball.Repositories
{
    public class TeamRepository : IRepository<ITeam>
    {
        private List<ITeam> models;

        public TeamRepository()
        {
            this.models = new List<ITeam>();
        }

        public IReadOnlyCollection<ITeam> Models => this.models.AsReadOnly();

        public void AddModel(ITeam model)
        {
            this.models.Add(model);
        }

        public bool ExistsModel(string name)
        {
            return this.models.Any(x => x.Name == name);
        }

        public ITeam GetModel(string name)
        {
            return this.models.FirstOrDefault(x => x.Name == name);
        }

        public bool RemoveModel(string name)
        {
            ITeam team = this.models.FirstOrDefault(x => x.Name == name);

            return this.models.Remove(team);
        }
    }
}
