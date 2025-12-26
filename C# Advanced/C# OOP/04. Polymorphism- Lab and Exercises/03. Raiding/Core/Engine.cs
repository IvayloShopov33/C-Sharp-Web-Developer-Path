using Raiding.Core.Interfaces;
using Raiding.Factories.Interfaces;
using Raiding.IO.Interfaces;
using Raiding.Models.Interfaces;

namespace Raiding.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IHeroFactory heroesFactory;
        private readonly ICollection<IBaseHero> heroes;

        public Engine(IReader reader, IWriter writer, IHeroFactory heroesFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.heroesFactory = heroesFactory;
            this.heroes = new List<IBaseHero>();
        }

        public void Run()
        {
            int heroesCount = int.Parse(this.reader.ReadLine());

            for (int i = 1; i <= heroesCount; i++)
            {
                string name = this.reader.ReadLine();
                string typeOfHero = this.reader.ReadLine();

                try
                {
                    this.heroes.Add(this.heroesFactory.Create(typeOfHero, name));
                }
                catch (Exception ex)
                {
                    writer.WriteLine(ex.Message);
                    i--;
                }
            }

            foreach (IBaseHero hero in this.heroes)
            {
                writer.WriteLine(hero.CastAbility());
            }

            int totalPower = this.heroes.Select(x => x.Power).Sum();
            int bossPower = int.Parse(reader.ReadLine());

            if (totalPower >= bossPower)
            {
                writer.WriteLine("Victory!");
            }
            else
            {
                writer.WriteLine("Defeat...");
            }
        }
    }
}