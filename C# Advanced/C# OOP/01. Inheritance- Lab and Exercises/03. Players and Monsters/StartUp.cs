using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            Hero hero = new Wizard("Shopov", 10);
            Console.WriteLine(hero);

            Elf elf = new MuseElf("Ronaldo", 15);
            Console.WriteLine(elf);

            Knight knight = new BladeKnight("Caesar", 60);
            Console.WriteLine(knight);
        }
    }
}