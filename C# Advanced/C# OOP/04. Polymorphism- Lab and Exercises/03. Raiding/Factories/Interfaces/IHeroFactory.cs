using Raiding.Models.Interfaces;

namespace Raiding.Factories.Interfaces
{
    public interface IHeroFactory
    {
        IBaseHero Create(string type, string name);
    }
}
