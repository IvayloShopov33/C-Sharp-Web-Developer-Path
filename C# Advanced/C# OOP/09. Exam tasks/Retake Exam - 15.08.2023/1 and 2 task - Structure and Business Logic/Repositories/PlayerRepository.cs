using Handball.Models.Contracts;
using Handball.Repositories.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace Handball.Repositories
{
    public class PlayerRepository : IRepository<IPlayer>
    {
        private List<IPlayer> models;

        public PlayerRepository()
        {
            this.models = new List<IPlayer>();
        }

        public IReadOnlyCollection<IPlayer> Models => this.models.AsReadOnly();

        public void AddModel(IPlayer model)
        {
            this.models.Add(model);
        }

        public bool ExistsModel(string name)
        {
            return this.models.Any(x => x.Name == name);
        }

        public IPlayer GetModel(string name)
        {
            return this.models.FirstOrDefault(x => x.Name == name);
        }

        public bool RemoveModel(string name)
        {
            IPlayer model = this.models.FirstOrDefault(x => x.Name == name);

            return this.models.Remove(model);
        }
    }
}
