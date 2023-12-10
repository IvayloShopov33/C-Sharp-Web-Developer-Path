using WildFarm.Core.Interfaces;
using WildFarm.Factories.Interfaces;
using WildFarm.IO.Interfaces;
using WildFarm.Models.Interfaces;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IAnimalFactory animalFactory;
        private readonly IFoodFactory foodFactory;
        private readonly ICollection<IAnimal> animals;

        public Engine(IReader reader, IWriter writer, IAnimalFactory animalFactory, IFoodFactory foodFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.animalFactory = animalFactory;
            this.foodFactory = foodFactory;
            this.animals = new List<IAnimal>();
        }

        public void Run()
        {
            string[] animalTokens;
            string[] foodTokens;
            while (true)
            {
                animalTokens = this.reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (animalTokens[0] == "End")
                {
                    break;
                }

                foodTokens = this.reader.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string foodType = foodTokens[0];
                int foodQuantity = int.Parse(foodTokens[1]);
                IAnimal animal = null;
                IFood food = null;

                try
                {
                    animal = this.animalFactory.CreateAnimal(animalTokens);
                    food = this.foodFactory.CreateFood(foodType, foodQuantity);

                    this.writer.WriteLine(animal.ProduceSound());
                    animal.Eat(food);
                }
                catch (ArgumentException ex)
                {
                    this.writer.WriteLine(ex.Message);
                }
                catch (Exception)
                {
                    throw;
                }

                this.animals.Add(animal);
            }

            foreach (IAnimal animal in this.animals)
            {
                this.writer.WriteLine(animal.ToString());
            }
        }
    }
}
