namespace _01._Apocalypse_Preparation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<int> textiles = new();
            Stack<int> medicaments = new();
            Dictionary<string, int> itemsCreated = new();

            List<int> textilesInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> medicamentsInput = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            foreach (int textile in textilesInput)
            {
                textiles.Enqueue(textile);
            }

            foreach (int medicament in medicamentsInput)
            {
                medicaments.Push(medicament);
            }

            while (textiles.Count > 0 && medicaments.Count > 0)
            {
                int textile = textiles.Dequeue();
                int medicament = medicaments.Pop();

                if (textile + medicament == 30)
                {
                    if (!itemsCreated.ContainsKey("Patch"))
                    {
                        itemsCreated.Add("Patch", 0);
                    }

                    itemsCreated["Patch"]++;
                }
                else if (textile + medicament == 40)
                {
                    if (!itemsCreated.ContainsKey("Bandage"))
                    {
                        itemsCreated.Add("Bandage", 0);
                    }

                    itemsCreated["Bandage"]++;
                }
                else if (textile + medicament == 100)
                {
                    if (!itemsCreated.ContainsKey("MedKit"))
                    {
                        itemsCreated.Add("MedKit", 0);
                    }

                    itemsCreated["MedKit"]++;
                }
                else if (textile + medicament > 100)
                {
                    if (!itemsCreated.ContainsKey("MedKit"))
                    {
                        itemsCreated.Add("MedKit", 0);
                    }

                    itemsCreated["MedKit"]++;

                    int newMedicament = medicaments.Pop() + (textile + medicament - 100);
                    medicaments.Push(newMedicament);
                }
                else
                {
                    medicaments.Push(medicament + 10);
                }
            }

            if (textiles.Count == 0 && medicaments.Count > 0)
            {
                Console.WriteLine("Textiles are empty.");
            }
            else if (textiles.Count > 0 && medicaments.Count == 0)
            {
                Console.WriteLine("Medicaments are empty.");
            }
            else if (textiles.Count == 0 && medicaments.Count == 0)
            {
                Console.WriteLine("Textiles and medicaments are both empty.");
            }

            foreach (var item in itemsCreated.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                Console.WriteLine($"{item.Key} - {item.Value}");
            }

            if (medicaments.Count > 0)
            {
                Console.WriteLine($"Medicaments left: {string.Join(", ", medicaments)}");
            }

            if (textiles.Count > 0)
            {
                Console.WriteLine($"Textiles left: {string.Join(", ", textiles)}");
            }
        }
    }
}