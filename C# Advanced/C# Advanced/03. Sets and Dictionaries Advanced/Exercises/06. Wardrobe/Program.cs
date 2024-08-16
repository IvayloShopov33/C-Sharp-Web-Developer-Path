namespace _6._Wardrobe
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> clothes =
                new Dictionary<string, Dictionary<string, int>>();
            int inputLinesCount = int.Parse(Console.ReadLine());
            for (int i = 1; i <= inputLinesCount; i++)
            {
                string[] colorWithClothes = Console.ReadLine().Split(" -> ");
                string color = colorWithClothes[0];
                string[] clothesWithTheSameColor = colorWithClothes[1].Split(',');
                
                //check if the color is not present in the dictionary
                if (!clothes.ContainsKey(color))
                {
                    //add the color to the dictionary
                    clothes.Add(color, new Dictionary<string, int>());
                }

                foreach (var item in clothesWithTheSameColor)
                {
                    //check if the garment is not present in the value of the current color
                    if (!clothes[color].ContainsKey(item))
                    {
                        //add the garment to the value of this color
                        clothes[color].Add(item, 0);
                    }

                    //increase the count of the current garment
                    clothes[color][item]++;
                }
            }

            string[] garmentToSearch = Console.ReadLine().Split();
            string colorToSearch = garmentToSearch[0];
            string garment = garmentToSearch[1];
            foreach (var color in clothes)
            {
                Console.WriteLine($"{color.Key} clothes:");
                foreach (var wear in color.Value)
                {
                    Console.Write($"* {wear.Key} - {wear.Value} ");
                    
                    //check if the current garment is the searched one
                    if (color.Key == colorToSearch && wear.Key == garment)
                    {
                        Console.Write("(found!)");
                    }

                    Console.WriteLine();
                }
            }
        }
    }
}
