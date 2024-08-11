using System;
using System.Collections.Generic;
using System.Linq;

namespace _3._Heroes_of_Code_and_Logic_VII
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Hero> heroes = new List<Hero>();
            InitializeHeroesWithTheirDetails(heroes);
            RecieveCommands(heroes);
            PrintHeroes(heroes);
        }

        static void InitializeHeroesWithTheirDetails(List<Hero> heroes)
        {
            int heroesCount = int.Parse(Console.ReadLine());
            for (int i = 1; i <= heroesCount; i++)
            {
                string[] heroDetails = Console.ReadLine().Split();
                string heroName = heroDetails[0];
                int heroHP = int.Parse(heroDetails[1]);
                int heroMP = int.Parse(heroDetails[2]);
                Hero hero = new Hero(heroName, heroHP, heroMP);
                heroes.Add(hero);
            }
        }

        static void RecieveCommands(List<Hero> heroes)
        {
            string[] commands = Console.ReadLine().Split(" - ");
            while (commands[0] != "End")
            {
                string nameOfHero = commands[1];
                Hero selectedHero = heroes.First(x => x.Name == nameOfHero);
                if (commands[0] == "CastSpell")
                {
                    int neededMP = int.Parse(commands[2]);
                    string spellName = commands[3];
                    if (selectedHero.MP >= neededMP)
                    {
                        selectedHero.MP -= neededMP;
                        Console.WriteLine($"{nameOfHero} has successfully cast {spellName} and now has {selectedHero.MP} MP!");
                    }
                    else
                    {
                        Console.WriteLine($"{nameOfHero} does not have enough MP to cast {spellName}!");
                    }
                }
                else if (commands[0] == "TakeDamage")
                {
                    int damage = int.Parse(commands[2]);
                    string attacker = commands[3];
                    if (selectedHero.HP > damage)
                    {
                        selectedHero.HP -= damage;
                        Console.WriteLine($"{nameOfHero} was hit for {damage} HP by {attacker} and now has {selectedHero.HP} HP left!");
                    }
                    else
                    {
                        heroes.Remove(selectedHero);
                        Console.WriteLine($"{nameOfHero} has been killed by {attacker}!");
                    }
                }
                else if (commands[0] == "Recharge")
                {
                    int amount = int.Parse(commands[2]);
                    int newMP = selectedHero.MP + amount;
                    if (newMP <= 200)
                    {
                        selectedHero.MP += amount;
                        Console.WriteLine($"{nameOfHero} recharged for {amount} MP!");
                    }
                    else
                    {
                        int enoughMP = newMP - 200 - amount;
                        enoughMP = Math.Abs(enoughMP);
                        selectedHero.MP += enoughMP;
                        Console.WriteLine($"{nameOfHero} recharged for {enoughMP} MP!");
                    }
                }
                else if (commands[0] == "Heal")
                {
                    int amount = int.Parse(commands[2]);
                    int newHP = selectedHero.HP + amount;
                    if (newHP <= 100)
                    {
                        selectedHero.HP += amount;
                        Console.WriteLine($"{nameOfHero} healed for {amount} HP!");
                    }
                    else
                    {
                        int enoughHP = newHP - 100 - amount;
                        enoughHP = Math.Abs(enoughHP);
                        selectedHero.HP += enoughHP;
                        Console.WriteLine($"{nameOfHero} healed for {enoughHP} HP!");
                    }
                }
                commands = Console.ReadLine().Split(" - ");
            }
        }

        static void PrintHeroes(List<Hero> heroes)
        {
            foreach (Hero hero in heroes)
            {
                Console.WriteLine($"{hero.Name}");
                Console.WriteLine($"  HP: {hero.HP}");
                Console.WriteLine($"  MP: {hero.MP}");
            }
        }
    }

    public class Hero
    {
        public Hero(string name, int hp, int mp)
        {
            this.Name = name;
            this.HP = hp;
            this.MP = mp;
        }
        public string Name { get; private set; }
        public int HP { get; set; }
        public int MP { get; set; }
    }
}
