namespace _09._Pokemon_Trainer
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            string[] trainersAndPokemons;
            while (true)
            {
                trainersAndPokemons = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                if (trainersAndPokemons[0] == "Tournament")
                {
                    break;
                }

                string trainerName = trainersAndPokemons[0];
                string pokemonName = trainersAndPokemons[1];
                string pokemonElement = trainersAndPokemons[2];
                int pokemonHealth = int.Parse(trainersAndPokemons[3]);
                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                if (trainers.Any(x => x.Name == trainerName))
                {
                    Trainer trainer = trainers.First(x => x.Name == trainerName);
                    trainer.Pokemons.Add(pokemon);
                }
                else
                {
                    Trainer trainer = new Trainer(trainerName);
                    trainer.Pokemons.Add(pokemon);
                    trainers.Add(trainer);
                }

            }

            string command = string.Empty;
            while (true)
            {
                command = Console.ReadLine();

                if (command == "End")
                {
                    trainers = trainers.OrderByDescending(x => x.Badges).ToList();
                    foreach (Trainer trainer in trainers)
                    {
                        Console.WriteLine($"{trainer.Name} {trainer.Badges} {trainer.Pokemons.Count}");
                    }

                    break;
                }

                foreach (Trainer trainer in trainers)
                {
                    if (trainer.Pokemons.Any(x => x.Element == command))
                    {
                        trainer.Badges++;
                    }
                    else
                    {
                        foreach (Pokemon pokemon in trainer.Pokemons.ToList())
                        {
                            pokemon.Health -= 10;
                            if (pokemon.Health <= 0)
                            {
                                trainer.Pokemons.Remove(pokemon);
                            }
                        }
                    }
                }
            }
        }
    }
}