namespace _9._Predicate_Party_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Func<string, string, bool> isStartWith = (x, y) => x.StartsWith(y);
            Func<string, string, bool> isEndWith = (x, y) => x.EndsWith(y);
            Func<int, int, bool> areLengthsEqual = (x, y) => x == y;

            List<string> guests = Console.ReadLine().Split().ToList();
            string input = string.Empty;
            while (true)
            {
                input = Console.ReadLine();

                if (input == "Party!")
                {
                    if (guests.Count > 0)
                    {
                        Console.WriteLine($"{string.Join(", ", guests)} are going to the party!");
                    }
                    else
                    {
                        Console.WriteLine("Nobody is going to the party!");
                    }

                    break;
                }

                string[] command = input.Split();
                if (command[0] == "Remove")
                {
                    RemoveAllOccurrences(guests, isStartWith, isEndWith, areLengthsEqual, command);
                }
                else if (command[0] == "Double")
                {
                    DoubleAllOccurrences(guests, isStartWith, isEndWith, areLengthsEqual, command);
                }
            }
        }

        static void RemoveAllOccurrences(List<string> guests, Func<string, string, bool> isStartWith, Func<string, string, bool> isEndWith, Func<int, int, bool> areLengthsEqual, string[] command)
        {
            if (command[1] == "StartsWith")
            {
                string textToCompare = command[2];
                foreach (string guest in guests.ToList())
                {
                    if (isStartWith(guest, textToCompare))
                    {
                        guests.Remove(guest);
                    }
                }
            }
            else if (command[1] == "EndsWith")
            {
                string textToCompare = command[2];
                foreach (string guest in guests.ToList())
                {
                    if (isEndWith(guest, textToCompare))
                    {
                        guests.Remove(guest);
                    }
                }
            }
            else if (command[1] == "Length")
            {
                int lengthToCompare = int.Parse(command[2]);
                foreach (string guest in guests.ToList())
                {
                    if (areLengthsEqual(guest.Length, lengthToCompare))
                    {
                        guests.Remove(guest);
                    }
                }
            }
        }

        static void DoubleAllOccurrences(List<string> guests, Func<string, string, bool> isStartWith, Func<string, string, bool> isEndWith, Func<int, int, bool> areLengthsEqual, string[] command)
        {
            if (command[1] == "StartsWith")
            {
                string textToCompare = command[2];
                for (int i = 0; i < guests.Count; i++)
                {
                    if (isStartWith(guests[i], textToCompare))
                    {
                        guests.Insert(i, guests[i]);
                        i++;
                    }
                }
            }
            else if (command[1] == "EndsWith")
            {
                string textToCompare = command[2];
                for (int i = 0; i < guests.Count; i++)
                {
                    if (isEndWith(guests[i], textToCompare))
                    {
                        guests.Insert(i, guests[i]);
                        i++;
                    }
                }
            }
            else if (command[1] == "Length")
            {
                int lengthToCompare = int.Parse(command[2]);
                for (int i = 0; i < guests.Count; i++)
                {
                    if (areLengthsEqual(guests[i].Length, lengthToCompare))
                    {
                        guests.Insert(i, guests[i]);
                        i++;
                    }
                }
            }
        }

    }
}