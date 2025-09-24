namespace _10._Party_Reservation_Filter_Module
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var filters = new Dictionary<string, Predicate<string>>();
            List<string> invitationNames = Console.ReadLine().Split().ToList();

            string command = string.Empty;
            while (true)
            {
                command = Console.ReadLine();

                if (command == "Print")
                {
                    foreach (var item in filters)
                    {
                        invitationNames.RemoveAll(item.Value);
                    }

                    Console.WriteLine(string.Join(' ', invitationNames));
                    break;
                }

                string[] commandDetails = command.Split(';');
                string key = commandDetails[1] + "_" + commandDetails[2];

                if (commandDetails[0] == "Add filter")
                {
                    Predicate<string> predicate = GetPredicate(commandDetails[1], commandDetails[2]);
                    filters.Add(key, predicate);
                }
                else if (commandDetails[0] == "Remove filter")
                {
                    filters.Remove(key);
                }
            }
        }

        static Predicate<string> GetPredicate(string command, string param)
        {
            if (command == "Length")
            {
                return x => x.Length == int.Parse(param);
            }

            if (command == "Starts with")
            {
                return x => x.StartsWith(param);
            }

            if (command == "Ends with")
            {
                return x => x.EndsWith(param);
            }

            // if the command is "Contains"
            return x => x.Contains(param);
        }
    }
}